using CloudInfra.Common.FileManagement;
using CloudInfra.ResourceTypes.Enum;

namespace CloudInfra.ResourceTypes.Database
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

            _fileSystem.WriteJsonFile(objecttoSave,filePath, fileName);
            return fileName;
        }
    }
}
