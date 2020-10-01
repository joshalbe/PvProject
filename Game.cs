using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
    class Game
    {
        Fight _fight;

        //Run the game
        public void Run()
        {
            Start();
            Update();
            End();
        }

        public void Start()
        {
            StartGame();
        }

        public void Update()
        {
            while (!_gameOver)
            {
                Menu();
                //_fight = new Fight(_player1, _player2);
            }
        }

        public void End()
        {
            //Console.Clear();
            Console.WriteLine("That's all folks!");
        }

        //int _health1 = 10;
        //string _name1 = " ";
        //int _armor1 = 1;
        //int _magic1 = 1;
        //int _damage1 = 3;
        //string _role1 = "Player";

        //int _health2 = 10;
        //string _name2 = "";
        //int _armor2 = 1;
        //int _magic2 = 1;
        //int _damage2 = 3;
        //string _role2 = "Player";

        int _turnCount = 0;

        bool _choosing = true;
        bool _gameOver = false;

        Player _player1;
        Player _player2;
        
        void StartGame()
        {
            while (_choosing)
            {
                Console.WriteLine("Welcome to the Battle Arena!");
                Console.WriteLine("Player 1, please give your name!");
                string input;
                GetInputString(out input);
                Console.Clear();
                Console.WriteLine(input + ", is that right?");
                char input2;
                GetInputChar(out input2, "Yes", "No");
                switch(input2)
                {
                    case '1':
                        {
                            Console.Clear();
                            Console.WriteLine("Alright!");
                            _player1 = new Player(input);
                            _choosing = false;
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            Console.WriteLine("Please clarify your name.");
                            break;
                        }
                }

                Console.WriteLine("Now, choose your combat class.");
                char input3;
                GetInputChar(out input3, "Paladin", "Warrior", "Cleric");
                switch(input3)
                {
                    case '1':
                        {
                            //Paladin(ref _role1, ref _health1, ref _armor1, ref _magic1, ref _damage1);
                            _player1 = new Paladin(_player1.GetName());
                            break;
                        }
                    case '2':
                        {
                            //Warrior(ref _role1, ref _health1, ref _armor1, ref _magic1, ref _damage1);
                            _player1 = new Warrior(_player1.GetName());
                            break;
                        }
                    case '3':
                        {
                            //Cleric(ref _role1, ref _health1, ref _armor1, ref _magic1, ref _damage1);
                            _player1 = new Cleric(_player1.GetName());
                            break;
                        }
                }
            }
            _choosing = true;
            while (_choosing)
            {
                Console.Clear();
                Console.WriteLine("Player 2, your turn! Please give your name.");
                string input;
                GetInputString(out input);
                Console.Clear();
                Console.WriteLine(input + ", is that right?");
                char input2;
                GetInputChar(out input2, "Yes", "No");
                switch (input2)
                {
                    case '1':
                        {
                            Console.Clear();
                            Console.WriteLine("Alright!");
                            _player2 = new Player(input);
                            _choosing = false;
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            Console.WriteLine("Please clarify your name.");
                            break;
                        }
                }

                Console.WriteLine("Now, choose your combat class.");
                char input3;
                GetInputChar(out input3, "Paladin", "Warrior", "Cleric");
                switch (input3)
                {
                    case '1':
                        {
                            //Paladin(ref _role2, ref _health2, ref _armor2, ref _magic2, ref _damage2);
                            _player2 = new Paladin(_player2.GetName());
                            break;
                        }
                    case '2':
                        {
                            //Warrior(ref _role2, ref _health2, ref _armor2, ref _magic2, ref _damage2);
                            _player2 = new Warrior(_player2.GetName());
                            break;
                        }
                    case '3':
                        {
                            //Cleric(ref _role2, ref _health2, ref _armor2, ref _magic2, ref _damage2);
                            _player2 = new Cleric(_player2.GetName());
                            break;
                        }
                }
            }
            Console.Clear();
            //Console.WriteLine(_name1 + " the " + _role1 + " vs. " + _name2 +" the " + _role2 + "! Start!");
        }

        void Menu()
        {
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
                        //start a new fight
                        _fight = new Fight(_player1, _player2);
                        _fight.StartFight();
                        break;
                    }
            }
        }

        void GetInputString(out string input)
        {
            input = "";
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

        

        //void Attack(int damage, int enemyArmor, ref int enemyHP)
        //{
            //damage -= enemyArmor / 2;
            //if(damage < 5)
            //{
                //damage = 5;
            //}
            //enemyHP -= damage;
            //Console.WriteLine();
            //Console.WriteLine("You did " + damage + " damage!");
            //Console.ReadLine();
            //Console.Clear();
        //}

        //void Heal(int magic, ref int yourHP)
        //{
            //yourHP += (magic/2);
            //Console.WriteLine();
            //Console.WriteLine("You healed up a bit!");
            //Console.ReadLine();
            //Console.Clear();
        //}

        //void Skill(string role, int yourHP, int yourArmor, int yourMagic, int yourDamage, int enemyHP, int enemyArmor, int enemyMagic, int enemyDamage)
        //{
            //switch(role)
            //{
                //case "Paladin":
                    //{
                        //int currentTurn = _turnCount;
                        //while(currentTurn == _turnCount || currentTurn == _turnCount + 1)
                        //{
                            //yourArmor = yourArmor * 2;
                            //Attack(yourDamage, );
                        //}
                        //break;
                    //}
                //case "Warrior":
                    //{

                        //break;
                    //}
                //case "Cleric":
                    //{
                        //break;
                    //}
            //}
        //}

    }
}
