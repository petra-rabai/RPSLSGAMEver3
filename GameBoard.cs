using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPSLSGAMEver3.Machine;
using static RPSLSGAMEver3.Player;

namespace RPSLSGAMEver3
{
    public class GameBoard
    {
        public static Dictionary<char, string> gameMenu = new Dictionary<char, string>();
        public static Dictionary<char, string> gameItems = new Dictionary<char, string>();

        public static void LoadDictionarys()
        {
            gameMenu.Add('E', "Start the Game");
            gameMenu.Add('H', "Game Help");
            gameMenu.Add('B', "Back to the Menu");
            gameMenu.Add('Q', "Quit the Game");

            gameItems.Add('P', "Paper");
            gameItems.Add('S', "Scissor");
            gameItems.Add('V', "Spock");
            gameItems.Add('R', "Rock");
            gameItems.Add('L', "Lizard");
        }

        public static void GameInitialize()
        {
            Console.Clear();
            Console.Title = "RPSLS GAME";
            Console.WriteLine("Welcome to the RPSLS Game\n" + "Rock, Paper, Scissor, Lizard, Spock\n"
                + "If you need to read the game rules hit the H key\n"
                + "Hit the E key to start the game or hit the Q key to quit the game\n"
                + "If you want to go back to the main screen hit the B key\n");
            WaitForUser();
        }

        public static void WaitForUser()
        {
            Console.WriteLine("Wait for user input: ");
            Console.Beep();
        }

        public static void GameHelp()
        {
            Console.Clear();
            Console.WriteLine("The Game rules: ");
            Console.WriteLine("Scissors cuts Paper\n" + "Paper covers Rock\n" + "Rock crushes Lizard\n" + "Lizard poisons Spock\n"
                + "Spock smashes Scissors\n" + "Scissors decapitates Lizard\n" + "Lizard eats Paper\n" + "Paper disproves Spock\n"
                + "Spock vaporizes Rock\n" + "Rock crushes Scissors\n" + "\n" + "If you want to go back to the main screen hit the B key\n"
                + "If you want to quit the game hit the Q key\n");
            WaitForUser();
        }

        public static void GameStart()
        {
            Console.Clear();
            Console.WriteLine("Choose an item: \n" + "Paper - P\n" + "Scissor - S\n"
                + "Rock - R\n" + "Lizard - L\n" + "Spock -V\n");
            WaitForUser();
        }

        public static void GameMenu()
        {
            Console.Clear();
            Console.WriteLine("Please hit a valid key: \n" + "Valid keys are: \n" + "H - Help\n" + "E - Start the Game \n" +
                "Q - Quit the Game\n" + "B - Back to the Main screen\n");
            WaitForUser();
        }

        public static void CheckChoosedItems()
        {
            while (!gameItems.ContainsKey(playerPressedkey))
            {
                playerPressedkey = ReadKeyFromKeyboard();
            }
            if (playerPressedkey == machinePressedkey)
            {
                IdentitiesEqual();
                while (!gameItems.ContainsKey(playerPressedkey))
                {
                    GameStart();
                    playerPressedkey = ReadKeyFromKeyboard();
                }
                machinePressedkey = GetMachineInput();
            }
            
            if ((playerPressedkey == 'S' && machinePressedkey == 'P') || (playerPressedkey == 'L' && machinePressedkey == 'P')
                || (playerPressedkey == 'P' && machinePressedkey == 'R') || (playerPressedkey == 'V' && machinePressedkey == 'R')
                || (playerPressedkey == 'R' && machinePressedkey == 'L') || (playerPressedkey == 'S' && machinePressedkey == 'L')
                || (playerPressedkey == 'L' && machinePressedkey == 'V') || (playerPressedkey == 'P' && machinePressedkey == 'V')
                || (playerPressedkey == 'V' && machinePressedkey == 'S') || (playerPressedkey == 'R' && machinePressedkey == 'S'))
            {
                playerPoint++;
            }
            else
            {
                machinePoint++;
            }

            playerChoosedOption = gameItems[playerPressedkey];
            machineChoosedOption = gameItems[machinePressedkey];
        }

        public static void IdentitiesEqual()
        {
            Console.Clear();
            Console.WriteLine("Both identities are equal\n Please choose again: \n");
            GameStart();
        }

        public static void ShowGameResult()
        {
            Console.Clear();
            if (playerPoint > machinePoint)
            {
                Console.WriteLine("You are WIN! :)\n" + "You are choosed the: " + playerChoosedOption + "\n"
                    + "The machine choosed the: " + machineChoosedOption);
            }
            else
            {
                Console.WriteLine("You are LOSE! :(\n" + "You are choosed the: " + playerChoosedOption + "\n"
                    + "The machine choosed the: " + machineChoosedOption);
            }
        }


        public static void SaveTheResult()
        {
            Console.Clear();
            Console.WriteLine("Add your name: ");
            WaitForUser();
            playerName = Console.ReadLine();
            string timestamp = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            string savedresult;
            string Gameresult = "\n" + "Username: " + playerName + " \n" + "Choosed option by the User: " + playerChoosedOption + "\n"
                + "Choosed option by the Machine: " + machineChoosedOption + "\n";
            savedresult = "\n" + timestamp + Gameresult;
            File.AppendAllText("GameResult.txt", savedresult);
        }

        public static void GameFinalize()
        {
            Console.Clear();
            Console.WriteLine("\n" + "If you want a new game hit the E key \n" + "If you want to quit hit the Q key\n");
            WaitForUser();
            playerPressedkey = GetPlayerInput();
        }


    }
}
