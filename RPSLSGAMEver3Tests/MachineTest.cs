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
        public void CheckMachinGetValueNotNullAndGetFromTheGameDictionary()
        {
            var machineKey = ' ';
            machineKey = GetMachineInput();
            Assert.IsNotNull(machineKey);
            Assert.Contains(machineKey, gameItems.Keys);
        }
    }
}