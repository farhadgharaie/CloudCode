using CloudInfra.Providers;
using CloudInfra.ResourceTypes.VirtualMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudInfra.UnitTest
{
    [TestClass]
    public class ProviderUnitTest
    {
        
        [TestMethod]
        public void Create_Infrastructure()
        {
            var provider = new Provider("test");
            var infra = provider.CreateInfrastructure("UAT");
            infra.VirtualMachine(new Windows(ResourceTypes.Enum.WindowsVersion.Windows10), 20, 4, 4);
            infra.VirtualMachine(new Windows(ResourceTypes.Enum.WindowsVersion.WindowsServer2008), 20, 4, 4);
            infra.VirtualMachine(new Linux(ResourceTypes.Enum.LinuxDistribution.Debian), 20, 4, 4);
            infra.Database().SQL("", ResourceTypes.Enum.SqlCharset.utf8, "","",""); ;
            infra.Database().MySQL("", ResourceTypes.Enum.MySqlCharset.utf8, "","",""); ;
        }
        [TestMethod]
        public void Delete_Infrastructure()
        {
            var provider = new Provider("test");
            provider.DeleteInfrastructure("UAT");
        }

    }
}
