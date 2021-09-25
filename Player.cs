using System;
using System.Collections.Generic;


namespace RPSLSGAMEver3
{
    public class Player
    {
        public string playerName = "";
        public int playerPoint;
        public char playerPressedkey;
        public string playerChoosedOption = "";
        GameBoard gameBoard = new GameBoard();

        public char GetPlayerInput()
        {
            ReadKeyboard();
            while((!gameBoard.gameMenu.ContainsKey(playerPressedkey)) && (!gameBoard.gameItems.ContainsKey(playerPressedkey)))
            {
                NotifyPalyerToInvalidAction();
                ReadKeyboard();
            }
            
            return playerPressedkey;
        }

        public void ReadKeyboard()
        { 
            ConsoleKeyInfo Hitkey = Console.ReadKey();
            playerPressedkey = Char.Parse(Hitkey.Key.ToString());
        }

        public void NotifyPalyerToInvalidAction()
        {
            InvalidActionHelper();
            gameBoard.WaitForUser();
        }

        public void InvalidActionHelper()
        {
            Console.Clear();
            Console.WriteLine("\nPlease hit a valid key: \n");
            foreach (KeyValuePair<char, string> gameMenupair in gameBoard.gameMenu)
            {
                Console.WriteLine(gameMenupair.Key + " - " + gameMenupair.Value);
            }
            foreach (KeyValuePair<char, string> gameItempair in gameBoard.gameItems)
            {
                Console.WriteLine(gameItempair.Key + " - " + gameItempair.Value);
            }
        }
    }
}
