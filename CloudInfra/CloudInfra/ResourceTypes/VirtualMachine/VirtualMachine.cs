namespace CloudInfra.ResourceTypes.VirtualMachine
{
    public class VirtualMachine
    {
        private int _hardDiskSpace;
        private int _ram;
        private int _cpu;
        private OperatingSystem _operatingSystem;
        public VirtualMachine(OperatingSystem operatingSystem,
                              int HardDisk, int RAM, int CPU)
        {
            _hardDiskSpace = HardDisk;
            _ram = RAM;
            _cpu = CPU;
            _operatingSystem = operatingSystem;
        }
        public VirtualMachineResource Build()
        {
            var res = new VirtualMachineResource()
            {
                CPU = _cpu,
                HardDisk = _hardDiskSpace,
                RAM = _ram,
                OperatingSystem=_operatingSystem.Build()
            };
            return res;
        }
    }
}

