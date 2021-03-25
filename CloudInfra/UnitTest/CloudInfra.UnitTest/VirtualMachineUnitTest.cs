using CloudInfra.ResourceTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudInfra.ResourceTypes.Enum;
using CloudInfra.ResourceTypes.VirtualMachine;

namespace CloudInfra.UnitTest
{
    [TestClass]
    public class VirtualMachineUnitTest
    {
        [TestMethod]
        public void Build_Windows_VirtualMachine_with_Right_Object()
        {
            //Arrange
            int cpu = 8;
            int ram = 4;
            int hdd = 40;
            WindowsVersion windowsVersion = WindowsVersion.WindowsServer2012;
            var vm = new VirtualMachine(new Windows(windowsVersion), hdd,ram,cpu);

             var excepted = new VirtualMachineResource
            {
                CPU=8,
                HardDisk=40,
                RAM=4,
                OperatingSystem= "WindowsServer2012" 
            };

            //Act
            var action = vm.Build();

            //Assert
            Assert.AreEqual(excepted, action);
        }
        [TestMethod]
        public void Build_Linux_VirtualMachine_with_Right_Object()
        {
            //Arrange
            int cpu = 8;
            int ram = 4;
            int hdd = 40;
            LinuxDistribution linuxDistribution = LinuxDistribution.Debian;
            var vm = new VirtualMachine(new Linux(linuxDistribution), hdd, ram, cpu);

            var excepted = new VirtualMachineResource
            {
                CPU = 8,
                HardDisk = 40,
                RAM = 4,
                OperatingSystem = "Debian"
            };

            //Act
            var action = vm.Build();

            //Assert
            Assert.AreEqual(excepted, action);
        }
    }
}
