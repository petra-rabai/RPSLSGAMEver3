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
            GameRules(player, machine);
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

        public void GameRules(in Player player, Machine machine)
        {
            LoadCompareChoosedItemsTuple(player, machine);
            CheckTheRules(player, machine, compareChoosedItems.Item1, compareChoosedItems.Item2);
        }

        public void LoadCompareChoosedItemsTuple(Player player, Machine machine)
        {
            compareChoosedItems = new Tuple<string, string>(player.playerChoosedOption, machine.machineChoosedOption);
        }

        public void CheckTheRules(in Player player, Machine machine, string optionOne, string optionTwo)
        {
            if (optionOne == player.playerChoosedOption && optionTwo == machine.machineChoosedOption)
            {
                winner.Add(compareChoosedItems, optionOne);
                player.playerPoint++;

            }
            else if (optionOne == machine.machineChoosedOption && optionTwo == player.playerChoosedOption)
            {
                winner.Add(compareChoosedItems, optionTwo);
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
                Console.WriteLine("You are WIN! :)\n" + "The winner is: " + winner[compareChoosedItems]+ "\n" + "Player point: "+ player.playerPoint + "\n" + "You are choosed: " + player.playerChoosedOption + "\n"
                    + "The machine choosed: " + machine.machineChoosedOption);
            }
            else
            {
                Console.WriteLine("You are LOSE! :(\n" + "The winner is: " + winner[compareChoosedItems] + "\n" + "Machine point: " + machine.machinePoint + "\n"  + "You are choosed: " + player.playerChoosedOption + "\n"
                    + "The machine choosed: " + machine.machineChoosedOption);
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
