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
        

        public char GetPlayerInput(in GameContent gameContent, GameBoard gameBoard)
        {
            
            ReadKeyboard();
            while((!gameContent.gameMenu.ContainsKey(playerPressedkey)) && (!gameContent.gameItems.ContainsKey(playerPressedkey)))
            {
                NotifyPalyerToInvalidAction(gameBoard, gameContent);
                ReadKeyboard();
            }
            
            return playerPressedkey;
        }

        public void ReadKeyboard()
        { 
            ConsoleKeyInfo Hitkey = Console.ReadKey();
            playerPressedkey = Char.Parse(Hitkey.Key.ToString());
        }

        public void NotifyPalyerToInvalidAction(in GameBoard gameBoard, GameContent gameContent)
        {
            
            InvalidActionHelper(gameContent);
            gameBoard.WaitForUser(gameContent);
        }

        public void InvalidActionHelper(in GameContent gameContent)
        {
            
            Console.Clear();
            Console.WriteLine(gameContent.playerHitValidKeyMessage);
            foreach (KeyValuePair<char, string> gameMenupair in gameContent.gameMenu)
            {
                Console.WriteLine(gameMenupair.Key + " - " + gameMenupair.Value + "\n");
            }
            foreach (KeyValuePair<char, string> gameItempair in gameContent.gameItems)
            {
                Console.WriteLine(gameItempair.Key + " - " + gameItempair.Value + "\n");
            }
        }
    }
}
