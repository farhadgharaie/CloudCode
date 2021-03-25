using CloudInfra.Providers;
using CloudInfra.ResourceTypes.VirtualMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudInfra.UnitTest
{
    [TestClass]
    public class ProviderUnitTest
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            var provider = new Provider("test");
            var infra = provider.CreateInfrastructure("UAT");
            infra.VirtualMachine(new Windows(ResourceTypes.Enum.WindowsVersion.Windows10), 20, 4, 4);
            infra.Database().SQL("", ResourceTypes.Enum.SqlCharset.utf8, ""); ;
        }
    }
}
