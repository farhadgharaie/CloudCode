using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudInfra.Providers;
using CloudInfra.ResourceTypes.VirtualMachine;
using Moq;
using CloudInfra.Common.FileManagement;
using CloudInfra.ResourceTypes.Enum;
using CloudInfra.ResourceTypes.Database;

namespace CloudInfra.IntegrationTest.Provider
{
    [TestClass]
    public  class ProviderIntegrationTest
    {
        private const string _providerName = "test";

        [TestMethod]
        public void Provider_Should_Create_Windows_VirtualMachine_Infrastructure_Json_File()
        {
            //Arrang
            int cpu = 8;
            int ram = 4;
            int hdd = 40;
            WindowsVersion windowsVersion = WindowsVersion.WindowsServer2012;
            
            var expectedObject = new VirtualMachineResource
            {
                CPU = cpu,
                HardDisk = hdd,
                RAM = ram,
                OperatingSystem = windowsVersion.ToString()
            };

            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                .Verifiable();
            
            //Act
            var provider = new Providers.Provider(_providerName, fileSystemMock.Object);
            var infra = provider.CreateInfrastructure("UAT");
            infra.VirtualMachine(new Windows(windowsVersion),hdd,ram,cpu);

            //Assert
            fileSystemMock.Verify(mock => mock.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()), Times.Once());
            fileSystemMock.Verify(mock => mock.WriteJsonFile(expectedObject,
                                                 @"c:\test\UAT\VirtualMachine",
                                                 "UAT_Server.json"), Times.Once());
        }
        [TestMethod]
        public void Provider_Should_Create_Linux_VirtualMachine_Infrastructure_Json_File()
        {
            //Arrang
            int cpu = 8;
            int ram = 4;
            int hdd = 40;
            LinuxDistribution linuxDistribution = LinuxDistribution.Suse;
            
            var expectedObject = new VirtualMachineResource
            {
                CPU = cpu,
                HardDisk = hdd,
                RAM = ram,
                OperatingSystem = linuxDistribution.ToString()
            };

            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                .Verifiable();

            //Act
            var provider = new Providers.Provider(_providerName, fileSystemMock.Object);
            var infra = provider.CreateInfrastructure("UAT");
            infra.VirtualMachine(new Linux(linuxDistribution), hdd, ram, cpu);
            

            //Assert
            fileSystemMock.Verify(mock => mock.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()), Times.Once());
            fileSystemMock.Verify(mock => mock.WriteJsonFile(expectedObject,
                                                 @"c:\test\UAT\VirtualMachine",
                                                 "UAT_Server.json"), Times.Once());
        }
        [TestMethod]
        public void Provider_Should_Create_SQL_Database_Infrastructure_Json_File()
        {
            //Arrang
            string instance = "example";
            SqlCharset charset = SqlCharset.utf32;
            string collation = "collation1";
            string userName = "user1";
            string password = "1234";
            var expectedObject = new DatabaseResource
            {
                Instance = instance,
                Collation = collation,
                Charset = charset.ToString(),
                UserName = userName,
                Password = password
            };

            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                .Verifiable();


            //Act
            var provider = new Providers.Provider(_providerName, fileSystemMock.Object);
            var infra = provider.CreateInfrastructure("UAT");
            infra.Database().SQL(instance, charset, collation, userName, password); ;

            //Assert
            fileSystemMock.Verify(mock => mock.WriteJsonFile(expectedObject,
                                                 @"c:\test\UAT\Database",
                                                 "UAT_SQL.json"), Times.Once());
        }
        [TestMethod]
        public void Provider_Should_Create_MySQL_Database_Infrastructure_Json_File()
        {
            //Arrang
            string instance = "example";
            MySqlCharset charset = MySqlCharset.utf32;
            string collation = "collation1";
            string userName = "user1";
            string password = "1234";
            var expectedObject = new DatabaseResource
            {
                Instance = instance,
                Collation = collation,
                Charset = charset.ToString(),
                UserName = userName,
                Password = password
            };

            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                .Verifiable();


            //Act
            var provider = new Providers.Provider(_providerName, fileSystemMock.Object);
            var infra = provider.CreateInfrastructure("UAT");
            infra.Database().MySQL(instance, charset, collation, userName, password); ;

            //Assert
            fileSystemMock.Verify(mock => mock.WriteJsonFile(expectedObject,
                                                 @"c:\test\UAT\Database",
                                                 "UAT_MySQL.json"), Times.Once());
        }
        [TestMethod]
        public void Provider_Should_Delete_Infrastructure()
        {

            //Arrang
            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.DeleteDirectory(It.IsAny<string>()))
                          .Verifiable();
            
            //Act
            var provider = new Providers.Provider(_providerName, fileSystemMock.Object);
            provider.DeleteInfrastructure("UAT");

            //Assert
            fileSystemMock.Verify(mock => mock.DeleteDirectory(@"c:\\test\\UAT"), Times.Once());
        }
    }
}
