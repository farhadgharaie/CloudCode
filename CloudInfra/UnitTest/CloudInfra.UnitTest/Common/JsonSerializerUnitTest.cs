using CloudInfra.Common.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudInfra.UnitTest.Common
{
    [TestClass]
    public class JsonSerializerUnitTest
    {
        private ISerializer jsonSerializer;
        public JsonSerializerUnitTest()
        {
            jsonSerializer = new JsonSerializer();
        }

        [TestMethod]
        public void SerializeEnumValueTest()
        {
            Sample sampleEntity = new Sample
            {
                Name="Farhad",
                Family="Gharaie"
            };

            string expectedJsonData = "{\"Family\":\"Gharaie\",\"Name\":\"Farhad\"}";
            string actualJsonData = jsonSerializer.Serialize<Sample>(sampleEntity);

            Assert.AreEqual(expectedJsonData, actualJsonData);
        }
        [TestMethod]
        public void DeserializeEnumValueTest()
        {
            string jsonData = "{\"Name\":\"Farhad\",\"Family\":\"Gharaie\"}";

            Sample expectedSampleEntity = new Sample
            {
                Name = "Farhad",
                Family = "Gharaie"
            };

            Sample actualSampleEntity = jsonSerializer.Deserialize<Sample>(jsonData);

            Assert.AreEqual(expectedSampleEntity.Name, actualSampleEntity.Name);
            Assert.AreEqual(expectedSampleEntity.Family, actualSampleEntity.Family);
        }
    }
    public class Sample
    {
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
