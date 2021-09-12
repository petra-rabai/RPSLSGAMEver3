using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPSLSGAMEver3.GameBoard;
using static RPSLSGAMEver3.Player;
using static RPSLSGAMEver3.Machine;

namespace RPSLSGAMEver3
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadDictionarys();
            GameInitialize();
            GetMachineInput();
            GetPlayerInput();
            CheckChoosedItems();
            ShowGameResult();
            SaveTheResult();
            GameFinalize();
        }
    }
}
