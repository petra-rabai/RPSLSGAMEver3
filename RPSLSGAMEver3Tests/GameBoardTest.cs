using NUnit.Framework;
using static RPSLSGAMEver3.Machine;
using static RPSLSGAMEver3.GameBoard;
using static RPSLSGAMEver3.Player;

namespace RPSLSGAMEver3Tests
{
    public class GameBoardTests
    {
        [SetUp]
        public void Setup()
        {
            playerPressedkey = ' ';
            machinePressedkey = ' ';
            playerPoint = 0;
            machinePoint = 0;
            playerChoosedOption = " ";
            machineChoosedOption = " ";
            gameMenu.Clear();
            gameItems.Clear();
        }

        [Test]
        public void CheckDictionarysLoadSuccess()
        {
            var expectedGameMenuCount = 0;
            var expectedGameItemCount = 0;
            LoadDictionarys();
            expectedGameMenuCount = 5;
            expectedGameItemCount = 5;
            Assert.AreEqual(expectedGameMenuCount,gameMenu.Count);
            Assert.AreEqual(expectedGameItemCount, gameItems.Count);

        }

        [Test]
        public void CheckGamePointsResetSuccess()
        {
            var expectedPlayerPoint = 1;
            var expectedMachinePoint = 1;

            GamePointsReset();
            Assert.AreNotEqual(expectedPlayerPoint, playerPoint);
            Assert.AreNotEqual(expectedMachinePoint, playerPoint);
        }

        [Test]
        public void CheckPaperCoverRockPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'P';
            machinePressedkey = 'R';
            
            GameRulePaperCoverRock();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint,playerPoint);
            Assert.AreEqual(expectedMachinePoint,machinePoint);
        }

        [Test]
        public void CheckPaperCoverRockMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'R';
            machinePressedkey = 'P';

            GameRulePaperCoverRock();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckSpockVaporizeRockPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'V';
            machinePressedkey = 'R';

            GameRuleSpockVaporizeRock();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckSpockVaporizeRockMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'R';
            machinePressedkey = 'V';

            GameRuleSpockVaporizeRock();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckRockCrushScissorPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'R';
            machinePressedkey = 'S';

            GameRuleRockCrushScissor();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckRockCrushScissorMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'S';
            machinePressedkey = 'R';

            GameRuleRockCrushScissor();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckSpockCrashScissorPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'V';
            machinePressedkey = 'S';

            GameRuleSpockCrashScissor();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckSpockCrashScissorMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'S';
            machinePressedkey = 'V';

            GameRuleSpockCrashScissor();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }


        [Test]
        public void CheckPaperDisprovesSpockPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'P';
            machinePressedkey = 'V';

            GameRulePaperDisprovesSpock();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckPaperDisprovesSpockMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'V';
            machinePressedkey = 'P';

            GameRulePaperDisprovesSpock();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckLizardPoisonedSpockPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'L';
            machinePressedkey = 'V';

            GameRuleLizardPoisonedSpock();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckLizardPoisonedSpockMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'V';
            machinePressedkey = 'L';

            GameRuleLizardPoisonedSpock();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckScissorCutLizardPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'S';
            machinePressedkey = 'L';

            GameRuleScissorCutLizard();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckScissorCutLizardMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'L';
            machinePressedkey = 'S';

            GameRuleScissorCutLizard();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckRockHitLizardPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'R';
            machinePressedkey = 'L';

            GameRuleRockHitLizard();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckRockHitLizardMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'L';
            machinePressedkey = 'R';

            GameRuleRockHitLizard();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckScissorCutPaperPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'S';
            machinePressedkey = 'P';

            GameRuleScissorCutPaper();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckScissorCutPaperMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'P';
            machinePressedkey = 'S';

            GameRuleScissorCutPaper();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckLizardEatPaperPlayerWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'L';
            machinePressedkey = 'P';

            GameRuleLizardEatPaper();
            expectedPlayerPoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckLizardEatPaperMachineWin()
        {
            var expectedPlayerPoint = 0;
            var expectedMachinePoint = 0;

            playerPressedkey = 'P';
            machinePressedkey = 'L';

            GameRuleLizardEatPaper();
            expectedMachinePoint = 1;
            Assert.AreEqual(expectedPlayerPoint, playerPoint);
            Assert.AreEqual(expectedMachinePoint, machinePoint);
        }

        [Test]
        public void CheckChoosedItemValueGetFromGameDictionary()
        {
            var expectedPlayerChoosedItemValue = " ";
            var expectedMachineChoosedItemValue = " ";
            LoadDictionarys();
            playerPressedkey = 'S';
            machinePressedkey = 'S';
            expectedPlayerChoosedItemValue = "Scissor";
            expectedMachineChoosedItemValue = "Scissor";
            GetChoosedItemsFromTheGameDictionary();
            Assert.AreEqual(expectedPlayerChoosedItemValue,playerChoosedOption);
            Assert.AreEqual(expectedMachineChoosedItemValue, playerChoosedOption);
        }






    }
}
