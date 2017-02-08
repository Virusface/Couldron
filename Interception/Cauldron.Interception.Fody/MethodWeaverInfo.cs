﻿using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Cauldron.Interception.Fody
{
    public sealed class MethodWeaverInfo
    {
        public static volatile uint index = 0;

        public MethodWeaverInfo(MethodDefinition method)
        {
            if (index + 1 == uint.MaxValue)
                index = 0;

            this.Id = (index++).ToString();
            this.MethodDefinition = method;
            this.OriginalBody = method.Body.Instructions.ToList();
            this.Processor = method.Body.GetILProcessor();
            this.LastReturn = this.Processor.Create(OpCodes.Ret);
            this.Property = method.GetPropertyDefinition();
            this.AutoPropertyBackingField = this.OriginalBody.FirstOrDefault(x => x.OpCode == OpCodes.Ldfld || x.OpCode == OpCodes.Ldsfld || x.OpCode == OpCodes.Stfld || x.OpCode == OpCodes.Stsfld)?.Operand as FieldDefinition;

            var fieldAttribute = FieldAttributes.Private;

            if (method.IsStatic)
                fieldAttribute |= FieldAttributes.Static;

            this.MethodBaseField = this.Property == null ? this.GetOrCreateField(typeof(System.Reflection.MethodBase)) : null;
        }

        public FieldDefinition AutoPropertyBackingField { get; private set; }

        public List<Instruction> ExceptionInstructions { get; private set; } = new List<Instruction>();

        public List<Instruction> FinallyInstructions { get; private set; } = new List<Instruction>();

        public string Id { get; private set; }

        public List<Instruction> Initializations { get; private set; } = new List<Instruction>();

        public Instruction LastReturn { get; private set; }

        public FieldDefinition MethodBaseField { get; private set; }

        public MethodDefinition MethodDefinition { get; private set; }

        public List<Instruction> OnEnterInstructions { get; private set; } = new List<Instruction>();

        public List<Instruction> OriginalBody { get; set; }

        public ILProcessor Processor { get; private set; }

        public PropertyDefinition Property { get; private set; }

        public void Build()
        {
            this.Processor.Append(this.Initializations);
            this.Processor.Append(this.OnEnterInstructions);
            this.Processor.Append(this.OriginalBody);
            this.Processor.Append(this.ExceptionInstructions);
            this.Processor.Append(this.FinallyInstructions);
            this.Processor.Append(this.LastReturn);
        }

        public FieldDefinition GetField(Type fieldType) => this.GetField(fieldType.GetTypeReference());

        public FieldDefinition GetField(TypeReference fieldType)
        {
            string fieldName;

            if (this.Property != null)
                fieldName = $"<{this.Property.Name}>k_{fieldType.Name.ToLower()}";
            else
                fieldName = $"<{this.MethodDefinition.Name}>k_{fieldType.Name.ToLower()}{this.Id}";

            return this.MethodDefinition.DeclaringType.Fields.FirstOrDefault(x => x.Name == fieldName);
        }

        public MethodDefinition GetMethod(string name, params ParameterDefinition[] parameters) => this.GetMethod(name, this.MethodDefinition.Module.TypeSystem.Void, parameters);

        public MethodDefinition GetMethod(string name, TypeReference returnType, params ParameterDefinition[] parameters)
        {
            string methodName;

            if (this.Property != null)
                methodName = $"<{this.Property.Name}>m_{name.ToLower()}";
            else
                methodName = $"<{this.MethodDefinition.Name}>m_{name.ToLower()}{this.Id}";

            return this.MethodDefinition.DeclaringType.Methods.FirstOrDefault(x => x.Name == methodName && x.ReturnType.FullName == returnType.FullName &&
                x.Parameters.Select(y => y.ParameterType.FullName).SequenceEqual(parameters.Select(y => y.ParameterType.FullName)));
        }

        public FieldDefinition GetOrCreateField(Type fieldType) => this.GetOrCreateField(fieldType.GetTypeReference());

        public FieldDefinition GetOrCreateField(TypeReference fieldType)
        {
            var field = this.GetField(fieldType);

            if (field != null)
                return field;

            string fieldName;

            if (this.Property != null)
                fieldName = $"<{this.Property.Name}>k_{fieldType.Name.ToLower()}";
            else
                fieldName = $"<{this.MethodDefinition.Name}>k_{fieldType.Name.ToLower()}{this.Id}";

            var attributes = FieldAttributes.Private;

            if (this.MethodDefinition.IsStatic)
                attributes |= FieldAttributes.Static;

            field = new FieldDefinition(fieldName, attributes, fieldType.Import());

            var attribute = new CustomAttribute(typeof(DebuggerBrowsableAttribute).GetMethodReference(".ctor", 1).Import());
            attribute.ConstructorArguments.Add(new CustomAttributeArgument(typeof(DebuggerBrowsableState).GetTypeReference().Import(), DebuggerBrowsableState.Never));
            field.CustomAttributes.Add(attribute);

            this.MethodDefinition.DeclaringType.Fields.Add(field);

            return field;
        }

        public MethodDefinition GetOrCreateMethod(string name, params ParameterDefinition[] parameters) => this.GetOrCreateMethod(name, this.MethodDefinition.Module.TypeSystem.Void, parameters);

        public MethodDefinition GetOrCreateMethod(string name, TypeReference returnType, params ParameterDefinition[] parameters)
        {
            var method = this.GetMethod(name, returnType, parameters);

            if (method != null)
                return method;

            string methodName;

            if (this.Property != null)
                methodName = $"<{this.Property.Name}>m_{name.ToLower()}";
            else
                methodName = $"<{this.MethodDefinition.Name}>m_{name.ToLower()}{this.Id}";

            var attributes = MethodAttributes.Private;

            if (this.MethodDefinition.IsStatic)
                attributes |= MethodAttributes.Static;

            method = new MethodDefinition(methodName, attributes, returnType);
            foreach (var item in parameters)
                method.Parameters.Add(item);

            this.MethodDefinition.DeclaringType.Methods.Add(method);

            return method;
        }
    }
}