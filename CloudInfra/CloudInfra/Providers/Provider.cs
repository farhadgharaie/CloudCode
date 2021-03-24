using CloudInfra.Common.FileManagement;
using CloudInfra.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudInfra.Providers
{
   public  class Provider
    {
        private string _providerName;
        private string _providerPath = @"c:\";
        public Provider(string ProviderName)
        {
            _providerName = ProviderName;
        }
        public Infrastructure CreateInfrastructure(string InfrastructureName)
        {
           return  new Infrastructure(InfrastructureName,_providerPath+_providerName, new ManageFile());
        }
    }
}
