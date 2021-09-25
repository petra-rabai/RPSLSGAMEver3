using System;
using System.Collections.Generic;
using System.IO;

namespace RPSLSGAMEver3
{
    public class GameBoard
    {
        public Dictionary<char, string> gameMenu = new Dictionary<char, string>();
        public Dictionary<char, string> gameItems = new Dictionary<char, string>();
        public Tuple<string, string> compaerChoosedItems;
        public Dictionary<Tuple<string, string>,string> winner = new Dictionary<Tuple<string, string>, string>();
       public void GameCore()
        {
            Player player = new Player();
            LoadDictionarys();
            GameInitialize(player);
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

        public void GameInitialize(in Player player)
        {
            Console.Clear();
            Console.Title = "RPSLS GAME";
            Console.WriteLine("Welcome to the RPSLS Game\n" + "Rock, Paper, Scissor, Lizard, Spock\n"
                + "If you need to read the game rules hit the H key\n"
                + "Hit the E key to start the game or hit the Q key to quit the game\n");
            WaitForUser();
            player.playerPressedkey = player.GetPlayerInput(this);
            MenuNavigation();
        }

        public void WaitForUser()
        {
            Console.WriteLine("\nWait for user input: ");
            Console.Beep();
        }

        public void CheckChoosedItems()
        {
            GamePointsReset();

            player.playerPressedkey = player.GetPlayerInput();
            machine.machinePressedkey = machine.GetMachineInput();

            CheckChoosedItemsEquality();
            GetChoosedItemsFromTheGameDictionary();
            CheckGameRules();
        }

        public void GetChoosedItemsFromTheGameDictionary()
        {
            player.playerChoosedOption = gameItems[player.playerPressedkey];
            machine.machineChoosedOption = gameItems[machine.machinePressedkey];
        }

        public  void GamePointsReset()
        {
            player.playerPoint = 0;
            machine.machinePoint = 0;
        }

        public void CheckGameRules()
        {
            compaerChoosedItems = new Tuple<string, string>(player.playerChoosedOption, machine.machineChoosedOption);
            ScissorCutPaper();
            LizardEatPaper();
            RockHitLizard();
            ScissorCutLizard();
            LizardPoisonedSpock();
            PaperDisposeSpock();
            SpockBrakeScissor();
            RockBrakeScissor();
            SpockVaporizeRock();
            PaperCoverRock();
        }

        public void PaperCoverRock()
        {
            if (compaerChoosedItems.Item1 == "Paper" && compaerChoosedItems.Item2 == "Rock")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void SpockVaporizeRock()
        {
            if (compaerChoosedItems.Item1 == "Spock" && compaerChoosedItems.Item2 == "Rock")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void RockBrakeScissor()
        {
            if (compaerChoosedItems.Item1 == "Rock" && compaerChoosedItems.Item2 == "Scissor")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void SpockBrakeScissor()
        {
            if (compaerChoosedItems.Item1 == "Spock" && compaerChoosedItems.Item2 == "Scissor")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void PaperDisposeSpock()
        {
            if (compaerChoosedItems.Item1 == "Paper" && compaerChoosedItems.Item2 == "Spock")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void LizardPoisonedSpock()
        {
            if (compaerChoosedItems.Item1 == "Lizard" && compaerChoosedItems.Item2 == "Spock")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void ScissorCutLizard()
        {
            if (compaerChoosedItems.Item1 == "Scissor" && compaerChoosedItems.Item2 == "Lizard")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void RockHitLizard()
        {
            if (compaerChoosedItems.Item1 == "Rock" && compaerChoosedItems.Item2 == "Lizard")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void LizardEatPaper()
        {
            if (compaerChoosedItems.Item1 == "Lizard" && compaerChoosedItems.Item2 == "Paper")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public void ScissorCutPaper()
        {
            if (compaerChoosedItems.Item1 == "Scissor" && compaerChoosedItems.Item2 == "Paper")
            {
                winner.Add(compaerChoosedItems, player.playerChoosedOption);
                player.playerPoint++;

            }
            else
            {
                winner.Add(compaerChoosedItems, machine.machineChoosedOption);
                machine.machinePoint++;
            }
        }

        public  void CheckChoosedItemsEquality()
        {
            if (player.playerPressedkey == machine.machinePressedkey)
            {
                IdentitiesEqual();
                player.InvalidActionHelper();
                WaitForUser();
                player.playerPressedkey = player.GetPlayerInput();
                machine.machinePressedkey = machine.GetMachineInput();
            }
        }

        public void Game()
        {
            Console.Clear();
            Console.WriteLine("Choose an item: \n" + "Paper - P\n" + "Scissor - S\n"
                + "Rock - R\n" + "Lizard - L\n" + "Spock -V\n");
            WaitForUser();
            CheckChoosedItems();
            ShowGameResult();
            GameFinalize();
        }

        public void IdentitiesEqual()
        {
            Console.Clear();
            Console.WriteLine("Both identities are equal\n");
        }

        public void GameHelp()
        {
            Console.Clear();
            Console.WriteLine("The Game rules: ");
            Console.WriteLine("Scissors cuts Paper\n" + "Paper covers Rock\n" + "Rock crushes Lizard\n" + "Lizard poisons Spock\n"
                + "Spock smashes Scissors\n" + "Scissors decapitates Lizard\n" + "Lizard eats Paper\n" + "Paper disproves Spock\n"
                + "Spock vaporizes Rock\n" + "Rock crushes Scissors\n" + "\n" + "If you want to go back to the main screen hit the B key\n"
                + "If you want to quit the game hit the Q key\n");
            WaitForUser();
            player.playerPressedkey = player.GetPlayerInput();
            MenuNavigation();
        }

        public void ShowGameResult()
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
            player.playerPressedkey = player.GetPlayerInput();
            MenuNavigation();
        }

        public void SaveTheResult()
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

        public void GameFinalize()
        {
            Console.Clear();
            Console.WriteLine("\n" + "If you want a new game hit the E key \n" + "If you want to quit hit the Q key\n");
            WaitForUser();
            player.playerPressedkey = player.GetPlayerInput();
            MenuNavigation();
        }

        public void MenuNavigation()
        {
            switch (player.playerPressedkey)
            {
                case 'H':
                    GameHelp();
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'B':
                    GameInitialize();
                    break;
                case 'C':
                    SaveTheResult();
                    break;
                case 'E':
                    Game();
                    break;
                default:
                    break;
            }
        }

    }
}
