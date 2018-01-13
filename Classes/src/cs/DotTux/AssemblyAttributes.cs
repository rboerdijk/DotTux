using System.Reflection;
using System.Configuration.Assemblies;

[assembly:AssemblyVersion("1.1.0.0")]
[assembly:AssemblyFlags(0x0020)] // AssemblyVersionCompatibility.SameProcess

[assembly:AssemblyCompany("OTP Systems Oy")]
[assembly:AssemblyCopyright("Copyright 2004 OTP Systems Oy")]

#if WSCLIENT // DotTux Workstation

[assembly:AssemblyProduct("DotTuxWS-1.1.0")]
[assembly:AssemblyTitle("DotTux Workstation")]
[assembly:AssemblyDescription("Tuxedo/WS API for the .NET CLR")]
#if APIDOC // Skip AssemblyKeyFile
#else
[assembly:AssemblyKeyFile("DotTuxWS.snk")]
#endif

#else // DotTux

[assembly:AssemblyProduct("DotTux-1.1.0")]
[assembly:AssemblyTitle("DotTux")]
[assembly:AssemblyDescription("Tuxedo API for the .NET CLR")]
#if APIDOC // Skip AssemblyKeyFile
#else
[assembly:AssemblyKeyFile("DotTux.snk")]
#endif

#endif
