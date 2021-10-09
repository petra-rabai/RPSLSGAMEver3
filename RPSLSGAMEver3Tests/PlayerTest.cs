using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RPSLSGAMEver3;

namespace RPSLSGAMEver3Tests
{
   public class PlayerTest
    {
        [Test]
        public void CheckNotifyPalyerToInvalidActionSuccess()
        {
            GameContent gameContent = new GameContent();
            GameBoard gameBoard = new GameBoard();
            Player player = new Player();
            player.NotifyPalyerToInvalidAction(gameBoard, gameContent);
        }
    }
}
