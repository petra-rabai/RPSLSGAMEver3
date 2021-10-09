using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLSGAMEver3
{
    public class GameContent
    {
        public string gameTitle = "RPSLS GAME";
        
        public string gameWelcomeMessage = "Welcome to the RPSLS Game\n"
                                           + "Rock, Paper, Scissor, Lizard, Spock\n"
                                           + "If you need to read the game rules hit the H key\n"
                                           + "Hit the E key to start the game or hit the Q key to quit the game\n";
        
        public string waitForUserMessage = "\nWait for user input: ";

        public string playerHitValidKeyMessage = "\nPlease hit a valid key: \n";
        
        public string gameAvailableItems = "Choose an item: \n"
                                           + "Paper - P\n"
                                           + "Scissor - S\n"
                                           + "Rock - R\n"
                                           + "Lizard - L\n"
                                           + "Spock -V\n";
        
        public string identiiesEqualMessage = "Both identities are equal\n";
        
        public string gameRulesMessage = "The Game rules: \n"
                                         + "Scissors cuts Paper\n"
                                         + "Paper covers Rock\n"
                                         + "Rock crushes Lizard\n"
                                         + "Lizard poisons Spock\n"
                                         + "Spock smashes Scissors\n"
                                         + "Scissors decapitates Lizard\n"
                                         + "Lizard eats Paper\n"
                                         + "Paper disproves Spock\n"
                                         + "Spock vaporizes Rock\n"
                                         + "Rock crushes Scissors\n"
                                         + "\n"
                                         + "If you want to go back to the main screen hit the B key\n"
                                         + "If you want to quit the game hit the Q key\n";
        
        public string gameWinnerMessage = "You are WIN! :)\n" + "The winner is: ";
        
        public string gameLoseMessage = "You are LOSE! :(\n" + "The winner is: ";
        
        public string gamePlayerPointMessage = "\n" + "Player point: ";
        
        public string gameMachinePointMessage = "\n" + "Machine point: ";
        
        public string gamePlayerChoosedOptionMessage = "\n" + "You are choosed: ";
        
        public string gameMachineChoosedOtionMessage = "\n" + "The machine choosed: ";
        
        public string gameChooseSaveTheResultOrQuitMessage = "\nIf you want to save the result hit the C key\n"
                                                             + "If you want to exit the game without save hit the Q key\n";
        
        public string gameSaveResultGetPlayerNameMessage = "Add your name: ";
        
        public string timeStamp = DateTime.Now.ToString("\n MM/dd/yyyy h:mm tt\n");
        
        public string savedResult = "";
        
        public string gameResult = "";

        public string gameResultDirectory = Properties.Settings.Default.FolderPath;

        public string gameResultFullPath = "";

        public bool gameDirectoryExists;

        public string savedDataFileName = "GameResult.txt";
        
        public string playerNameMessage = "\n" + "Player name: ";
        
        public string gameFinalizeMessage = "\n"
                                            + "If you want a new game hit the E key \n"
                                            + "If you want to quit hit the Q key\n";
        
        public Dictionary<char, string> gameMenu = new Dictionary<char, string>
        {
            ['E'] = "Start the Game",
            ['H'] = "Game Help",
            ['B'] = "Back to the Menu",
            ['C'] = "Save the Result",
            ['Q'] = "Quit the Game"
        };
        
        public Dictionary<char, string> gameItems = new Dictionary<char, string>
        {
            ['P'] = "Paper",
            ['S'] = "Scissor",
            ['V'] = "Spock",
            ['R'] = "Rock",
            ['L'] = "Lizard"

        };
        
        public Tuple<string, string> compareChoosedItems;

        public Dictionary<Tuple<string, string>, string> winner = new Dictionary<Tuple<string, string>, string>();
    }
}
