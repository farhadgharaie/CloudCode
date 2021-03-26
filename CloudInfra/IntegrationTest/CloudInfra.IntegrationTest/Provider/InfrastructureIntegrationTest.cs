using CloudInfra.Common.FileManagement;
using CloudInfra.Providers;
using CloudInfra.ResourceTypes.Database;
using CloudInfra.ResourceTypes.Enum;
using CloudInfra.ResourceTypes.VirtualMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace CloudInfra.IntegrationTest.Provider
{
    [TestClass]
    public class InfrastructureIntegrationTest
    {
        [TestMethod]
        public void VirtualMachine_Should_Set_Windows_VirtualMachineResource_Correctly()
        {
            //Arrang
            int cpu = 8;
            int ram = 4;
            int hdd = 40;
            WindowsVersion windowsVersion = WindowsVersion.WindowsServer2012;
            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                          .Verifiable();
            string providerPath = @"D:\IGS";
            var expected = @"UAT_Server.json";

            //Act
            var actual = new Infrastructure("UAT", providerPath, fileSystemMock.Object)
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
            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
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
        [TestMethod]
        public void Database_Should_Set_SQL_DatabaseResource_Correctly()
        {
            //Arrang
            string instance = "example";
            SqlCharset charset = SqlCharset.utf32;
            string collation = "collation1";
            string userName = "user1";
            string password = "2345";

            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                          .Verifiable();
            string providerPath = @"D:\IGS";
            var expected = @"UAT_SQL.json";

            //Act
            var actual = new Infrastructure("UAT", providerPath, fileSystemMock.Object)
                        .Database().SQL(instance, charset, collation,userName,password);


            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Database_Should_Set_MySQL_DatabaseResource_Correctly()
        {
            //Arrang
            string instance = "example";
            MySqlCharset charset = MySqlCharset.utf8;
            string collation = "collation1";
            string userName = "user1";
            string password = "2345";

            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                          .Verifiable();
            string providerPath = @"D:\IGS";
            var expected = @"UAT_MySQL.json";

            //Act
            var actual = new Infrastructure("UAT", providerPath, fileSystemMock.Object)
                        .Database().MySQL(instance, charset, collation,userName,password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_Should_Remove_All_Infrastructure_ResourceType()
        {
            //Arrang
            string[] directoriesPath = new string[] { @"IGS\UAT\VM",
                                                      @"IGS\UAT\DB" };
            string[] filesPath = new string[] { @"IGS\UAT\VM\UAT_Server1.json",
                                                @"IGS\UAT\VM\UAT_Server2.json" };

            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.GetAllDirectory(It.IsAny<string>()))
                          .Returns(directoriesPath);
            fileSystemMock.Setup(w => w.GetAllFile(@"IGS\UAT\VM"))
                          .Returns(filesPath);

            string providerPath = @"IGS";

            //Act
            new Infrastructure("UAT", providerPath, fileSystemMock.Object)
                       .Delete();


            //Assert
            fileSystemMock.Verify(mock => mock.DeleteDirectory(@"IGS\UAT"), Times.Once());
            fileSystemMock.Verify(mock => mock.DeleteDirectory(@"IGS\UAT\VM"), Times.Once());
            fileSystemMock.Verify(mock => mock.DeleteDirectory(@"IGS\UAT\DB"), Times.Once());
            fileSystemMock.Verify(mock => mock.DeleteFile(It.IsAny<string>()), Times.Exactly(2));

        }
    }
}
