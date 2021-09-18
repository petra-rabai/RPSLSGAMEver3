using NUnit.Framework;
using static RPSLSGAMEver3.Machine;
using static RPSLSGAMEver3.GameBoard;

namespace RPSLSGAMEver3Tests
{
    public class MachineTests
    {
        [SetUp]
        public void Setup()
        {
            LoadDictionarys();
        }

        [Test]
        public void CheckMachineValueIsNotEmpty()
        {
            var machineKey = GetMachineInput();
            Assert.IsNotNull(machineKey);
        }

        [Test]
        public void CheckMachinGetValueFromTheGameDictionary()
        {
             var machineKey = GetMachineInput();
             Assert.Contains(machineKey, gameItems.Keys);
        }
    }
}