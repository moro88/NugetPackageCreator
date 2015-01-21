﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NugetTest.CsprojFileFinder.ProjectReferences
{
    public class Cl_ProjectReferencesFinder
    {
        public IEnumerable<Cl_ProjectInfo> GetProjectReferences(string vrpCsprojText)
        {
            XElement vrlRoot = XElement.Load(new StringReader(vrpCsprojText));
            foreach (var vrlProjectReference in vrlRoot.Elements().Where(el => el.Name.LocalName == "ItemGroup").SelectMany(e => e.Elements()).Where(r => r.Name.LocalName == "ProjectReference"))
            {
                yield return new Cl_ProjectInfo(vrlProjectReference.Elements().Single(e => e.Name.LocalName == "Name").Value);
            }
        }
    }
}