﻿using System;
using System.Collections.Generic;
using System.IO;
using static RPSLSGAMEver3.Machine;
using static RPSLSGAMEver3.Player;

namespace RPSLSGAMEver3
{
    public class GameBoard
    {
        public static Dictionary<char, string> gameMenu = new Dictionary<char, string>();
        public static Dictionary<char, string> gameItems = new Dictionary<char, string>();

       public static void GameCore()
        {
            LoadDictionarys();
            GameInitialize();
        }

        public static void LoadDictionarys()
        {
            gameMenu.Add('E', "Start the Game");
            gameMenu.Add('H', "Game Help");
            gameMenu.Add('B', "Back to the Menu");
            gameMenu.Add('C', "Save the Result");
            gameMenu.Add('Q', "Quit the Game");

            gameItems.Add('P', "Paper");
            gameItems.Add('S', "Scissor");
            gameItems.Add('V', "Spock");
            gameItems.Add('R', "Rock");
            gameItems.Add('L', "Lizard");
        }

        public static void GameInitialize()
        {
            Console.Clear();
            Console.Title = "RPSLS GAME";
            Console.WriteLine("Welcome to the RPSLS Game\n" + "Rock, Paper, Scissor, Lizard, Spock\n"
                + "If you need to read the game rules hit the H key\n"
                + "Hit the E key to start the game or hit the Q key to quit the game\n");
            WaitForUser();
            playerPressedkey = GetPlayerInput();
            MenuNavigation();
        }

        public static void WaitForUser()
        {
            Console.WriteLine("\nWait for user input: ");
            Console.Beep();
        }

        public static void CheckChoosedItems()
        {
            playerPoint = 0;
            machinePoint = 0;

            playerPressedkey = GetPlayerInput();
            machinePressedkey = GetMachineInput();

            if (playerPressedkey == machinePressedkey)
            {
                IdentitiesEqual();
                InvalidActionHelper();
                WaitForUser();
                playerPressedkey = GetPlayerInput();
                machinePressedkey = GetMachineInput();
            }

            if ((playerPressedkey == 'S' && machinePressedkey == 'P') || (playerPressedkey == 'L' && machinePressedkey == 'P')
                || (playerPressedkey == 'P' && machinePressedkey == 'R') || (playerPressedkey == 'V' && machinePressedkey == 'R')
                || (playerPressedkey == 'R' && machinePressedkey == 'L') || (playerPressedkey == 'S' && machinePressedkey == 'L')
                || (playerPressedkey == 'L' && machinePressedkey == 'V') || (playerPressedkey == 'P' && machinePressedkey == 'V')
                || (playerPressedkey == 'V' && machinePressedkey == 'S') || (playerPressedkey == 'R' && machinePressedkey == 'S'))
            {
                playerPoint++;
            }
            else
            {
                machinePoint++;
            }

            playerChoosedOption = gameItems[playerPressedkey];
            machineChoosedOption = gameItems[machinePressedkey];
        }

        public static void Game()
        {
            Console.Clear();
            Console.WriteLine("Choose an item: \n" + "Paper - P\n" + "Scissor - S\n"
                + "Rock - R\n" + "Lizard - L\n" + "Spock -V\n");
            WaitForUser();
            CheckChoosedItems();
            ShowGameResult();
            GameFinalize();
        }

        public static void IdentitiesEqual()
        {
            Console.Clear();
            Console.WriteLine("Both identities are equal\n");
        }

        public static void GameHelp()
        {
            Console.Clear();
            Console.WriteLine("The Game rules: ");
            Console.WriteLine("Scissors cuts Paper\n" + "Paper covers Rock\n" + "Rock crushes Lizard\n" + "Lizard poisons Spock\n"
                + "Spock smashes Scissors\n" + "Scissors decapitates Lizard\n" + "Lizard eats Paper\n" + "Paper disproves Spock\n"
                + "Spock vaporizes Rock\n" + "Rock crushes Scissors\n" + "\n" + "If you want to go back to the main screen hit the B key\n"
                + "If you want to quit the game hit the Q key\n");
            WaitForUser();
            playerPressedkey = GetPlayerInput();
            MenuNavigation();
        }

        public static void ShowGameResult()
        {
            Console.Clear();
            if (playerPoint > machinePoint)
            {
                Console.WriteLine("You are WIN! :)\n" + "Player point: "+ playerPoint + "\n" + "You are choosed the: " + playerChoosedOption + "\n"
                    + "The machine choosed the: " + machineChoosedOption);
            }
            else
            {
                Console.WriteLine("You are LOSE! :(\n" + "Machine point: " + machinePoint + "\n"  + "You are choosed the: " + playerChoosedOption + "\n"
                    + "The machine choosed the: " + machineChoosedOption);
            }

            Console.WriteLine("\nIf you want to save the result hit the C key\n" + "If you want to exit the game without save hit the Q key\n");
            WaitForUser();
            playerPressedkey = GetPlayerInput();
            MenuNavigation();
        }

        public static void SaveTheResult()
        {
            Console.Clear();
            Console.WriteLine("Add your name: ");
            WaitForUser();
            playerName = Console.ReadLine();
            string timestamp = DateTime.Now.ToString("MM/dd/yyyy h:mm tt\n");
            string savedresult;
            string Gameresult = "\n" + "Username: " + playerName + " \n" + "Player point: " + playerPoint + "\n" + "Choosed option by the Player: " + playerChoosedOption + "\n"
                + "Machine point: " + machinePoint + "\n" + "Choosed option by the Machine: " + machineChoosedOption + "\n";
            savedresult = "\n" + timestamp + "\n" + Gameresult;
            File.AppendAllText("GameResult.txt", savedresult);
        }

        public static void GameFinalize()
        {
            Console.Clear();
            Console.WriteLine("\n" + "If you want a new game hit the E key \n" + "If you want to quit hit the Q key\n");
            WaitForUser();
            playerPressedkey = GetPlayerInput();
            MenuNavigation();
        }

        public static void MenuNavigation()
        {
            switch (playerPressedkey)
            {
                case 'H':
                    GameHelp();
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'B':
                    GameInitialize();
                    break;
                case 'C':
                    SaveTheResult();
                    break;
                case 'E':
                    Game();
                    break;
                default:
                    break;
            }
        }

    }
}
