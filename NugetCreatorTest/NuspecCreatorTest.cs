﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NugetTest.NuspecCreator.CsprojFileFinder;
using NugetTest.NuspecCreator.FileTextLoader;
using NugetTest.NuspecCreator.NuspecXmlCreator;

namespace NugetCreatorTest
{
    [TestClass]
    public class NuspecCreatorTest
    {
        private Cl_NuspecProjectInfo CreateNuspecProjectInfo()
        {
            var vrlProjectInfo = new Cl_NuspecProjectInfo();

            vrlProjectInfo.ApplicationId = "inSolutions.Utilities";
            vrlProjectInfo.NugetVersion = "1.0.1.8";
            vrlProjectInfo.FileVersion = "2.0.1.8";
            vrlProjectInfo.Authors = "Arkadiusz Neuman";
            vrlProjectInfo.Description = "Szkielet Aplikacji dla programów firmy inSolutions.";
            vrlProjectInfo.Title = "Szkielet Aplikacji - Utilities";
            
            List<Cl_ProjectInfo> vrlProjectReferences = new List<Cl_ProjectInfo>();
            vrlProjectReferences.Add(new Cl_ProjectInfo("ApplicationFrameSystemInterfaces", "3.0.1.8"));

            List<Cl_ProjectInfo> vrlProjectPackages = new List<Cl_ProjectInfo>();
            vrlProjectPackages.Add(new Cl_ProjectInfo("NLog", "3.2.0.0"));
            vrlProjectPackages.Add(new Cl_ProjectInfo("FluentMigrator", "1.4.0.0"));
            vrlProjectPackages.Add(new Cl_ProjectInfo("FluentMigrator.Runner", "1.4.0.0"));

            vrlProjectInfo.AddionalPackages = vrlProjectPackages;
            vrlProjectInfo.ProjectReferences = vrlProjectReferences;

            return vrlProjectInfo;
        }

        private string GetValidNuspec()
        {
            return new Cl_FileTextLoader().GetTextFromFile(Path.Combine(Directory.GetCurrentDirectory(), "ExampleNuspecFile.xml"));
        }

        [TestMethod]
        public void Check_Is_Nuspec_Valid()
        {
            Cl_NuspecProjectInfo vrlNuspecProjectInfo = CreateNuspecProjectInfo();
            string vrlValidNuspec = GetValidNuspec();

            string vrlNuspecText = new Cl_NuspecXmlCreator().CreateNuspecText(vrlNuspecProjectInfo);

            Assert.AreEqual(ExceptBlanks(vrlValidNuspec), ExceptBlanks(vrlNuspecText));
        }

        private string ExceptBlanks(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (!char.IsWhiteSpace(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}