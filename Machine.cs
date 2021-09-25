using System;
using System.Linq;

namespace RPSLSGAMEver3
{
    public class Machine
    {
        public  char machinePressedkey;
        public int machinePoint;
        public string machineChoosedOption = "";
        GameBoard gameBoard = new GameBoard();

        public char GetMachineInput()
        {
            Random choose = new Random();
            int chooseHelper = choose.Next(gameBoard.gameItems.Count);
            char gameDictionaryKey = gameBoard.gameItems.Keys.ElementAt(chooseHelper);
            machinePressedkey = gameDictionaryKey;

            return machinePressedkey;
        }
    }
}
