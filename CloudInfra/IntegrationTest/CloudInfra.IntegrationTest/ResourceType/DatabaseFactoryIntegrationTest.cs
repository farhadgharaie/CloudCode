using CloudInfra.Common.FileManagement;
using CloudInfra.ResourceTypes.Database;
using CloudInfra.ResourceTypes.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CloudInfra.IntegrationTest.ResourceType
{
    [TestClass]
    public class DatabaseFactoryIntegrationTest
    {
        [TestMethod]
        public void SQL_Factory_Should_Save_SQL_Attributes()
        {
            //Arrang

            string _infrastructureName = "Test";
            string _providerPath = "path";
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
            string subPath = string.Concat(_providerPath, @"\", _infrastructureName, @"\", "Database");
            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                .Verifiable();


            //Act
             new DatabaseFactory(_infrastructureName, _providerPath, fileSystemMock.Object)
                            .SQL(instance, charset, collation, userName, password); ;


            //Assert
            fileSystemMock
                .Verify(mock => mock.WriteJsonFile(expectedObject,
                                                             subPath,
                                                             "Test_SQL.json"),
                                                   Times.Once());
        }
        [TestMethod]
        public void MySQL_Factory_Should_Save_SQL_Attributes()
        {
            //Arrang

            string _infrastructureName = "Test";
            string _providerPath = "path";
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
            string subPath = string.Concat(_providerPath, @"\", _infrastructureName, @"\", "Database");
            var fileSystemMock = new Mock<IFileManager>();
            fileSystemMock.Setup(w => w.WriteJsonFile(It.IsAny<object>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<string>()))
                .Verifiable();


            //Act
            new DatabaseFactory(_infrastructureName, _providerPath, fileSystemMock.Object)
                           .MySQL(instance, charset, collation, userName, password); ;


            //Assert
            fileSystemMock
                .Verify(mock => mock.WriteJsonFile(expectedObject,
                                                             subPath,
                                                             "Test_MySQL.json"),
                                                   Times.Once());
        }
    }
}
