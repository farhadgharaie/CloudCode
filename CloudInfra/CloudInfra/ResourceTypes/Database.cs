using System;
using System.Collections.Generic;
using System.Text;

namespace CloudInfra.ResourceTypes
{
    public enum MySqlCharset
    {
         utf8,
         uft32
    }
    public enum SqlCharset
    {
        utf8,
        uft32
    }
    public class DatabaseResource
    {
        public string Instance { get; set; }
        public string Charset { get; set; }
        public string Collation { get; set; }
    }
   public abstract class Database
    {
        public abstract DatabaseResource Create();
    }
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
        public override DatabaseResource Create()
        {
            return new DatabaseResource
            {
                Collation=collation,
                Charset=charset.ToString(),
                Instance=instance
            };
        }
    }
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
        public override DatabaseResource Create()
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
