using CloudInfra.Common.FileManagement;
using CloudInfra.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudInfra.Providers
{
    public interface IProvider
    {
        void setRootPath(string rootPath);
        void setName(string providerName);


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

        public void setName(string providerName)
        {
            _providerName = providerName;
        }

        public void setRootPath(string rootPath)
        {
            _providerPath = rootPath;
        }
    }
}
