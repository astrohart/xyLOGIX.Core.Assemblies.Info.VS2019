<a name='assembly'></a>
# xyLOGIX.Core.Assemblies.Info

## Contents

- [AssemblyMetadata](#T-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata')
  - [AssemblyCompany](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyCompany 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyCompany')
  - [AssemblyProduct](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyProduct 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyProduct')
  - [AssemblyTitle](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyTitle 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyTitle')
  - [AssemblyVersion](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyVersion 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyVersion')
- [Get](#T-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-Get 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.Get')
  - [AssemblyToUse()](#M-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-Get-AssemblyToUse 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.Get.AssemblyToUse')
- [Resources](#T-xyLOGIX-Core-Assemblies-Info-Properties-Resources 'xyLOGIX.Core.Assemblies.Info.Properties.Resources')
  - [Culture](#P-xyLOGIX-Core-Assemblies-Info-Properties-Resources-Culture 'xyLOGIX.Core.Assemblies.Info.Properties.Resources.Culture')
  - [ResourceManager](#P-xyLOGIX-Core-Assemblies-Info-Properties-Resources-ResourceManager 'xyLOGIX.Core.Assemblies.Info.Properties.Resources.ResourceManager')

<a name='T-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata'></a>
## AssemblyMetadata `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info

##### Summary

Exposes static methods to obtain data from various sources.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyCompany'></a>
### AssemblyCompany `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyCompany]` attribute from the `AssemblyInfo.cs`
file of the calling assembly.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyProduct'></a>
### AssemblyProduct `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyProduct]` attribute from the `AssemblyInfo.cs`
file of the calling assembly.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyTitle'></a>
### AssemblyTitle `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyTitle]` attribute from the `AssemblyInfo.cs` file
of the calling assembly.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyVersion'></a>
### AssemblyVersion `property`

##### Summary

Gets the full version of the application.

<a name='T-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-Get'></a>
## Get `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info.AssemblyMetadata

##### Summary

Exposes static methods to get values.

<a name='M-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-Get-AssemblyToUse'></a>
### AssemblyToUse() `method`

##### Summary

Attempts to get the [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') instance that
is to be used to gather attributes.

##### Returns

If successful, the [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly')
instance that is to be used to gather attributes, or `null` if
not possible.

##### Parameters

This method has no parameters.

##### Remarks

This library can be called either from a unit test, or from a EXE.



We basically ask the calling assembly whether its pathname ends with
`Tests.dll`.  If affirmative, then the return value of the
[GetCallingAssembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly.GetCallingAssembly 'System.Reflection.Assembly.GetCallingAssembly') method is
fetched.



Otherwise, we assume that we have been called from a WinForms or Console or WPF
EXE application; therefore, the return value of this method is that of the
[GetEntryAssembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly.GetEntryAssembly 'System.Reflection.Assembly.GetEntryAssembly') method.

<a name='T-xyLOGIX-Core-Assemblies-Info-Properties-Resources'></a>
## Resources `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-xyLOGIX-Core-Assemblies-Info-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-xyLOGIX-Core-Assemblies-Info-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.
