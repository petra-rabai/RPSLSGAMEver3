using System;
using System.Linq;

namespace RPSLSGAMEver3
{
    public class Machine
    {
        public  char machinePressedkey;
        public int machinePoint;
        public string machineChoosedOption = "";

        public char GetMachineInput(in GameContent gameContent)
        {
            Random choose = new Random();
            int chooseHelper = choose.Next(gameContent.gameItems.Count);
            char gameDictionaryKey = gameContent.gameItems.Keys.ElementAt(chooseHelper);
            machinePressedkey = gameDictionaryKey;

            return machinePressedkey;
        }
    }
}
