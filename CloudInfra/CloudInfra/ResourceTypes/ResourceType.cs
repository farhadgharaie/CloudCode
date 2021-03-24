using System;
using System.Collections.Generic;
using System.Text;

namespace CloudInfra.ResourceTypes
{
   public  interface IResourceType
    {
        string VirtualMachine(OperatingSystem os,int HDD,int RAM, int CPU);
        string Database();
    }
    
}
