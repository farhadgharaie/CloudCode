using CloudInfra.ResourceTypes.Enum;
using System;
using System.Runtime.Serialization;

namespace CloudInfra.ResourceTypes
{
    public class VirtualMachine
    {
        private int _hardDiskSpace;
        private int _rAM;
        private int _cPU;
        private OperatingSystem _operatingSystem;
        public VirtualMachine()
        {

        }
        public VirtualMachine(OperatingSystem operatingSystem,
                              int HardDisk, int RAM, int CPU)
        {
            _hardDiskSpace = HardDisk;
            _rAM = RAM;
            _cPU = CPU;
            _operatingSystem = operatingSystem;
        }
        public VirtualMachineResource Build()
        {
            var res = new VirtualMachineResource()
            {
                CPU = _cPU,
                HardDisk = _hardDiskSpace,
                RAM = _rAM,
                OperatingSystem=_operatingSystem.Build()
            };
            return res;
        }
        public void Delete()
        {

        }
    }
    public abstract class OperatingSystem
    {
        public abstract string Build();
    }
    
    public class Windows : OperatingSystem
    {
        private WindowsVersion _version;
        public Windows(WindowsVersion version)
        {
            _version = version;
        }
        public override string Build()
        {
            return _version.ToString();
        }
    }
   
    public class Linux : OperatingSystem
    {
        private LinuxDistribution _distribution;
        public Linux(LinuxDistribution distribution)
        {
            _distribution = distribution;
        }
        public override string Build()
        {
            return _distribution.ToString();
        }
    }

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

