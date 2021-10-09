using NUnit.Framework;
using System;
using RPSLSGAMEver3;
using System.IO;
using System.Collections.Generic;

namespace RPSLSGAMEver3Tests
{
    public class GameBoardTests
    {
        [SetUp]
        public void Setup()
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameContent gameContent = new GameContent();

            player.playerPressedkey = ' ';
            machine.machinePressedkey = ' ';
            player.playerPoint = 0;
            machine.machinePoint = 0;
            player.playerChoosedOption = " ";
            machine.machineChoosedOption = " ";
            
            gameContent.gameMenu.Clear();
            gameContent.gameItems.Clear();
            gameContent.gameResultDirectory = " ";
        }

        [Test]
        public void CheckGameSkeletonSuccess()
        {
            GameContent gameContent = new GameContent();
            GameBoard gameBoard = new GameBoard();

            gameBoard.GameSkeleton();
        }

        [TestCase(1,0)]
        [TestCase(0,1)]
        [Test]
        public void CheckShowGameResultSuccess( int expectedPlayerPoint, int expectedMachinePoint)
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameContent gameContent = new GameContent();
            GameBoard gameBoard = new GameBoard();
            Tuple<string, string> testCompareChoosedItems = new Tuple<string, string>("Scissor", "Paper");
            Dictionary<Tuple<string, string>, string> testWinner = new Dictionary<Tuple<string, string>, string>();

