using System;

namespace CloudInfra.ResourceTypes.VirtualMachine
{
    public class VirtualMachineResource
    {
        public int CPU { get; set; }
        public int RAM { get; set; }
        public int HardDisk { get; set; }
        public string OperatingSystem { get; set; }
        public override bool Equals(Object obj)
        {
            if (obj is VirtualMachineResource)
            {
                var that = obj as VirtualMachineResource;
                return this.CPU == that.CPU &&
                       this.RAM == that.RAM &&
                       this.HardDisk == that.HardDisk &&
                       this.OperatingSystem==that.OperatingSystem;
            }
            return false;
        }
    }
}

