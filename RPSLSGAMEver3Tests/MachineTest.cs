using NUnit.Framework;
using RPSLSGAMEver3;

namespace RPSLSGAMEver3Tests
{
    public class MachineTests
    {
        [SetUp]
        public void Setup()
        {
            GameBoard gameBoard = new GameBoard();
            
            gameBoard.LoadDictionarys();
        }

        [Test]
        public void CheckMachinGetValueNotNullAndGetFromTheGameDictionary()
        {
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            var machineKey = ' ';
            machineKey = machine.GetMachineInput();
            Assert.IsNotNull(machineKey);
            Assert.Contains(machineKey, gameBoard.gameItems.Keys);
        }
    }
}