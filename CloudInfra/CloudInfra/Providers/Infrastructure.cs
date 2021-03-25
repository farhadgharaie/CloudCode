using CloudInfra.Common.FileManagement;
using CloudInfra.Common.Json;
using CloudInfra.ResourceTypes;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using OperatingSystem = CloudInfra.ResourceTypes.OperatingSystem;

namespace CloudInfra.Providers
{
    public class Infrastructure : IResourceType
    {
        private readonly IFileSystem _fileSystem;
        private string _infrastractureName;
        private string _providerPath = "";
        private string _fileExtention = ".json";
        private JsonSerializer _jsonData = new JsonSerializer();
        public Infrastructure(string InfrastractureName,
                              string ProviderPath,
                              IFileSystem fileSystem)
        {
            _infrastractureName = InfrastractureName;
            _providerPath = ProviderPath;
            _fileSystem = fileSystem;
        }

        public virtual DatabaseFacotry Database()
        {
            return new DatabaseFacotry(_infrastractureName, _providerPath,_fileSystem);
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
            _fileSystem.WriteTextFile(virtualMachineAttribute,
                                    filePath, fileName);

            return fileName;
        }
        public void Delete()
        {
            string infrastructurePath = string.Concat(_providerPath,@"\", _infrastractureName);
            
            var directories = _fileSystem.GetAllDirectory(infrastructurePath);
            
            foreach (var dir in directories)
            {
                var files = _fileSystem.GetAllFile(dir);
                foreach (var file in files)
                {
                    _fileSystem.DeleteFile(file);
                }
                _fileSystem.DeleteDirectory(dir);
            }
            _fileSystem.DeleteDirectory(infrastructurePath);
        }
    }
}
