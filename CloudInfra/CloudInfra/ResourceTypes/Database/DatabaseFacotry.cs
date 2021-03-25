using CloudInfra.Common.FileManagement;
using CloudInfra.ResourceTypes.Enum;

namespace CloudInfra.ResourceTypes.Database
{
    public class DatabaseFacotry
    {
        private readonly IFileManager _fileSystem;
        private string _infrastractureName;
        private string _providerPath = "";
        private string _fileExtention = ".json";
        public DatabaseFacotry(string InfrastractureName,
                              string ProviderPath,
                              IFileManager fileSystem)
        {
            _infrastractureName = InfrastractureName;
            _providerPath = ProviderPath;
            _fileSystem = fileSystem;
        }
        public string SQL(string instance,
                           SqlCharset charset,
                           string collation,
                           string userName,
                           string password)
        {
            var sql = new SQLResource(instance,
                                     charset,
                                     collation,
                                     userName,
                                     password);
            var sqlAttributes= sql.Build();
            var filename=WriteFile(sqlAttributes,"SQL");
            return filename;
        }
        public string MySQL(string instance,
                           MySqlCharset charset,
                           string collation,
                           string userName,
                           string password)
        {
            var mySql = new MySQLResource(instance,
                                         charset,
                                         collation,
                                         userName,
                                         password);
            var mySqlAttributes= mySql.Build();
            var filename = WriteFile(mySqlAttributes,"MySQL");
            return filename;
        }
        
        private string WriteFile<T>(T objecttoSave,string databaseType)
            where T :class, new()
        {
            string resourceTypeName = @"\Database";
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

            _fileSystem.WriteJsonFile(objecttoSave,filePath, fileName);
            return fileName;
        }
    }
}
