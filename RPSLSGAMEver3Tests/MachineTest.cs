using NUnit.Framework;
using RPSLSGAMEver3;

namespace RPSLSGAMEver3Tests
{
    public class MachineTests
    {
        [Test]
        public void CheckMachinGetValueNotNullAndGetFromTheGameDictionary()
        {
            Machine machine = new Machine();
            GameContent gameContent = new GameContent();
            var machineKey = ' ';
            machineKey = machine.GetMachineInput(gameContent);
            Assert.IsNotNull(machineKey);
            Assert.Contains(machineKey, gameContent.gameItems.Keys);
        }
    }
}