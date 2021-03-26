using CloudInfra.Common.FileManagement;
using CloudInfra.Common.Json;
using CloudInfra.ResourceTypes.Database;
using CloudInfra.ResourceTypes.VirtualMachine;

namespace CloudInfra.Providers
{
    public class Infrastructure : IInfrastructure
    {
        private readonly IFileManager _fileManager;
        private string _infrastractureName;
        private string _providerPath = "";
        private string _fileExtention = ".json";
        private JsonSerializer _jsonData = new JsonSerializer();
        public Infrastructure(string InfrastractureName,
                              string ProviderPath,
                              IFileManager fileManager)
        {
            _infrastractureName = InfrastractureName;
            _providerPath = ProviderPath;
            _fileManager = fileManager;
        }

        public virtual DatabaseFactory Database()
        {
            return new DatabaseFactory(_infrastractureName, _providerPath,_fileManager);
        }
        public virtual string VirtualMachine(OperatingSystem os, int HDD, int RAM, int CPU)
        {
            string resourceTypeName = @"\VirtualMachine";
            string filePath =
                string.Concat(_providerPath,
                             @"\",
                             _infrastractureName,
                              resourceTypeName
                              );
            string fileName = string.Concat(_infrastractureName,
                              "_Server",
                              _fileExtention);
            var vm = new VirtualMachine(os, HDD, RAM, CPU);
            var virtualMachineAttribute = vm.Build();
            _fileManager.WriteJsonFile(virtualMachineAttribute,
                                    filePath, fileName);

            return fileName;
        }
        public void Delete()
        {
            string infrastructurePath = string.Concat(_providerPath,@"\", _infrastractureName);
            
            var directories = _fileManager.GetAllDirectory(infrastructurePath);
            
            foreach (var dir in directories)
            {
                var files = _fileManager.GetAllFile(dir);
                foreach (var file in files)
                {
                    _fileManager.DeleteFile(file);
                }
                _fileManager.DeleteDirectory(dir);
            }
            _fileManager.DeleteDirectory(infrastructurePath);
        }
    }
}
