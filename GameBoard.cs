using System;
using System.Collections.Generic;
using System.IO;

namespace RPSLSGAMEver3
{
    public class GameBoard
    {
        public Dictionary<char, string> gameMenu = new Dictionary<char, string>();
        public Dictionary<char, string> gameItems = new Dictionary<char, string>();
        public Tuple<string, string> compareChoosedItems;
        public Dictionary<Tuple<string, string>,string> winner = new Dictionary<Tuple<string, string>, string>();
       public void GameCore()
        {
            Player player = new Player();
            Machine machine = new Machine();
            LoadDictionarys();
            GameInitialize(player,machine);
        }

        public void LoadDictionarys()
        {
            gameMenu.Add('E', "Start the Game");
            gameMenu.Add('H', "Game Help");
            gameMenu.Add('B', "Back to the Menu");
            gameMenu.Add('C', "Save the Result");
            gameMenu.Add('Q', "Quit the Game");

            gameItems.Add('P', "Paper");
            gameItems.Add('S', "Scissor");
            gameItems.Add('V', "Spock");
            gameItems.Add('R', "Rock");
            gameItems.Add('L', "Lizard");
        }

        public void GameInitialize(in Player player, Machine machine)
        {
            Console.Clear();
            Console.Title = "RPSLS GAME";
            Console.WriteLine("Welcome to the RPSLS Game\n" + "Rock, Paper, Scissor, Lizard, Spock\n"
                + "If you need to read the game rules hit the H key\n"
                + "Hit the E key to start the game or hit the Q key to quit the game\n");
            WaitForUser();
            player.playerPressedkey = player.GetPlayerInput(this);
            MenuNavigation(player, machine);
        }

        public void WaitForUser()
        {
            Console.WriteLine("\nWait for user input: ");
            Console.Beep();
        }

        public void CheckChoosedItems(in Player player, Machine machine)
        {
            GamePointsReset(player, machine);

            player.playerPressedkey = player.GetPlayerInput(this);
            machine.machinePressedkey = machine.GetMachineInput(this);

            CheckChoosedItemsEquality(player, machine);
            GetChoosedItemsFromTheGameDictionary(player,machine);
            CheckGameRules(player, machine);
        }

        public void GetChoosedItemsFromTheGameDictionary(in Player player, Machine machine)
        {
            player.playerChoosedOption = gameItems[player.playerPressedkey];
            machine.machineChoosedOption = gameItems[machine.machinePressedkey];
        }

        public  void GamePointsReset(in Player player, Machine machine)
        {
            player.playerPoint = 0;
            machine.machinePoint = 0;
        }

        public void CheckGameRules(in Player player, Machine machine)
        {
            compareChoosedItems = new Tuple<string, string>(player.playerChoosedOption, machine.machineChoosedOption);
            ScissorCutPaper(player, machine);
            LizardEatPaper(player, machine);
            RockHitLizard(player, machine);
            ScissorCutLizard(player, machine);
            LizardPoisonedSpock(player, machine);
            PaperDisposeSpock(player, machine);
            SpockBrakeScissor(player, machine);
            RockBrakeScissor(player, machine);
            SpockVaporizeRock(player, machine);
            PaperCoverRock(player,machine);
        }

