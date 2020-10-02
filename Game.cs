using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
    class Game
    {
        //Intialize an instance of a fight
        Fight _fight;

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
            Console.WriteLine("That's all folks!");
        }

        //Initialize the choosing process, the gameover option, and the players
        bool _choosing = true;
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        
        //Function to start the game
        void StartGame()
        {
            //While the first player is still choosing their various details
            while (_choosing)
            {
                //Introduce them to the game
                Console.WriteLine("Welcome to the Battle Arena!");
                //Prompt the first player to give their name
                Console.WriteLine("Player 1, please give your name!");
                string input;
                GetInputString(out input);
                Console.Clear();
                //Then confirm their name
                Console.WriteLine(input + ", is that right?");
                char input2;
                GetInputChar(out input2, "Yes", "No");
                switch(input2)
                {
                    case '1':
                        {
                            //If they're ready to move on, intialize their player
                            Console.Clear();
                            Console.WriteLine("Alright!");
                            _player1 = new Player(input);
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
            while(_choosing)
            {
                //Prompt the first player to choose their class
                Console.WriteLine("Now, choose your combat class.");
                char input3;
                GetInputChar(out input3, "Paladin", "Warrior", "Cleric");
                switch (input3)
                {
                    case '1':
                        {
                            //If they choose the Paladin class, initalize the player as a Paladin
                            _player1 = new Paladin(_player1.GetName());
                            _choosing = false;
                            break;
                        }
                    case '2':
                        {
                            //If they choose the Warrior class, intialize the player as a Warrior
                            _player1 = new Warrior(_player1.GetName());
                            _choosing = false;
                            break;
                        }
                    case '3':
                        {
                            //If they choose the Cleric class, initialize the player as a Cleric
                            _player1 = new Cleric(_player1.GetName());
                            _choosing = false;
                            break;
                        }
                }
            }

            //Return the choosing condition to true for the second player
            _choosing = true;
            //And while they're choosing
            while (_choosing)
            {
                //Prompt the second player for their name
                Console.Clear();
                Console.WriteLine("Player 2, your turn! Please give your name.");
                string input;
                GetInputString(out input);
                Console.Clear();
                //Confirm their name
                Console.WriteLine(input + ", is that right?");
                char input2;
                GetInputChar(out input2, "Yes", "No");
                switch (input2)
                {
                    case '1':
                        {
                            //if it's right, then initialize them as a player and move on
                            Console.Clear();
                            Console.WriteLine("Alright!");
                            _player2 = new Player(input);
                            _choosing = false;
                            break;
                        }
                    case '2':
                        {
                            //If it's not correct, return them to the prompt
                            Console.Clear();
                            Console.WriteLine("Please clarify your name.");
                            break;
                        }
                }
            }
            //yet again set the choosing
            _choosing = true;
            while(_choosing)
            {
                //prompt player 2 for their class
                Console.WriteLine("Now, choose your combat class.");
                char input3;
                GetInputChar(out input3, "Paladin", "Warrior", "Cleric");
                switch (input3)
                {
                    case '1':
                        {
                            //Initialize the player as a Paladin and signify that they're done choosing
                            _player2 = new Paladin(_player2.GetName());
                            _choosing = false;
                            break;
                        }
                    case '2':
                        {
                            //Initialize the player as a Warrior and signify that they're done choosing
                            _player2 = new Warrior(_player2.GetName());
                            _choosing = false;
                            break;
                        }
                    case '3':
                        {
                            //Initialize the player as a Cleric and signify that they're done choosing
                            _player2 = new Cleric(_player2.GetName());
                            _choosing = false;
                            break;
                        }
                }
            }
            //Clear out any clutter
            Console.Clear();
        }

        //Function for the menu, or home screen
        void Menu()
        {
            //Prompt the players for a course of action
            Console.WriteLine("What would you like to do?");
            char input;
            GetInputChar(out input, "Visit the Shop", "Fight");
            switch(input)
            {
                case '1':
                    {
                        //start the shop
                        break;
                    }
                case '2':
                    {
                        //start a new fight with the players
                        _fight = new Fight(_player1, _player2);
                        _fight.StartFight();
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
    }
}
