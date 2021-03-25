using System.Runtime.Serialization;

namespace CloudInfra.ResourceTypes.VirtualMachine
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
}

