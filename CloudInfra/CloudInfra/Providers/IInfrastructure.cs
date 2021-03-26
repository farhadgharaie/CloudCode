using CloudInfra.ResourceTypes.Database;
using CloudInfra.ResourceTypes.VirtualMachine;

namespace CloudInfra.Providers
{
   public  interface IInfrastructure
    {
        string VirtualMachine(OperatingSystem os,int HDD,int RAM, int CPU);
        DatabaseFactory Database();
        void Delete();
    }
    
}
