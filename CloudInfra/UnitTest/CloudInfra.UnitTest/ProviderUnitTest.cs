using CloudInfra.Providers;
using CloudInfra.ResourceTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CloudInfra.UnitTest
{
    [TestClass]
    public class ProviderUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var provider = new Provider("test");
            var infra=provider.CreateInfrastructure("UAT");
            
        }
    }
}
