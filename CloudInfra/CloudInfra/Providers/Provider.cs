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
        public Provider(string ProviderName)
        {
            _providerName = ProviderName;
        }
        public virtual Infrastructure CreateInfrastructure(string InfrastructureName)
        {
           return  new Infrastructure(InfrastructureName,_providerPath+_providerName,
                                      new FileManager());
        }
        public virtual void DeleteInfrastructure(string InfrastructureName)
        {
            var infra = new Infrastructure(InfrastructureName, _providerPath + _providerName,
                                       new FileManager());
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
