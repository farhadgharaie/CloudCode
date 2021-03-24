using CloudInfra.ResourceTypes.Enum;
using System;

namespace CloudInfra.ResourceTypes
{
    public class VirtualMachine
    {
        private int _hardDiskSpace;
        private int _rAM;
        private int _cPU;
        private OperatingSystem _operatingSystem;
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
    }
    public abstract class OperatingSystem
    {
        public abstract object Build();
    }
    public class WindowsAttribute
    {
        public string Version { get; set; }
        public override bool Equals(Object obj)
        {
            if (obj is WindowsAttribute)
            {
                var that = obj as WindowsAttribute;
                return this.Version == that.Version;
            }
            return false;
        }
    }
    public class Windows : OperatingSystem
    {
        private WindowsVersion _version;
        public Windows(WindowsVersion version)
        {
            _version = version;
        }
        public override object Build()
        {
            return new WindowsAttribute
            {
                Version = _version.ToString()
            };
        }
    }
    public class LinuxAttribute
    {
        public string Distribution { get; set; }
        public override bool Equals(Object obj)
        {
            if (obj is LinuxAttribute)
            {
                var that = obj as LinuxAttribute;
                return  this.Distribution == that.Distribution;
            }
            return false;
        }
    }
    public class Linux : OperatingSystem
    {
        private LinuxDistribution _distribution;
        public Linux(LinuxDistribution distribution)
        {
            _distribution = distribution;
        }

        public override object Build()
        {
            return new LinuxAttribute
            {
                Distribution = _distribution.ToString(),
            };
        }
    }
    public class VirtualMachineResource
    {
        public int CPU { get; set; }
        public int RAM { get; set; }
        public int HardDisk { get; set; }
        public object OperatingSystem { get; set; }
        public override bool Equals(Object obj)
        {
            if (obj is VirtualMachineResource)
            {
                var that = obj as VirtualMachineResource;
                return this.CPU == that.CPU &&
                       this.RAM == that.RAM &&
                       this.HardDisk == that.HardDisk &&
                       this.OperatingSystem.Equals(that.OperatingSystem);
            }
            return false;
        }
    }
}

