using System;
using System.Linq;
using static RPSLSGAMEver3.GameBoard;

namespace RPSLSGAMEver3
{
    public static class Machine
    {
        public static  char machinePressedkey;
        public static int machinePoint;
        public static string machineChoosedOption = "";

        public static char GetMachineInput()
        {
            Random choose = new Random();
            int chooseHelper = choose.Next(gameItems.Count);
            char gameDictionaryKey = gameItems.Keys.ElementAt(chooseHelper);
            machinePressedkey = gameDictionaryKey;

            return machinePressedkey;
        }
    }
}
