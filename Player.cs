using System;
using System.Collections.Generic;
using static RPSLSGAMEver3.GameBoard;


namespace RPSLSGAMEver3
{
    public class Player
    {
        public static string playerName = "";
        public static int playerPoint;
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
            InvalidActionHelper();
            WaitForUser();
        }

        public static void InvalidActionHelper()
        {
            Console.Clear();
            Console.WriteLine("\nPlease hit a valid key: \n");
            foreach (KeyValuePair<char, string> gameMenupair in gameMenu)
            {
                Console.WriteLine(gameMenupair.Key + " - " + gameMenupair.Value);
            }
            foreach (KeyValuePair<char, string> gameItempair in gameItems)
            {
                Console.WriteLine(gameItempair.Key + " - " + gameItempair.Value);
            }
        }
    }
}
