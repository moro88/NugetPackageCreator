﻿using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NugetTest.NuspecCreator.CsprojFileFinder.AssemblyNameFinder
{
    public class Cl_AssemblyNameFinder : I_AssemblyNameFinder
    {
        public string GetAssemblyName(string vrpCsprojText)
        {
            XElement vrlRoot = XElement.Load(new StringReader(vrpCsprojText));
            return vrlRoot.Elements().First(el => el.Name.LocalName == "PropertyGroup").Elements().Single(el => el.Name.LocalName == "AssemblyName").Value;
        }
    }
}