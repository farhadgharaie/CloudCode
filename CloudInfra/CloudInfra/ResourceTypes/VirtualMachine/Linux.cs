using CloudInfra.ResourceTypes.Enum;

namespace CloudInfra.ResourceTypes.VirtualMachine
{
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
}