        public void PaperCoverRock(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Paper" && compareChoosedItems.Item2 == "Rock")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Rock" && compareChoosedItems.Item2 == "Paper")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void SpockVaporizeRock(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Spock" && compareChoosedItems.Item2 == "Rock")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Rock" && compareChoosedItems.Item2 == "Spock")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void RockBrakeScissor(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Rock" && compareChoosedItems.Item2 == "Scissor")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Scissor" && compareChoosedItems.Item2 == "Rock")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void SpockBrakeScissor(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Spock" && compareChoosedItems.Item2 == "Scissor")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Scissor" && compareChoosedItems.Item2 == "Spock")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void PaperDisposeSpock(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Paper" && compareChoosedItems.Item2 == "Spock")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Spock" && compareChoosedItems.Item2 == "Paper")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void LizardPoisonedSpock(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Lizard" && compareChoosedItems.Item2 == "Spock")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Spock" && compareChoosedItems.Item2 == "Lizard")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void ScissorCutLizard(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Scissor" && compareChoosedItems.Item2 == "Lizard")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Lizard" && compareChoosedItems.Item2 == "Scissor")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void RockHitLizard(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Rock" && compareChoosedItems.Item2 == "Lizard")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Lizard" && compareChoosedItems.Item2 == "Rock")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void LizardEatPaper(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Lizard" && compareChoosedItems.Item2 == "Paper")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Paper" && compareChoosedItems.Item2 == "Lizard")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void ScissorCutPaper(in Player player, Machine machine)
        {
            if (compareChoosedItems.Item1 == "Scissor" && compareChoosedItems.Item2 == "Paper")
            {
                winner.Add(compareChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else if (compareChoosedItems.Item1 == "Paper" && compareChoosedItems.Item2 == "Scissor")
            {
                winner.Add(compareChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public  void CheckChoosedItemsEquality(in Player player, Machine machine)
        {
            if (player.playerPressedkey == machine.machinePressedkey)
            {
                IdentitiesEqual();
                player.InvalidActionHelper(this);
                WaitForUser();
                player.playerPressedkey = player.GetPlayerInput(this);
                machine.machinePressedkey = machine.GetMachineInput(this);
            }
        }

        public void Game(in Player player, Machine machine)
        {
            Console.Clear();
            Console.WriteLine("Choose an item: \n" + "Paper - P\n" + "Scissor - S\n"
                + "Rock - R\n" + "Lizard - L\n" + "Spock -V\n");
            WaitForUser();
            CheckChoosedItems(player,machine);
            ShowGameResult(player,machine);
            GameFinalize(player,machine);
        }

        public void IdentitiesEqual()
        {
            Console.Clear();
            Console.WriteLine("Both identities are equal\n");
        }

        public void GameHelp(in Player player, Machine machine)
        {
            Console.Clear();
            Console.WriteLine("The Game rules: ");
            Console.WriteLine("Scissors cuts Paper\n" + "Paper covers Rock\n" + "Rock crushes Lizard\n" + "Lizard poisons Spock\n"
                + "Spock smashes Scissors\n" + "Scissors decapitates Lizard\n" + "Lizard eats Paper\n" + "Paper disproves Spock\n"
                + "Spock vaporizes Rock\n" + "Rock crushes Scissors\n" + "\n" + "If you want to go back to the main screen hit the B key\n"
                + "If you want to quit the game hit the Q key\n");
            WaitForUser();
            player.playerPressedkey = player.GetPlayerInput(this);
            MenuNavigation(player,machine);
        }

        public void ShowGameResult(in Player player, Machine machine)
        {
            Console.Clear();
            if (player.playerPoint > machine.machinePoint)
            {
                Console.WriteLine("You are WIN! :)\n" + winner.ToString() + "Player point: "+ player.playerPoint + "\n" + "You are choosed the: " + player.playerChoosedOption + "\n"
                    + "The machine choosed the: " + machine.machineChoosedOption);
            }
            else
            {
                Console.WriteLine("You are LOSE! :(\n" + winner.ToString() + "Machine point: " + machine.machinePoint + "\n"  + "You are choosed the: " + player.playerChoosedOption + "\n"
                    + "The machine choosed the: " + machine.machineChoosedOption);
            }

            Console.WriteLine("\nIf you want to save the result hit the C key\n" + "If you want to exit the game without save hit the Q key\n");
            WaitForUser();
            player.playerPressedkey = player.GetPlayerInput(this);
            MenuNavigation(player,machine);
        }

        public void SaveTheResult(in Player player, Machine machine)
        {
            Console.Clear();
            Console.WriteLine("Add your name: ");
            WaitForUser();
            player.playerName = Console.ReadLine();
            string timestamp = DateTime.Now.ToString("MM/dd/yyyy h:mm tt\n");
            string savedresult;
            string Gameresult = "\n" + "Username: " + player.playerName + " \n" + "Player point: " + player.playerPoint + "\n" + "Choosed option by the Player: " + player.playerChoosedOption + "\n"
                + "Machine point: " + machine.machinePoint + "\n" + "Choosed option by the Machine: " + machine.machineChoosedOption + "\n";
            savedresult = "\n" + timestamp + "\n" + Gameresult;
            File.AppendAllText("GameResult.txt", savedresult);
        }

        public void GameFinalize(in Player player, Machine machine)
        {
            Console.Clear();
            Console.WriteLine("\n" + "If you want a new game hit the E key \n" + "If you want to quit hit the Q key\n");
            WaitForUser();
            player.playerPressedkey = player.GetPlayerInput(this);
            MenuNavigation(player,machine);
        }

        public void MenuNavigation(in Player player, Machine machine)
        {
            switch (player.playerPressedkey)
            {
                case 'H':
                    GameHelp(player,machine);
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'B':
                    GameInitialize(player,machine);
                    break;
                case 'C':
                    SaveTheResult(player,machine);
                    break;
                case 'E':
                    Game(player,machine);
                    break;
                default:
                    break;
            }
        }

    }
}
