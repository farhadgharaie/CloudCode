using CloudInfra.Common.FileManagement;

namespace CloudInfra.Providers
{
    public interface IProvider
    {
        void setRootPath(string rootPath);
        string GetName();
        Infrastructure CreateInfrastructure(string InfrastructureName);
        void DeleteInfrastructure(string InfrastructureName);
    }
   public  class Provider : IProvider
    {
        private string _providerName;
        private string _providerPath = @"c:\";
        private readonly IFileManager _fileManager;
        public Provider(string ProviderName,
                        IFileManager fileManager=null)
        {
            _providerName = ProviderName;
            _fileManager = fileManager is null ? new FileManager() : fileManager;
        }
        public virtual Infrastructure CreateInfrastructure(string InfrastructureName)
        {
           return  new Infrastructure(InfrastructureName,_providerPath+_providerName,
                                      _fileManager);
        }
        public virtual void DeleteInfrastructure(string InfrastructureName)
        {
            var infra = new Infrastructure(InfrastructureName, _providerPath + _providerName,
                                           _fileManager);
            infra.Delete();
        }

        public virtual string GetName()
        {
            return _providerName ;
        }

        public virtual void setRootPath(string rootPath)
        {
            _providerPath = rootPath;
        }
    }
}
