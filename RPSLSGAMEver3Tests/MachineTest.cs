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
            GameBoard gameBoard = new GameBoard();
            var machineKey = ' ';
            gameBoard.LoadDictionarys();
            machineKey = machine.GetMachineInput(gameBoard);
            Assert.IsNotNull(machineKey);
            Assert.Contains(machineKey, gameBoard.gameItems.Keys);
        }
    }
}