using CloudInfra.ResourceTypes.Enum;

namespace CloudInfra.ResourceTypes.Database
{
    public class SQLResource : Database
    {
        private string instance;
        private SqlCharset charset;
        private string collation;
        public SQLResource(string Instance,
                           SqlCharset Charset,
                           string Collation)
        {
            instance = Instance;
            charset = Charset;
            collation = Collation;
        }
        public override DatabaseResource Build()
        {
            return new DatabaseResource
            {
                Collation = collation,
                Charset = charset.ToString(),
                Instance = instance
            };
        }
    }
}
