﻿using Cauldron.Interception.Cecilator;
using Cauldron.Interception.Fody.Extensions;
using Cauldron.Interception.Fody.HelperTypes;
using System.Collections.Generic;
using System.Linq;

namespace Cauldron.Interception.Fody
{
    public sealed class PropertyBuilderInfo
    {
        private Field _syncRoot;

        public PropertyBuilderInfo(Property property, IEnumerable<PropertyBuilderInfoItem> item)
        {
            this.Property = property;
            this.InterceptorInfos = item.ToArray();
        }

        public bool HasGetterInterception => this.InterceptorInfos.Any(x => x.InterfaceGetter != null);
        public bool HasSetterInterception => this.InterceptorInfos.Any(x => x.InterfaceSetter != null);
        public PropertyBuilderInfoItem[] InterceptorInfos { get; private set; }
        public Property Property { get; private set; }

        public bool RequiresSyncRootField => this.InterceptorInfos?.Any(x => x.HasSyncRootInterface) ?? false;

        public Field SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                    _syncRoot = this.Property.DeclaringType.CreateField(this.Property.Modifiers.GetPrivate(), typeof(object), $"<{this.Property.Name}>_syncObject_{this.Property.Identification}");

                return _syncRoot;
            }
        }
    }

    public sealed class PropertyBuilderInfoItem
    {
        public PropertyBuilderInfoItem(AttributedProperty attribute, Property property, __IPropertyGetterInterceptor interfaceGetter, __IPropertySetterInterceptor interfaceSetter)
        {
            this.Attribute = attribute;
            this.InterfaceGetter = interfaceGetter;
            this.InterfaceSetter = interfaceSetter;
            this.Property = property;
            this.HasSyncRootInterface = attribute.Attribute.Type.Implements(__ISyncRoot.TypeName);
        }

        public AttributedProperty Attribute { get; private set; }
        public bool HasSyncRootInterface { get; private set; }
        public __IPropertyGetterInterceptor InterfaceGetter { get; private set; }
        public __IPropertySetterInterceptor InterfaceSetter { get; private set; }
        public Property Property { get; private set; }
    }
}