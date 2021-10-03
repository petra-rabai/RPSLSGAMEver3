using NUnit.Framework;
using RPSLSGAMEver3;

namespace RPSLSGAMEver3Tests
{
    public class GameBoardTests
    {
        [SetUp]
        public void Setup()
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            player.playerPressedkey = ' ';
            machine.machinePressedkey = ' ';
            player.playerPoint = 0;
            machine.machinePoint = 0;
            player.playerChoosedOption = " ";
            machine.machineChoosedOption = " ";
            gameBoard.gameMenu.Clear();
            gameBoard.gameItems.Clear();
        }

        [Test]
        public void CheckDictionarysLoadSuccess()
        {
            GameBoard gameBoard = new GameBoard();
            var expectedGameMenuCount = 0;
            var expectedGameItemCount = 0;
            gameBoard.LoadDictionarys();
            expectedGameMenuCount = 5;
            expectedGameItemCount = 5;
            Assert.AreEqual(expectedGameMenuCount, gameBoard.gameMenu.Count);
            Assert.AreEqual(expectedGameItemCount, gameBoard.gameItems.Count);

        }

        [Test]
        public void CheckGamePointsResetSuccess()
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            var expectedPlayerPoint = 1;
            var expectedMachinePoint = 1;

            gameBoard.GamePointsReset(player,machine);
            Assert.AreNotEqual(expectedPlayerPoint, player.playerPoint);
            Assert.AreNotEqual(expectedMachinePoint, player.playerPoint);
        }

        [TestCase('P', 'R', "Paper", "Rock")]
        [TestCase('V', 'R', "Spock", "Rock")]
        [TestCase('S', 'P', "Scissor", "Paper")]
        [TestCase('R', 'S', "Rock", "Scissor")]
        [TestCase('V', 'S', "Spock", "Scissor")]
        [TestCase('P', 'V', "Paper", "Spock")]
        [TestCase('L', 'V', "Lizard", "Spock")]
        [TestCase('S', 'L', "Scissor", "Lizard")]
        [TestCase('R', 'L', "Rock", "Lizard")]
        [TestCase('L', 'P', "Lizard", "Paper")]
        [TestCase('R', 'P', "Rock", "Paper")]
        [TestCase('R', 'V', "Rock", "Spock")]
        [TestCase('P', 'S', "Paper", "Scissor")]
        [TestCase('S', 'R', "Scissor", "Rock")]
        [TestCase('S', 'V', "Scissor", "Spock")]
        [TestCase('V', 'P', "Spock", "Paper")]
        [TestCase('V', 'L', "Spock", "Lizard")]
        [TestCase('L', 'S', "Lizard", "Scissor")]
        [TestCase('L', 'R', "Lizard", "Rock")]
        [TestCase('P', 'L', "Paper", "Lizard")]
        [Test]
        public void CheckChoosedItemValueGetFromGameDictionary( char keyOne, char keyTwo, string optionOne,string optionTwo )
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            var expectedPlayerChoosedItemValue = " ";
            var expectedMachineChoosedItemValue = " ";
            gameBoard.LoadDictionarys();
            player.playerPressedkey = keyOne;
            machine.machinePressedkey = keyTwo;
            expectedPlayerChoosedItemValue = optionOne;
            expectedMachineChoosedItemValue = optionTwo;
            gameBoard.GetChoosedItemsFromTheGameDictionary(player,machine);
            Assert.AreEqual(expectedPlayerChoosedItemValue,player.playerChoosedOption);
            Assert.AreEqual(expectedMachineChoosedItemValue, machine.machineChoosedOption);
        }

        [TestCase("Paper", "Rock")]
        [TestCase("Spock", "Rock")]
        [TestCase("Scissor", "Paper")]
        [TestCase("Rock", "Scissor")]
        [TestCase("Spock", "Scissor")]
        [TestCase("Paper", "Spock")]
        [TestCase("Lizard", "Spock")]
        [TestCase("Scissor", "Lizard")]
        [TestCase("Rock", "Lizard")]
        [TestCase("Lizard", "Paper")]
        [TestCase("Rock", "Paper")]
        [TestCase("Rock", "Spock")]
        [TestCase("Paper", "Scissor")]
        [TestCase("Scissor", "Rock")]
        [TestCase("Scissor", "Spock")]
        [TestCase("Spock", "Paper")]
        [TestCase("Spock", "Lizard")]
        [TestCase("Lizard", "Scissor")]
        [TestCase("Lizard", "Rock")]
        [TestCase("Paper", "Lizard")]
        [Test]
        public void CheckCompareChoosedItemsLoadSuccess(string optionOne, string optionTwo)
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            gameBoard.LoadDictionarys();
            var expectedChoosedItemOne = optionOne;
            var expectedChoosedItemTwo = optionTwo;
            player.playerChoosedOption = optionOne;
            machine.machineChoosedOption = optionTwo;
            gameBoard.LoadCompareChoosedItemsTuple(player, machine);
            Assert.AreEqual(expectedChoosedItemOne, gameBoard.compareChoosedItems.Item1);
            Assert.AreEqual(expectedChoosedItemTwo, gameBoard.compareChoosedItems.Item2);
        }

        [TestCase("Paper", "Rock")]
        [TestCase("Spock", "Rock")]
        [TestCase("Scissor", "Paper")]
        [TestCase("Rock", "Scissor")]
        [TestCase("Spock", "Scissor")]
        [TestCase("Paper", "Spock")]
        [TestCase("Lizard", "Spock")]
        [TestCase("Scissor", "Lizard")]
        [TestCase("Rock", "Lizard")]
        [TestCase("Lizard", "Paper")]
        [TestCase("Rock", "Paper")]
        [TestCase("Rock", "Spock")]
        [TestCase("Paper", "Scissor")]
        [TestCase("Scissor", "Rock")]
        [TestCase("Scissor", "Spock")]
        [TestCase("Spock", "Paper")]
        [TestCase("Spock", "Lizard")]
        [TestCase("Lizard", "Scissor")]
        [TestCase("Lizard", "Rock")]
        [TestCase("Paper", "Lizard")]
        [Test]
        
        public void CheckGameRulesSuccess(string optionOne, string optionTwo)
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            var expectedPlayerPoint = 0;
            var expectedMachinePoint= 0;
            player.playerChoosedOption = optionOne;
            machine.machineChoosedOption = optionTwo;
            gameBoard.LoadCompareChoosedItemsTuple(player, machine);
            optionOne = gameBoard.compareChoosedItems.Item1;
            optionTwo = gameBoard.compareChoosedItems.Item2;
            gameBoard.CheckTheRules(player, machine,optionOne,optionTwo);
            expectedPlayerPoint = player.playerPoint;
            expectedMachinePoint = machine.machinePoint;
            Assert.AreEqual(expectedPlayerPoint, player.playerPoint);
            Assert.AreEqual(expectedMachinePoint, machine.machinePoint);
            Assert.AreNotEqual(expectedPlayerPoint, expectedMachinePoint);
        }
    }
}
