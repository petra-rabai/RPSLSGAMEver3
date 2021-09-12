using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPSLSGAMEver3.GameBoard;

namespace RPSLSGAMEver3
{
    public class Machine
    {
        public static  char machinePressedkey;
        public static int machinePoint = 0;
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
