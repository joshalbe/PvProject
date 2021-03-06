﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PvProject
{
    class Game
    {
        //Intialize an instance of a fight, as well as the shop
        Fight _fight;
        Shop _shop;

        //Run the game
        public void Run()
        {
            //Start the game
            Start();
            //Go through the paces of the bulk of the game
            Update();
            //End the game
            End();
        }

        public void Start()
        {
            //Function to start the game
            StartGame();
        }

        public void Update()
        {
            //While the players still want to play
            while (!_gameOver)
            {
                //make sure it always returns to the menu
                Menu();
            }
        }

        public void End()
        {
            //Parting message
            Console.Clear();
            Console.WriteLine("That's all folks!");
        }

        //Initialize the choosing process, the gameover option, and the players
        bool _choosing = true;
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        int _playerCount = 0;
        
        //Function to start the game
        void StartGame()
        {
            //Initiate the players
            InitiatePlayer(ref _player1);
            InitiatePlayer(ref _player2);

            //Initialize the shop for the newly created players
            _shop = new Shop(_player1, _player2);
        }

        void InitiatePlayer(ref Player player)
        {
            //Increment the player count
            _playerCount++;

            //While the player is still choosing their various details
            while (_choosing)
            {
                //Introduce them to the game
                Console.WriteLine("Welcome to the Battle Arena!");
                //Prompt the player to give their name
                Console.WriteLine("Player " + _playerCount + ", please give your name!");
                string input;
                GetInputString(out input);
                Console.Clear();
                //Then confirm their name
                Console.WriteLine(input + ", is that right?");
                char input2;
                GetInputChar(out input2, "Yes", "No");
                switch (input2)
                {
                    case '1':
                        {
                            //If they're ready to move on, intialize their player
                            Console.Clear();
                            Console.WriteLine("Alright!");
                            player = new Player(input);
                            _choosing = false;
                            break;
                        }
                    case '2':
                        {
                            //If they made a mistake
                            Console.Clear();
                            Console.WriteLine("Please clarify your name.");
                            break;
                        }
                }
            }
            //Return the choosing condition to true for the next choice
            _choosing = true;
            //While the player is choosing their class
            while (_choosing)
            {
                //Prompt the player to choose their class
                Console.WriteLine("Now, choose your combat class.");
                char input3;
                GetInputChar(out input3, "Paladin", "Warrior", "Cleric");
                switch (input3)
                {
                    case '1':
                        {
                            //If they choose the Paladin class, initalize the player as a Paladin
                            player = new Paladin(player.GetName());
                            _choosing = false;
                            break;
                        }
                    case '2':
                        {
                            //If they choose the Warrior class, intialize the player as a Warrior
                            player = new Warrior(player.GetName());
                            _choosing = false;
                            break;
                        }
                    case '3':
                        {
                            //If they choose the Cleric class, initialize the player as a Cleric
                            player = new Cleric(player.GetName());
                            _choosing = false;
                            break;
                        }
                }
            }
            //Return the choosing condition to true for potential next players
            _choosing = true;
            //Clear out any clutter
            Console.Clear();
        }

        //Function for the menu, or home screen
        void Menu()
        {
            //Prompt the players for a course of action
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            char input;
            GetInputChar(out input, "Visit the Shop", "Fight", "Save High Score", "Previous High Score", "Exit Game");
            switch(input)
            {
                case '1':
                    {
                        //start the shop
                        _shop.Menu();
                        break;
                    }
                case '2':
                    {
                        //start a new fight with the players
                        _fight = new Fight(_player1, _player2);
                        _fight.StartFight();
                        break;
                    }
                case '3':
                    {
                        //Saves the high score of the players by writing it to a text file
                        Console.Clear();
                        Console.WriteLine("Your high score has been saved!");
                        SaveScore("HighScore.txt");
                        Console.ReadLine();
                        break;
                    }
                case '4':
                    {
                        //Loads up the previously saved high scores from the text file
                        Console.Clear();
                        Console.WriteLine("Here's the previous high score!");
                        LoadScore("HighScore.txt");
                        Console.ReadLine();
                        break;
                    }
                case '5':
                    {
                        //Ends the game
                        _gameOver = true;
                        break;
                    }
            }
        }

        void GetInputString(out string input)
        {
            //Accept a string as input for later use
            Console.Write("> ");
            input = Console.ReadLine();
        }

        void GetInputChar(out char input, string option1, string option2)
        {
            //Initialize input
            input = ' ';
            //Loop until the player enters a valid input
            while (input != '1' && input != '2')
            {
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
            }
        }

        void GetInputChar(out char input, string option1, string option2, string option3)
        {
            //Initialize input
            input = ' ';
            //Loop until the player enters a valid input
            while (input != '1' && input != '2' && input != '3')
            {
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                Console.WriteLine("3." + option3);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
            }
        }

        void GetInputChar(out char input, string option1, string option2, string option3, string option4, string option5)
        {
            //Initialize input
            input = ' ';
            //Loop until the player enters a valid input
            while (input != '1' && input != '2' && input != '3' && input != '4' && input != '5')
            {
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                Console.WriteLine("3." + option3);
                Console.WriteLine("4." + option4);
                Console.WriteLine("5." + option5);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
            }
        }

        void SaveScore(string path)
        {
            //Create a file to write data within
            StreamWriter playFile = File.CreateText(path);

            //Decide which player had the best score
            if(_player1.GetScore() > _player2.GetScore())
            {
                //If Player 1 had a higher score, record their name, class and score
                playFile.WriteLine(_player1.GetName());
                playFile.WriteLine(_player1._role);
                playFile.WriteLine(_player1.GetScore());
            }
            else if(_player2.GetScore() > _player1.GetScore())
            {
                //If Player 2 had a higher score, record their name, class and score
                playFile.WriteLine(_player2.GetName());
                playFile.WriteLine(_player2._role);
                playFile.WriteLine(_player2.GetScore());
            }
            else
            {
                //If neither came out on top, record both of their names, classes and their shared score
                playFile.WriteLine(_player1.GetName() + " and " + _player2.GetName());
                playFile.WriteLine(_player1._role + " and " + _player2._role);
                playFile.WriteLine(_player1.GetScore());
            }
            //Close the file
            playFile.Close();
        }

        bool LoadScore(string path)
        {
            //Make sure the file exists
            if(!File.Exists(path))
            {
                //And stop the process if it doesn't, while alerting the player to the issue
                Console.WriteLine("No save file has been saved yet.");
                return false;
            }

            //Create a reader to be able to retrieve the data
            StreamReader reader = File.OpenText(path);

            //Display the name, class and score of the previously saved high score
            Console.WriteLine("Name: " + reader.ReadLine());
            Console.WriteLine("Class: " + reader.ReadLine());
            Console.WriteLine("Score: " + reader.ReadLine());

            //Close the file
            reader.Close();
            return true;
        }
    }
}
