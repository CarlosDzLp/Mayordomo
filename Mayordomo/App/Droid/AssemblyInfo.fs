namespace Mayordomo.Droid

open System.Reflection
open System.Runtime.CompilerServices

// the name of the type here needs to match the name inside the ResourceDesigner attribute
type Resources = Mayordomo.Droid.Resource

[<assembly:Android.Runtime.ResourceDesigner("Mayordomo.Droid.Resources", IsApplication = true)>]
[<assembly:AssemblyTitle("Mayordomo.Droid")>]
[<assembly:AssemblyDescription("")>]
[<assembly:AssemblyConfiguration("")>]
[<assembly:AssemblyCompany("")>]
[<assembly:AssemblyProduct("")>]
[<assembly:AssemblyCopyright("${AuthorCopyright}")>]
[<assembly:AssemblyTrademark("")>]
[<assembly:AssemblyVersion("1.0.0.0")>]

//[<assembly: AssemblyDelaySign(false)>]
//[<assembly: AssemblyKeyFile("")>]

()
