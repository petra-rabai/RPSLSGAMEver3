using System;
using System.Collections.Generic;
using System.IO;

namespace RPSLSGAMEver3
{
    public class GameBoard
    {
       public void GameCore()
        {
            Player player = new Player();
            Machine machine = new Machine();
            GameBoard gameBoard = new GameBoard();
            GameContent gameContent = new GameContent();
            GameInitialize(gameContent);
            WaitForUser(gameContent);
            MenuNavigation(player, machine, gameContent, gameBoard);
        }
        public void GameInitialize(GameContent gameContent)
        {
            Console.Title = gameContent.gameTitle;
            Console.WriteLine(gameContent.gameWelcomeMessage); 
        }

        public void WaitForUser(in GameContent gameContent)
        {
            Console.WriteLine(gameContent.waitForUserMessage);
            Console.Beep();
        }

        public void CheckChoosedItems(in Player player, Machine machine, GameContent gameContent, GameBoard gameBoard)
        {
            GamePointsReset(player, machine);
            GetPlayerData(player, gameContent, gameBoard);
            GetMachineData(machine, gameContent);
            ConsoleClear();
            CheckChoosedItemsEquality(player, machine, gameContent,gameBoard);
            GetPlayerData(player, gameContent, gameBoard);
            GetMachineData(machine, gameContent);
            GetChoosedItemsFromTheGameDictionary(player, machine,gameContent);
            GameRules(player, machine,gameContent);
        }

        public void GetMachineData(in Machine machine, GameContent gameContent)
        {
            machine.machinePressedkey = machine.GetMachineInput(gameContent);
        }

        public void GetPlayerData(in Player player, GameContent gameContent, GameBoard gameBoard)
        {
            player.playerPressedkey = player.GetPlayerInput(gameContent, gameBoard);
        }

        public void GetChoosedItemsFromTheGameDictionary(in Player player, Machine machine, GameContent gameContent)
        {
            GetPlayerChoosedOption(player, gameContent);
            GetMachineChoosedOption(machine, gameContent);
        }

        public static void GetMachineChoosedOption(Machine machine, GameContent gameContent)
        {
            machine.machineChoosedOption = gameContent.gameItems[machine.machinePressedkey];
        }

        public static void GetPlayerChoosedOption(Player player, GameContent gameContent)
        {
            player.playerChoosedOption = gameContent.gameItems[player.playerPressedkey];
        }

        public  void GamePointsReset(in Player player, Machine machine)
        {
            player.playerPoint = 0;
            machine.machinePoint = 0;
        }

        public void GameRules(in Player player, Machine machine, GameContent gameContent)
        {
            LoadCompareChoosedItemsTuple(player, machine,gameContent);
            CheckTheRules(player, machine, gameContent, gameContent.compareChoosedItems.Item1, gameContent.compareChoosedItems.Item2);
        }

        public void LoadCompareChoosedItemsTuple(Player player, Machine machine, GameContent gameContent)
        {
            gameContent.compareChoosedItems = new Tuple<string, string>(player.playerChoosedOption, machine.machineChoosedOption);
        }

        public void CheckTheRules(in Player player, Machine machine,GameContent gameContent, string optionOne, string optionTwo)
        {
            if (optionOne == gameContent.compareChoosedItems.Item1 && optionTwo == gameContent.compareChoosedItems.Item2)
            {
                PlayerWin(player, gameContent, optionOne);

            }
            else if (optionOne == gameContent.compareChoosedItems.Item2 && optionTwo == gameContent.compareChoosedItems.Item1)
            {
                MachineWin(machine, gameContent, optionOne);
            }
        }

        public static void MachineWin(Machine machine, GameContent gameContent, string optionOne)
        {
            AddWinnerInfo(gameContent, optionOne);
            machine.machinePoint++;
        }

        public static void AddWinnerInfo(GameContent gameContent, string optionOne)
        {
            gameContent.winner.Add(gameContent.compareChoosedItems, optionOne);
        }

        public static void PlayerWin(Player player, GameContent gameContent, string optionOne)
        {
            AddWinnerInfo(gameContent, optionOne);
            player.playerPoint++;
        }

        public  void CheckChoosedItemsEquality(in Player player, Machine machine, GameContent gameContent, GameBoard gameBoard)
        {
            if (player.playerPressedkey == machine.machinePressedkey)
            {
                IdentitiesEqual(gameContent);
                GetInvalidActionHelper(player,gameContent);
                WaitForUser(gameContent);  
            }
        }

        public void GetInvalidActionHelper(in Player player, GameContent gameContent)
        {
            player.InvalidActionHelper(gameContent);
        }

