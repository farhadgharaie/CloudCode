using System;
using System.Collections.Generic;
using System.Text;

namespace CloudInfra.ResourceTypes
{
   public class VirtualMachine
    {
        private int hardDiskSpace;
        private int rAM;
        private int cPU;
        public VirtualMachine(int HardDisk,int RAM,int CPU)
        {
            hardDiskSpace = HardDisk;
            rAM = RAM;
            cPU = CPU;
        }
        public VirtualMachineResource Create()
        {
            var res = new VirtualMachineResource()
            {
                CPU = cPU,
                HardDisk = hardDiskSpace,
                RAM = rAM
            };
            return res;
        }
    }
    public class VirtualMachineResource
    {
        public int CPU { get; set; }
        public int RAM { get; set; }
        public int HardDisk { get; set; }
    }
}

