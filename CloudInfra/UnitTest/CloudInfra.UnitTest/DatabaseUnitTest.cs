using CloudInfra.ResourceTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            SqlCharset charset = SqlCharset.uft32;
            string collation = "collation1";
            var db = new SQLResource(instance,charset,collation);

            var expected = new DatabaseResource
            {
                Instance = "example",
                Collation = "collation1",
                Charset = "utf32"
            };

            //Act
            var actual=db.Create();

            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod]
        public void MySQLResource_Returen_Right_DatabaseResource()
        {
            //Arrang 
            string instance = "example";
            MySqlCharset charset = MySqlCharset.uft32;
            string collation = "collation1";
            var db = new MySQLResource(instance, charset, collation);

            var expected = new DatabaseResource
            {
                Instance = "example",
                Collation = "collation1",
                Charset = "utf32"
            };

            //Act
            var actual = db.Create();

            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
