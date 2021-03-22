using CloudInfra.ResourceTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudInfra.UnitTest
{
    [TestClass]
    public class VirtualMachineUnitTest
    {
        [TestMethod]
        public void VirtualMachine_Create_Right_Object()
        {
            //Arrange
            int cpu = 8;
            int ram = 4;
            int hdd = 40;
            var vm = new VirtualMachine(hdd,ram,cpu);

            var excepted = new VirtualMachineResource
            {
                CPU=cpu,
                HardDisk=hdd,
                RAM=ram
            };

            //Act
            var action = vm.Create();

            //Assert
            Assert.AreEqual(excepted.ToString(), action.ToString());
        }
    }
}