            player.playerChoosedOption = "Scissor";
            machine.machineChoosedOption = "Paper";
            gameContent.compareChoosedItems = testCompareChoosedItems;
            testWinner.Add(testCompareChoosedItems,"Scissor");
            gameContent.winner.Add(testCompareChoosedItems, "Paper");
            gameContent.winner[gameContent.compareChoosedItems] = testWinner[testCompareChoosedItems];
            player.playerPoint = expectedPlayerPoint;
            machine.machinePoint = expectedMachinePoint;
            gameBoard.ShowGameResult(player, machine, gameContent, gameBoard);
        }

        [Test]
        public void CheckGameFinalizeSuccess()
        {
            GameContent gameContent = new GameContent();
            GameBoard gameBoard = new GameBoard();

            gameBoard.GameFinalize(gameContent);
        }

        [TestCase('P')]
        [TestCase('R')]
        [TestCase('V')]
        [TestCase('S')]
        [TestCase('L')]

        [Test]
        public void CheckGetMachineInputSuccess(char key)
        {
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            gameBoard.GetMachineData(machine, gameContent);
            key = machine.machinePressedkey;

            Assert.Contains(key, gameContent.gameItems.Keys);

        }

        [Test]
        public void CheckWriteGameItemsToTheConsoleSuccess()
        {
            GameContent gameContent = new GameContent();
            GameBoard gameBoard = new GameBoard();

            gameBoard.WriteGameItemsToTheConsole(gameContent);
        }

        [TestCase("C:\\Test\\")]
        [Test]
        public void CheckCreateGameResultDirectorySuccess(string expectedGameDirectory)
        {
            GameContent gameContent = new GameContent();
            GameBoard gameBoard = new GameBoard();

            gameContent.gameResultDirectory = expectedGameDirectory;
            gameBoard.CreateGameResultDirectory(gameContent);
            
            DirectoryAssert.Exists(expectedGameDirectory);
            Directory.Delete(expectedGameDirectory);
        }

        [Test]
        public void CheckWriteIdentitiesEqualMessageToTheConsoleSuccess()
        {
            GameContent gameContent = new GameContent();
            GameBoard gameBoard = new GameBoard();

            gameBoard.IdentitiesEqual(gameContent);
        }

        [Test]
        public void CheckWriteWaitForUserMessageToTheConsoleSuccess()
        {
            GameContent gameContent = new GameContent();
            GameBoard gameBoard = new GameBoard();

            gameBoard.WaitForUser(gameContent);
        }

        [Test]
        public void CheckGameRulesApplied()
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            gameBoard.GameRules(player, machine, gameContent);
        }

        [Test]
        public void CheckGetInvalidActionHelperSuccess()
        {
            Player player = new Player();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            gameBoard.GetInvalidActionHelper(player, gameContent);

        }

        [Test]
        public void CheckGameInitializeSuccess()
        {
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            gameBoard.GameInitialize(gameContent);
        }
        
        [TestCase('S','S')]
        [TestCase('P', 'P')]
        [TestCase('R', 'R')]
        [TestCase('L', 'L')]
        [TestCase('V', 'V')]
        [Test]
        public void CheckChoosedItemsEqualitySuccess(char playerKey, char machineKey)
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            player.playerPressedkey = playerKey;
            machine.machinePressedkey = machineKey;
            gameBoard.CheckChoosedItemsEquality(player, machine, gameContent, gameBoard);
            
            Assert.AreEqual(playerKey, player.playerPressedkey);
            Assert.AreEqual(machineKey, machine.machinePressedkey);
        }

        [Test]
        public void CheckDictionarysCount()
        {
            GameContent gameContent = new GameContent();
            var expectedGameMenuCount = 5;
            var expectedGameItemCount = 5;
          
            Assert.AreEqual(expectedGameMenuCount, gameContent.gameMenu.Count);
            Assert.AreEqual(expectedGameItemCount, gameContent.gameItems.Count);

        }

        [Test]
        public void CheckGamePointsResetSuccess()
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            var expectedPlayerPoint = 1;
            var expectedMachinePoint = 1;

            gameBoard.GamePointsReset(player,machine);

            Assert.AreNotEqual(expectedPlayerPoint, player.playerPoint);
            Assert.AreNotEqual(expectedMachinePoint, player.playerPoint);
        }

        [Test]
        public void CheckGameHelpSuccess()
        {
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();
            gameBoard.GameHelp(gameContent);
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
        public void CheckChoosedItemValueGetFromGameDictionary(char keyOne,
                                                               char keyTwo,
                                                               string optionOne,
                                                               string optionTwo)
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            var expectedPlayerChoosedItemValue = optionOne;
            var expectedMachineChoosedItemValue = optionTwo;

            player.playerPressedkey = keyOne;
            machine.machinePressedkey = keyTwo;
            gameBoard.GetChoosedItemsFromTheGameDictionary(player,machine,gameContent);

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
        public void CheckCompareChoosedItemsLoadSuccess(string optionOne,
                                                      string optionTwo)
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            var expectedChoosedItemOne = optionOne;
            var expectedChoosedItemTwo = optionTwo;

            player.playerChoosedOption = optionOne;
            machine.machineChoosedOption = optionTwo;
            gameBoard.LoadCompareChoosedItemsTuple(player, machine, gameContent);

            Assert.AreEqual(expectedChoosedItemOne, gameContent.compareChoosedItems.Item1);
            Assert.AreEqual(expectedChoosedItemTwo, gameContent.compareChoosedItems.Item2);
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
        
        public void CheckGameRulesPlayerSuccess(string optionOne,
                                          string optionTwo)
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            var expectedPlayerPoint = 0;
            var expectedMachinePoint= 0;
            
            player.playerChoosedOption = optionOne;
            machine.machineChoosedOption = optionTwo;
            gameBoard.LoadCompareChoosedItemsTuple(player, machine,gameContent);
            optionOne = gameContent.compareChoosedItems.Item1;
            optionTwo = gameContent.compareChoosedItems.Item2;
            gameBoard.CheckTheRules(player, machine,gameContent,optionOne,optionTwo);
            expectedPlayerPoint = player.playerPoint;
            expectedMachinePoint = machine.machinePoint;

            Assert.AreEqual(expectedPlayerPoint, player.playerPoint);
            Assert.AreEqual(expectedMachinePoint, machine.machinePoint);
            Assert.AreNotEqual(expectedPlayerPoint, expectedMachinePoint);
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

        public void CheckGameRulesMachineSuccess(string optionOne,
                                          string optionTwo)
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            player.playerChoosedOption = optionOne;
            machine.machineChoosedOption = optionTwo;
            gameBoard.LoadCompareChoosedItemsTuple(player, machine, gameContent);
            optionOne = gameContent.compareChoosedItems.Item1;
            optionTwo = gameContent.compareChoosedItems.Item2;
            gameBoard.CheckTheRules(player, machine, gameContent, optionTwo, optionOne);
            expectedPlayerPoint = player.playerPoint;
            expectedMachinePoint = machine.machinePoint;

            Assert.AreEqual(expectedPlayerPoint, player.playerPoint);
            Assert.AreEqual(expectedMachinePoint, machine.machinePoint);
            Assert.AreNotEqual(expectedPlayerPoint, expectedMachinePoint);
        }

        [Test]
        public void CheckResultSavingSuccess()
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();

            var expectedFileName = "";
            var expectedFileData = "";
            
            player.playerName = "Test";
            player.playerPoint = 1;
            player.playerChoosedOption = "Scissor";
            machine.machinePoint = 1;
            machine.machineChoosedOption = "Scissor";
            gameBoard.SaveTheResult(player, machine, gameContent);
            expectedFileName = gameContent.gameResultFullPath;
            expectedFileData = gameContent.gameResult;

            DirectoryAssert.Exists(gameContent.gameResultDirectory);
            FileAssert.Exists(expectedFileName);
            Assert.AreEqual(expectedFileData, gameContent.gameResult);
        }

    }
}
