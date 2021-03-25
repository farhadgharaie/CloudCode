using CloudInfra.ResourceTypes.Enum;

namespace CloudInfra.ResourceTypes.Database
{
    public class MySQLResource : Database
    {
        private string instance;
        private MySqlCharset charset;
        private string collation;
        public MySQLResource(string Instance,
                           MySqlCharset Charset,
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
