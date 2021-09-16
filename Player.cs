using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPSLSGAMEver3.GameBoard;


namespace RPSLSGAMEver3
{
    public class Player
    {
        public static string playerName = "";
        public static int playerPoint = 0;
        public static char playerPressedkey;
        public static string playerChoosedOption = "";

        public static char GetPlayerInput()
        {
            ReadKeyboard();
            while((!gameMenu.ContainsKey(playerPressedkey)) && (!gameItems.ContainsKey(playerPressedkey)))
            {
                NotifyPalyerToInvalidAction();
                ReadKeyboard();
            }
            
            return playerPressedkey;
        }

        public static void ReadKeyboard()
        { 
            ConsoleKeyInfo Hitkey = Console.ReadKey();
            playerPressedkey = Char.Parse(Hitkey.Key.ToString());
        }

        public static void NotifyPalyerToInvalidAction()
        {
            InvalidActionMenuItemHelper();
            InvalidActionGameItemHelper();
            WaitForUser();
        }

        public static void InvalidActionMenuItemHelper()
        {
            Console.Clear();
            Console.WriteLine("\nPlease hit a valid key: \n" + " \nIf you in the Manu you can choose the following key: \n");
            foreach (KeyValuePair<char, string> gameMenupair in gameMenu)
            {
                Console.WriteLine(gameMenupair.Key + " - " + gameMenupair.Value);
            }
        }

        public static void InvalidActionGameItemHelper()
        {
            Console.WriteLine("\nIf you in the Game you can choose the following key: \n");
            foreach (KeyValuePair<char, string> gameItempair in gameItems)
            {
                Console.WriteLine(gameItempair.Key + " - " + gameItempair.Value);
            }
        }
    }
}
