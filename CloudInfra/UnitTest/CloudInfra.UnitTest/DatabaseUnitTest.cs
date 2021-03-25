using CloudInfra.ResourceTypes.Database;
using CloudInfra.ResourceTypes.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudInfra.UnitTest
{
    [TestClass]
    public class DatabaseUnitTest
    {
        [TestMethod]
        public void SQLResource_Returen_Right_DatabaseResource()
        {
            //Arrang 
            string instance = "example";
            SqlCharset charset = SqlCharset.utf32;
            string collation = "collation1";
            var db = new SQLResource(instance,charset,collation);

            var expected = new DatabaseResource
            {
                Instance = "example",
                Collation = "collation1",
                Charset = "utf32"
            };

            //Act
            var actual=db.Build();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MySQLResource_Returen_Right_DatabaseResource()
        {
            //Arrang 
            string instance = "example";
            MySqlCharset charset = MySqlCharset.utf8;
            string collation = "collation1";
            var db = new MySQLResource(instance, charset, collation);

            var expected = new DatabaseResource
            {
                Instance = "example",
                Collation = "collation1",
                Charset = "utf8"
            };

            //Act
            var actual = db.Build();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
