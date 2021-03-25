using CloudInfra.ResourceTypes.Database;
using CloudInfra.ResourceTypes.VirtualMachine;

namespace CloudInfra.ResourceTypes
{
   public  interface IResourceType
    {
        string VirtualMachine(OperatingSystem os,int HDD,int RAM, int CPU);
        DatabaseFacotry Database();
    }
    
}
