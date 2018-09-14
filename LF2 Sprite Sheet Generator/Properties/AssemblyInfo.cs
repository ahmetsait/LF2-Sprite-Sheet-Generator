using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("LF2 Sprite Sheet Generator")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Ahmet Sait Koçak")]
[assembly: AssemblyProduct("LF2 Sprite Sheet Generator")]
[assembly: AssemblyCopyright("Copyright © Ahmet Sait Koçak 2018")]
[assembly: AssemblyTrademark("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("88f385c0-637c-4608-8225-4dc3a67fec07")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(Info.version + ".*")]
[assembly: AssemblyFileVersion(Info.version)]
[assembly: AssemblyInformationalVersion("v" + Info.version)]

internal static class Info
{
	public const string version = "0.1.0";
}
