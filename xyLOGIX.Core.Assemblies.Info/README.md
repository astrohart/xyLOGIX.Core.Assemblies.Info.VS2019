<a name='assembly'></a>
# xyLOGIX.Core.Assemblies.Info

## Contents

- [AssemblyMetadata](#T-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata')
  - [AssemblyCompany](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyCompany 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyCompany')
  - [AssemblyCopyright](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyCopyright 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyCopyright')
  - [AssemblyDescription](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyDescription 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyDescription')
  - [AssemblyProduct](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyProduct 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyProduct')
  - [AssemblyTitle](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyTitle 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyTitle')
  - [AssemblyVersion](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyVersion 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyVersion')
  - [DesiredAssembly](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-DesiredAssembly 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.DesiredAssembly')
  - [FormalApplicationName](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-FormalApplicationName 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.FormalApplicationName')
  - [ShortCompanyName](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-ShortCompanyName 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.ShortCompanyName')
  - [ShortProductName](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-ShortProductName 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.ShortProductName')
  - [UseExecutingAssembly](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-UseExecutingAssembly 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.UseExecutingAssembly')
  - [HasWhiteSpace(value)](#M-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-HasWhiteSpace-System-String- 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.HasWhiteSpace(System.String)')
- [AssemblyReferenceRequestedEventHandler](#T-xyLOGIX-Core-Assemblies-Info-AssemblyReferenceRequestedEventHandler 'xyLOGIX.Core.Assemblies.Info.AssemblyReferenceRequestedEventHandler')
- [Find](#T-xyLOGIX-Core-Assemblies-Info-Find 'xyLOGIX.Core.Assemblies.Info.Find')
  - [AllAssembliesThatDependOn(executingAssembly)](#M-xyLOGIX-Core-Assemblies-Info-Find-AllAssembliesThatDependOn-System-Reflection-Assembly- 'xyLOGIX.Core.Assemblies.Info.Find.AllAssembliesThatDependOn(System.Reflection.Assembly)')
  - [DependsOn(currentAssembly,executingAssembly)](#M-xyLOGIX-Core-Assemblies-Info-Find-DependsOn-System-Reflection-Assembly,System-Reflection-Assembly- 'xyLOGIX.Core.Assemblies.Info.Find.DependsOn(System.Reflection.Assembly,System.Reflection.Assembly)')
- [Get](#T-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-Get 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.Get')
- [Get](#T-xyLOGIX-Core-Assemblies-Info-Get 'xyLOGIX.Core.Assemblies.Info.Get')
  - [AssemblyCompany](#P-xyLOGIX-Core-Assemblies-Info-Get-AssemblyCompany 'xyLOGIX.Core.Assemblies.Info.Get.AssemblyCompany')
  - [AssemblyProduct](#P-xyLOGIX-Core-Assemblies-Info-Get-AssemblyProduct 'xyLOGIX.Core.Assemblies.Info.Get.AssemblyProduct')
  - [AssemblyTitle](#P-xyLOGIX-Core-Assemblies-Info-Get-AssemblyTitle 'xyLOGIX.Core.Assemblies.Info.Get.AssemblyTitle')
  - [AssemblyToUse()](#M-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-Get-AssemblyToUse 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.Get.AssemblyToUse')
  - [#cctor()](#M-xyLOGIX-Core-Assemblies-Info-Get-#cctor 'xyLOGIX.Core.Assemblies.Info.Get.#cctor')
- [Resources](#T-xyLOGIX-Core-Assemblies-Info-Properties-Resources 'xyLOGIX.Core.Assemblies.Info.Properties.Resources')
  - [Culture](#P-xyLOGIX-Core-Assemblies-Info-Properties-Resources-Culture 'xyLOGIX.Core.Assemblies.Info.Properties.Resources.Culture')
  - [ResourceManager](#P-xyLOGIX-Core-Assemblies-Info-Properties-Resources-ResourceManager 'xyLOGIX.Core.Assemblies.Info.Properties.Resources.ResourceManager')
- [StackFrameExtensions](#T-xyLOGIX-Core-Assemblies-Info-StackFrameExtensions 'xyLOGIX.Core.Assemblies.Info.StackFrameExtensions')
  - [GetDeclaringAssembly(frame)](#M-xyLOGIX-Core-Assemblies-Info-StackFrameExtensions-GetDeclaringAssembly-System-Diagnostics-StackFrame- 'xyLOGIX.Core.Assemblies.Info.StackFrameExtensions.GetDeclaringAssembly(System.Diagnostics.StackFrame)')

<a name='T-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata'></a>
## AssemblyMetadata `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info

##### Summary

Exposes `static` methods to obtain data from various
sources.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyCompany'></a>
### AssemblyCompany `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyCompany]` attribute from the `AssemblyInfo.cs`
file of the calling assembly.

##### Remarks

This property returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value
if it could not interrogate the target assembly for the requested information.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyCopyright'></a>
### AssemblyCopyright `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyCopyright]` attribute from the `AssemblyInfo.cs`
file of the calling assembly.

##### Remarks

This property returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value
if it could not interrogate the target assembly for the requested information.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyDescription'></a>
### AssemblyDescription `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyDescription]` attribute from the
`AssemblyInfo.cs` file of the calling assembly.

##### Remarks

This property returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value
if it could not interrogate the target assembly for the requested information.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyProduct'></a>
### AssemblyProduct `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyProduct]` attribute from the `AssemblyInfo.cs`
file of the calling assembly.

##### Remarks

This property returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value
if it could not interrogate the target assembly for the requested information.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyTitle'></a>
### AssemblyTitle `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyTitle]` attribute from the `AssemblyInfo.cs` file
of the calling assembly.

##### Remarks

This property returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value
if it could not interrogate the target assembly for the requested information.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyVersion'></a>
### AssemblyVersion `property`

##### Summary

Gets the full version [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') of the calling
assembly.

##### Remarks

This property returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value
if it could not interrogate the target assembly for the requested information.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-DesiredAssembly'></a>
### DesiredAssembly `property`

##### Summary

Gets or sets a reference to an instance of
[Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly')
that indicates which `Assembly` metadata to use for the values of the
properties.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-FormalApplicationName'></a>
### FormalApplicationName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the formal name of the
application.

##### Remarks

The formal name is something such as
`xyLOGIX My Application 2.0.35.2965`, where `xyLOGIX` is the
`Short Company Name`, `My Application` is the `Product Name`,
and `2.0.35.2965` is the `Version`.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-ShortCompanyName'></a>
### ShortCompanyName `property`

##### Summary

Gets the shortened form of the name of the company that is associated
with the target assembly.

##### Remarks

The shortened form of a company is that which does not contain "LLC",
or ", Inc." etc.



This property assumes that all full company names use commas to separate the
brand name from the incorporation prefix.



This property returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value if it
could not interrogate the target assembly for the requested information.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-ShortProductName'></a>
### ShortProductName `property`

##### Summary

Obtains the name of the application's product without the name of the
company.

##### Remarks

This is useful, e.g., for error messages.  Instead of, "
`MyCompany MyApp could not locate the file`," you can instead say, "
`MyApp could not locate the file`."



This property returns the value of the
[AssemblyProduct](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyProduct 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyProduct')
property
if the shortened form of the product name could not otherwise be determined.

<a name='P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-UseExecutingAssembly'></a>
### UseExecutingAssembly `property`

##### Summary

Gets or sets a value indicating whether the currently-executing assembly is to
be utilized for gathering information such as product name, company, version
etc.

##### Remarks

The default value of this property is `false`.

<a name='M-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-HasWhiteSpace-System-String-'></a>
### HasWhiteSpace(value) `method`

##### Summary

Determines if the specified [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') parameter,
`value`, is a string that is non-blank but also contains any
whitespace.

##### Returns

`true` if the specified `value`
contains any whitespace characters; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the value that is to be
checked for whitespace. |

<a name='T-xyLOGIX-Core-Assemblies-Info-AssemblyReferenceRequestedEventHandler'></a>
## AssemblyReferenceRequestedEventHandler `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info

##### Summary

Delegate that expresses the method signature for a handler of an
`AssemblyReferenceRequested` event.

##### Returns

If successful, a reference to an instance of
[Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that indicates which .NET assembly
is to be used for extracting metadata.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Assemblies.Info.AssemblyReferenceRequestedEventHandler](#T-T-xyLOGIX-Core-Assemblies-Info-AssemblyReferenceRequestedEventHandler 'T:xyLOGIX.Core.Assemblies.Info.AssemblyReferenceRequestedEventHandler') | (Required.) A [EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') that contains the event data. |

<a name='T-xyLOGIX-Core-Assemblies-Info-Find'></a>
## Find `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info

##### Summary

Exposes `static` methods to find information on assemblies
through
Reflection.

<a name='M-xyLOGIX-Core-Assemblies-Info-Find-AllAssembliesThatDependOn-System-Reflection-Assembly-'></a>
### AllAssembliesThatDependOn(executingAssembly) `method`

##### Summary

Attempts to obtain a collection of references to instances of
`executingAssembly` in the call stack that refer to the
specified `executingAssembly`.

##### Returns

If successful, a read-only collection of references to instances of
`executingAssembly` in the call stack that refer to the
specified `executingAssembly` is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| executingAssembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of the
currently-executing [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly'). |

##### Remarks

If there is an issue that is experienced

<a name='M-xyLOGIX-Core-Assemblies-Info-Find-DependsOn-System-Reflection-Assembly,System-Reflection-Assembly-'></a>
### DependsOn(currentAssembly,executingAssembly) `method`

##### Summary

Determines if the specified `executingAssembly` is
referred to by other assemblies in the current stack trace frame.

##### Returns

`true` if the specified
`currentAssembly` depends upon the
`executingAssembly`; `false` otherwise, or
if the relationship between the specified assemblies could not be determined.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| currentAssembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) A
[Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that is to be checked. |
| executingAssembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to the
currently-executing [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly'). |

##### Remarks

This method also returns `false` if information is
missing or a system error occurs during the operation.

<a name='T-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-Get'></a>
## Get `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info.AssemblyMetadata

<a name='T-xyLOGIX-Core-Assemblies-Info-Get'></a>
## Get `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info

##### Summary

Exposes `static` methods to obtain data from various
sources.

<a name='P-xyLOGIX-Core-Assemblies-Info-Get-AssemblyCompany'></a>
### AssemblyCompany `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyCompany]` attribute from the `AssemblyInfo.cs`
file of  the calling assembly.

<a name='P-xyLOGIX-Core-Assemblies-Info-Get-AssemblyProduct'></a>
### AssemblyProduct `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyProduct]` attribute from the `AssemblyInfo.cs`
file of  the calling assembly.

<a name='P-xyLOGIX-Core-Assemblies-Info-Get-AssemblyTitle'></a>
### AssemblyTitle `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value of the
`[assembly: AssemblyTitle]` attribute from the `AssemblyInfo.cs` file
of  the calling assembly.

<a name='M-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-Get-AssemblyToUse'></a>
### AssemblyToUse() `method`

##### Summary

Attempts to get the [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly')
instance that is to be used to gather attributes.

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

<a name='M-xyLOGIX-Core-Assemblies-Info-Get-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [Get](#T-xyLOGIX-Core-Assemblies-Info-Get 'xyLOGIX.Core.Assemblies.Info.Get') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='T-xyLOGIX-Core-Assemblies-Info-Properties-Resources'></a>
## Resources `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-xyLOGIX-Core-Assemblies-Info-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all resource lookups using this strongly typed resource class.

<a name='P-xyLOGIX-Core-Assemblies-Info-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='T-xyLOGIX-Core-Assemblies-Info-StackFrameExtensions'></a>
## StackFrameExtensions `type`

##### Namespace

xyLOGIX.Core.Assemblies.Info

##### Summary

Exposes extension methods for the
[StackFrame](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.StackFrame 'System.Diagnostics.StackFrame') class.

<a name='M-xyLOGIX-Core-Assemblies-Info-StackFrameExtensions-GetDeclaringAssembly-System-Diagnostics-StackFrame-'></a>
### GetDeclaringAssembly(frame) `method`

##### Summary

Attempts to obtain a reference to the
[Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') instance that represents the
assembly that contains the method that is at the current stack
`frame`.

##### Returns

If successful, a reference to the
[Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') instance that represents the
assembly that contains the method that is at the current stack
`frame`; `null` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| frame | [System.Diagnostics.StackFrame](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.StackFrame 'System.Diagnostics.StackFrame') | (Required.) Reference to an instance of the
[StackFrame](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.StackFrame 'System.Diagnostics.StackFrame') that represents the top of the
call stack. |
