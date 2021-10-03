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
        

        public char GetPlayerInput(in GameBoard gameBoard)
        {
            
            ReadKeyboard();
            while((!gameBoard.gameMenu.ContainsKey(playerPressedkey)) && (!gameBoard.gameItems.ContainsKey(playerPressedkey)))
            {
                NotifyPalyerToInvalidAction(gameBoard);
                ReadKeyboard();
            }
            
            return playerPressedkey;
        }

        public void ReadKeyboard()
        { 
            ConsoleKeyInfo Hitkey = Console.ReadKey();
            playerPressedkey = Char.Parse(Hitkey.Key.ToString());
        }

        public void NotifyPalyerToInvalidAction(in GameBoard gameBoard)
        {
            
            InvalidActionHelper(gameBoard);
            gameBoard.WaitForUser();
        }

        public void InvalidActionHelper(in GameBoard gameBoard)
        {
            
            Console.Clear();
            Console.WriteLine("\nPlease hit a valid key: \n");
            foreach (KeyValuePair<char, string> gameMenupair in gameBoard.gameMenu)
            {
                Console.WriteLine(gameMenupair.Key + " - " + gameMenupair.Value + "\n");
            }
            foreach (KeyValuePair<char, string> gameItempair in gameBoard.gameItems)
            {
                Console.WriteLine(gameItempair.Key + " - " + gameItempair.Value + "\n");
            }
        }
    }
}
