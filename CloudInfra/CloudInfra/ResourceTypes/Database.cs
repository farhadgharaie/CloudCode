using CloudInfra.Common.FileManagement;
using CloudInfra.ResourceTypes.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudInfra.ResourceTypes
{
    public class DatabaseFacotry
    {
        private readonly IFileSystem _fileSystem;
        private string _infrastractureName;
        private string _providerPath = "";
        private string _fileExtention = ".json";
        public DatabaseFacotry(string InfrastractureName,
                              string ProviderPath,
                              IFileSystem fileSystem)
        {
            _infrastractureName = InfrastractureName;
            _providerPath = ProviderPath;
            _fileSystem = fileSystem;
        }
        public string SQL(string Instance,
                           SqlCharset Charset,
                           string Collation)
        {
            var sql = new SQLResource(Instance,
                                     Charset,
                                     Collation);
            var sqlAttributes= sql.Build();
            var filename=WriteFile(sqlAttributes,"SQL");
            return filename;
        }
        public string MySQL(string Instance,
                           MySqlCharset Charset,
                           string Collation)
        {
            var mySql = new MySQLResource(Instance,
                                     Charset,
                                     Collation);
            var mySqlAttributes= mySql.Build();
            var filename = WriteFile(mySqlAttributes,"MySQL");
            return filename;
        }
        
        private string WriteFile<T>(T objecttoSave,string databaseType)
            where T :class, new()
        {
            string resourceTypeName = @"\DB";
            string filePath =
                string.Concat(_providerPath,
                             @"\",
                             _infrastractureName,
                              resourceTypeName
                              );
            string fileName = string.Concat(_infrastractureName,
                               @"_",
                              databaseType,
                              _fileExtention);

            _fileSystem.WriteTextFile(objecttoSave,filePath, fileName);
            return fileName;
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
    public abstract class Database
    {
        public abstract DatabaseResource Build();
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
