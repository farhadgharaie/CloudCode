using CloudInfra.ResourceTypes.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudInfra.ResourceTypes
{
    
    public class Database
    {
        public DatabaseResource SQL(string Instance,
                           SqlCharset Charset,
                           string Collation)
        {
           var sql= new SQLResource(Instance,
                                    Charset,
                                    Collation);
            return sql.Build();
        }
        public DatabaseResource MySQL(string Instance,
                           MySqlCharset Charset,
                           string Collation)
        {
            var sql = new MySQLResource(Instance,
                                     Charset,
                                     Collation);
            return sql.Build();
        }
    }
    public class DatabaseResource
    {
        public string Instance { get; set; }
        public string Charset { get; set; }
        public string Collation { get; set; }
        public override bool Equals(Object obj)
        {
            if (obj is DatabaseResource)
            {
                var that = obj as DatabaseResource;
                return this.Instance == that.Instance &&
                       this.Charset == that.Charset &&
                       this.Collation == that.Collation;
            }
            return false;
        }
    }
   public abstract class DatabaseFactory
    {
        public abstract DatabaseResource Build();
    }
    public class SQLResource : DatabaseFactory
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
                Collation=collation,
                Charset=charset.ToString(),
                Instance=instance
            };
        }
    }
    public class MySQLResource : DatabaseFactory
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
