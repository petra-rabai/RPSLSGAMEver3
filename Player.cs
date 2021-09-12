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
            ReadKeyFromKeyboard();
            
            if(!gameMenu.ContainsKey(playerPressedkey))
            {
                GameMenu();
                ReadKeyFromKeyboard();
            }
            else
            {
                switch (playerPressedkey)
                {
                    case 'H':
                        GameHelp();
                        GetPlayerInput();
                        break;
                    case 'Q':
                        Environment.Exit(0);
                        break;
                    case 'B':
                        GameInitialize();
                        GetPlayerInput();
                        break;
                    case 'E':
                        GameStart();
                        ReadKeyFromKeyboard();
                        break;
                    default:
                        break;
                }
            }

            //if (!gameItems.ContainsKey(playerPressedkey))
            //{
            //    GameStart();
            //    ReadKeyFromKeyboard();
            //}

            return playerPressedkey;
        }

        public static char ReadKeyFromKeyboard()
        {
            //TODO: handle if the readkey is more than one character
            ConsoleKeyInfo Hitkey = Console.ReadKey();
            playerPressedkey = Char.Parse(Hitkey.Key.ToString());
            return playerPressedkey;
        }
        
    }
}
