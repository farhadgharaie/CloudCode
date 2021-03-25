using CloudInfra.ResourceTypes.Enum;

namespace CloudInfra.ResourceTypes.VirtualMachine
{
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
}

