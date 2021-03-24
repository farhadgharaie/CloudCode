using CloudInfra.Common.FileManagement;
using CloudInfra.ResourceTypes;
using System.IO;
using OperatingSystem = CloudInfra.ResourceTypes.OperatingSystem;

namespace CloudInfra.Providers
{
    public class Infrastructure : IResourceType
    {
        private readonly IFileSystem _fileSystem;
        private string _infrastractureName;
        private string _providerPath = "";
        private string _fileExtention = ".json";
        public Infrastructure(string InfrastractureName,
                              string ProviderPath,
                              IFileSystem fileSystem)
        {
            _infrastractureName = InfrastractureName;
            _providerPath = ProviderPath;
            _fileSystem = fileSystem;
        }

        public DatabaseFacotry Database()
        {
            return new DatabaseFacotry(_infrastractureName, _providerPath,_fileSystem);
        }
        public string VirtualMachine(OperatingSystem os, int HDD, int RAM, int CPU)
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

            string fileContent = virtualMachineAttribute.ToString();
            WriteFile( filePath, fileName, fileContent);

            return fileName;
        }
        private void WriteFile( string filePAth, string fileName, string fileContent)
        {
            _fileSystem.WriteTextFile(filePAth, fileName, fileContent);
        }
    }
    
}
