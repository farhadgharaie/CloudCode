using CloudInfra.ResourceTypes.Enum;

namespace CloudInfra.ResourceTypes.Database
{
    public class SQLResource : Database
    {
        private string _instance;
        private SqlCharset _charset;
        private string _collation;
        private string _userName;
        private string _password;
        public SQLResource(string instance,
                           SqlCharset charset,
                           string collation,
                           string userName,
                           string password)
        {
            _instance = instance;
            _charset = charset;
            _collation = collation;
            _userName = userName;
            _password = password;
        }
        public override DatabaseResource Build()
        {
            return new DatabaseResource
            {
                Collation = _collation,
                Charset = _charset.ToString(),
                Instance = _instance,
                UserName=_userName,
                Password=_password
            };
        }
    }
}
