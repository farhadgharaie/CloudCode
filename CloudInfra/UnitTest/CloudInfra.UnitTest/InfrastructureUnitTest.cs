using CloudInfra.Common.FileManagement;
using CloudInfra.Providers;
using CloudInfra.ResourceTypes;
using CloudInfra.ResourceTypes.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CloudInfra.UnitTest
{
    [TestClass]
    public class InfrastructureUnitTest
    {
        [TestMethod]
        public void VirtualMachine_Should_Set_Windows_VirtualMachineResource_Correctly()
        {
            //Arrang
            int cpu = 8;
            int ram = 4;
            int hdd = 40;
            WindowsVersion windowsVersion = WindowsVersion.WindowsServer2012;
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(w => w.WriteTextFile(It.IsAny<string>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                          .Verifiable();
            string providerPath = @"D:\IGS";
            var expected = @"UAT_Server.json";

            //Act
            var actual = new Infrastructure("UAT", providerPath,fileSystemMock.Object)
                        .VirtualMachine(new Windows(windowsVersion), hdd, ram, cpu);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void VirtualMachine_Should_Set_Linux_VirtualMachineResource_Correctly()
        {
            //Arrang
            int cpu = 8;
            int ram = 4;
            int hdd = 40;
            LinuxDistribution LinuxDist = LinuxDistribution.Debian;
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(w => w.WriteTextFile(It.IsAny<string>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                          .Verifiable();
            string providerPath = @"D:\IGS";
            var expected = @"UAT_Server.json";

            //Act
            var actual = new Infrastructure("UAT", providerPath, fileSystemMock.Object)
                        .VirtualMachine(new Linux(LinuxDist), hdd, ram, cpu);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
