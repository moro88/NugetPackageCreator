﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NugetTest.CsprojFileFinder.PackagesFinder;

namespace NugetCreatorTest
{
    [TestClass]
    public class PackagesFinderTest
    {
        private IEnumerable<Cl_Package> GetPackages()
        {
            Cl_PackagesFinder vrlPackagesFinder = new Cl_PackagesFinder();
            return vrlPackagesFinder.GetPackages(new TextGetter().GetCsprojText());
        }

        [TestMethod]
        public void Check_Packages_Quantity()
        {
            IEnumerable<Cl_Package> vrlPackages = GetPackages();

            Assert.AreEqual(4, vrlPackages.Count());
        }

        [TestMethod]
        public void Check_Package_FluentMigrator()
        {
            IEnumerable<Cl_Package> vrlPackages = GetPackages();

            Assert.IsTrue(vrlPackages.Any(p => p.Name == "FluentMigrator"));
        }

        [TestMethod]
        public void Check_Package_FluentMigratorRunner()
        {
            IEnumerable<Cl_Package> vrlPackages = GetPackages();

            Assert.IsTrue(vrlPackages.Any(p => p.Name == "FluentMigrator.Runner"));
        }

        [TestMethod]
        public void Check_Package_NLog()
        {
            IEnumerable<Cl_Package> vrlPackages = GetPackages();

            Assert.IsTrue(vrlPackages.Any(p => p.Name == "NLog"));
        }

        [TestMethod]
        public void Check_Package_ApplicationFrameSystemInterfaces()
        {
            IEnumerable<Cl_Package> vrlPackages = GetPackages();

            Assert.IsTrue(vrlPackages.Any(p => p.Name == "ApplicationFrameSystemInterfaces"));
        }
    }
}