        public void Game(in Player player, Machine machine, GameContent gameContent, GameBoard gameBoard)
        {
            CheckChoosedItems(player, machine, gameContent, gameBoard);
            ShowGameResult(player, machine, gameContent, gameBoard);
            GameFinalize(player, machine, gameContent, gameBoard);
        }

        public void WriteGameItemsToTheConsole(GameContent gameContent)
        {
            Console.WriteLine(gameContent.gameAvailableItems);
            WaitForUser(gameContent);
        }

        public void IdentitiesEqual(in GameContent gameContent)
        {
            Console.WriteLine(gameContent.identiiesEqualMessage);
        }

        public void GameHelp(in Player player, Machine machine, GameContent gameContent, GameBoard gameBoard)
        {
            Console.WriteLine(gameContent.gameRulesMessage);
            WaitForUser(gameContent);
            MenuNavigation(player,machine,gameContent,gameBoard);
        }

        public void ShowGameResult(in Player player, Machine machine, GameContent gameContent, GameBoard gameBoard)
        {
            Console.Clear();
            if (player.playerPoint > machine.machinePoint)
            {
                Console.WriteLine(gameContent.gameWinnerMessage
                                  + gameContent.winner[gameContent.compareChoosedItems]
                                  + gameContent.gamePlayerPointMessage
                                  + player.playerPoint
                                  + gameContent.gamePlayerChoosedOptionMessage
                                  + player.playerChoosedOption
                                  + gameContent.gameMachineChoosedOtionMessage
                                  + machine.machineChoosedOption);
            }
            else
            {
                Console.WriteLine(gameContent.gameLoseMessage
                                  + gameContent.winner[gameContent.compareChoosedItems]
                                  + gameContent.gameMachinePointMessage
                                  + machine.machinePoint
                                  + gameContent.gamePlayerChoosedOptionMessage
                                  + player.playerChoosedOption
                                  + gameContent.gameMachineChoosedOtionMessage
                                  + machine.machineChoosedOption);
            }

            Console.WriteLine(gameContent.gameChooseSaveTheResultOrQuitMessage);
            WaitForUser(gameContent);
            MenuNavigation(player,machine,gameContent,gameBoard);
        }

        public void CreateGameResultDirectory(GameContent gameContent)
        {
            gameContent.gameDirectoryExists = Directory.Exists(gameContent.gameResultDirectory);
            if (!gameContent.gameDirectoryExists)
            {
               Directory.CreateDirectory(gameContent.gameResultDirectory);
            }
                
        }

        public void SaveTheResult(in Player player, Machine machine, GameContent gameContent)
        {
            CreateGameResultDirectory(gameContent);
            gameContent.gameResult = gameContent.playerNameMessage
                                    + player.playerName
                                    + gameContent.gamePlayerPointMessage
                                    + player.playerPoint
                                    + gameContent.gamePlayerChoosedOptionMessage
                                    + player.playerChoosedOption
                                    + gameContent.gameMachinePointMessage
                                    + machine.machinePoint
                                    + gameContent.gameMachineChoosedOtionMessage
                                    + machine.machineChoosedOption;

            gameContent.savedResult = gameContent.timeStamp
                                      + gameContent.gameResult;

            gameContent.gameResultFullPath = gameContent.gameResultDirectory
                                             + gameContent.savedDataFileName;
            File.AppendAllText(gameContent.gameResultFullPath, gameContent.savedResult);
        }

        public void GetPlayerName(Player player, GameContent gameContent)
        {
            Console.Clear();
            Console.WriteLine(gameContent.gameSaveResultGetPlayerNameMessage);
            WaitForUser(gameContent);
            player.playerName = Console.ReadLine();
        }

        public void GameFinalize(in Player player, Machine machine, GameContent gameContent, GameBoard gameBoard)
        {
            Console.WriteLine(gameContent.gameFinalizeMessage);
            WaitForUser(gameContent);
            MenuNavigation(player,machine,gameContent,gameBoard);
        }

        public void ConsoleClear()
        {
            Console.Clear();
        }

        public void MenuNavigation(in Player player, Machine machine, GameContent gameContent, GameBoard gameBoard)
        {
            GetPlayerData(player,gameContent,gameBoard);
            switch (gameContent.gameMenu[player.playerPressedkey])
            {
                case "Game Help":
                    ConsoleClear();
                    GameHelp(player,machine, gameContent,gameBoard);
                    break;
                case "Quit the Game":
                    Environment.Exit(0);
                    break;
                case "Back to the Menu":
                    GameInitialize(gameContent);
                    break;
                case "Save the Result":
                    GetPlayerName(player, gameContent);
                    SaveTheResult(player,machine,gameContent);
                    break;
                case "Start the Game":
                    ConsoleClear();
                    WriteGameItemsToTheConsole(gameContent);
                    Game(player,machine,gameContent,gameBoard);
                    break;
                default:
                    break;
            }
        }

    }
}
