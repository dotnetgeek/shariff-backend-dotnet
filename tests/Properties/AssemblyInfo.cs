﻿using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Shariff.Backend.Tests")]
[assembly: AssemblyTrademark("")]
//because of https://github.com/tmenier/Flurl/issues/67 
[assembly: CollectionBehavior(MaxParallelThreads = 1)]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("11a49103-40d5-4aea-821d-0e6ff4083c9c")]
