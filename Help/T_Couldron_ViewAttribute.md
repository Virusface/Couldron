# ViewAttribute Class
 _**\[This is preliminary documentation and is subject to change.\]**_

Specifies a view for a the viewmodel


## Inheritance Hierarchy
System.Object<br />&nbsp;&nbsp;System.Attribute<br />&nbsp;&nbsp;&nbsp;&nbsp;Couldron.ViewAttribute<br />
**Namespace:**&nbsp;<a href="N_Couldron">Couldron</a><br />**Assembly:**&nbsp;Couldron (in Couldron.dll) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
[AttributeUsageAttribute(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ViewAttribute : Attribute
```

The ViewAttribute type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Couldron_ViewAttribute__ctor">ViewAttribute</a></td><td>
Initializes a new instance of ViewAttribute</td></tr></table>&nbsp;
<a href="#viewattribute-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td>TypeId</td><td> (Inherited from Attribute.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Couldron_ViewAttribute_ViewType">ViewType</a></td><td>
Gets the Type of the view</td></tr></table>&nbsp;
<a href="#viewattribute-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td>Equals</td><td> (Inherited from Attribute.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td>Finalize</td><td> (Inherited from Object.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td>GetHashCode</td><td> (Inherited from Attribute.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td>GetType</td><td> (Inherited from Object.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td>IsDefaultAttribute</td><td> (Inherited from Attribute.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td>Match</td><td> (Inherited from Attribute.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td>MemberwiseClone</td><td> (Inherited from Object.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td>ToString</td><td> (Inherited from Object.)</td></tr></table>&nbsp;
<a href="#viewattribute-class">Back to Top</a>

## Extension Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Couldron_Extensions_CastTo__1">CastTo(T)</a></td><td>
Performs certain types of conversions between compatible reference types or nullable types 

 Returns null if convertion was not successfull
 (Defined by <a href="T_Couldron_Extensions">Extensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Couldron_Extensions_DisposeAll">DisposeAll</a></td><td>
Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. 

 This will dispose an object if it implements the IDisposable interface. 

 If the object is a FrameworkElement it will try to find known diposable attached properties. 

 It will also dispose the the DataContext content.
 (Defined by <a href="T_Couldron_Extensions">Extensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Couldron_ExtensionConvertions_ToBool">ToBool</a></td><td>
Tries to convert an Object to a Boolean
 (Defined by <a href="T_Couldron_ExtensionConvertions">ExtensionConvertions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Couldron_ExtensionConvertions_ToDouble">ToDouble</a></td><td>
Tries to convert a Object to an Double
 (Defined by <a href="T_Couldron_ExtensionConvertions">ExtensionConvertions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Couldron_ExtensionConvertions_ToInteger">ToInteger</a></td><td>
Tries to convert a Object to an Int32
 (Defined by <a href="T_Couldron_ExtensionConvertions">ExtensionConvertions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Couldron_ExtensionConvertions_ToString2">ToString2</a></td><td>
Returns a string that represents the current object. 

 If the object is null a Empty will be returned
 (Defined by <a href="T_Couldron_ExtensionConvertions">ExtensionConvertions</a>.)</td></tr></table>&nbsp;
<a href="#viewattribute-class">Back to Top</a>

## Explicit Interface Implementations
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Explicit interface implementation](media/pubinterface.gif "Explicit interface implementation")![Private method](media/privmethod.gif "Private method")</td><td>_Attribute.GetIDsOfNames</td><td> (Inherited from Attribute.)</td></tr><tr><td>![Explicit interface implementation](media/pubinterface.gif "Explicit interface implementation")![Private method](media/privmethod.gif "Private method")</td><td>_Attribute.GetTypeInfo</td><td> (Inherited from Attribute.)</td></tr><tr><td>![Explicit interface implementation](media/pubinterface.gif "Explicit interface implementation")![Private method](media/privmethod.gif "Private method")</td><td>_Attribute.GetTypeInfoCount</td><td> (Inherited from Attribute.)</td></tr><tr><td>![Explicit interface implementation](media/pubinterface.gif "Explicit interface implementation")![Private method](media/privmethod.gif "Private method")</td><td>_Attribute.Invoke</td><td> (Inherited from Attribute.)</td></tr></table>&nbsp;
<a href="#viewattribute-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Couldron">Couldron Namespace</a><br />