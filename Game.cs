using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
    class Game
    {
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
                FirstPlayerTurn(ref _health2, ref _health1);
                SecondPlayerTurn(ref _health1, ref _health2);
            }
        }

        public void End()
        {

        }

        int _health1 = 10;
        string _name1 = " ";
        int _armor1 = 1;
        int _magic1 = 1;
        int _damage1 = 3;
        string _role1 = "Player";

        int _health2 = 10;
        string _name2 = "";
        int _armor2 = 1;
        int _magic2 = 1;
        int _damage2 = 3;
        string _role2 = "Player";

        int _turnCount = 0;

        bool _choosing = true;
        bool _gameOver = false;

        
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
                string input2;
                GetInputString(out input2);
                if (input2 == "yes" || input2 == "Yes" || input2 == "YES")
                {
                    Console.Clear();
                    Console.WriteLine("Alright!");
                    _name1 = input;
                    _choosing = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please clarify your name.");
                }

                Console.WriteLine("Now, choose your combat class.");
                char input3;
                GetInputChar(out input3, "Paladin", "Warrior", "Cleric");
                switch(input3)
                {
                    case '1':
                        {
                            Paladin(ref _role1, ref _health1, ref _armor1, ref _magic1, ref _damage1);
                            break;
                        }
                    case '2':
                        {
                            Warrior(ref _role1, ref _health1, ref _armor1, ref _magic1, ref _damage1);
                            break;
                        }
                    case '3':
                        {
                            Cleric(ref _role1, ref _health1, ref _armor1, ref _magic1, ref _damage1);
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
                string input2;
                GetInputString(out input2);
                if (input2 == "yes" || input2 == "Yes" || input2 == "YES")
                {
                    Console.Clear();
                    Console.WriteLine("Alright!");
                    _name2 = input;
                    _choosing = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please clarify your name.");
                }

                Console.WriteLine("Now, choose your combat class.");
                char input3;
                GetInputChar(out input3, "Paladin", "Warrior", "Cleric");
                switch (input3)
                {
                    case '1':
                        {
                            Paladin(ref _role2, ref _health2, ref _armor2, ref _magic2, ref _damage2);
                            break;
                        }
                    case '2':
                        {
                            Warrior(ref _role2, ref _health2, ref _armor2, ref _magic2, ref _damage2);
                            break;
                        }
                    case '3':
                        {
                            Cleric(ref _role2, ref _health2, ref _armor2, ref _magic2, ref _damage2);
                            break;
                        }
                }
            }
            Console.Clear();
            Console.WriteLine(_name1 + " the " + _role1 + " vs. " + _name2 +" the " + _role2 + "! Start!");
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

        void FirstPlayerTurn(ref int enemyHP, ref int yourHP)
        {
            _turnCount++;
            if (enemyHP <= 0 && yourHP > 0)
            {
                _gameOver = true;
                Console.WriteLine(_name1 + " wins!");
            }
            else if (yourHP <= 0 && enemyHP > 0)
            {
                _gameOver = true;
                Console.WriteLine(_name2 + " wins!");
            }
            else
            {
                Console.WriteLine(_name1 + ": " + _health1 + "HP");
                Console.WriteLine(_name2 + ": " + _health2 + "HP");
                Console.WriteLine();

                Console.WriteLine(_name1 + ", you're up! What will you do?");
                char input;
                GetInputChar(out input, "Attack", "Heal", "Skill");
                switch (input)
                {
                    case '1':
                        {
                            Attack(_damage1, _armor2, ref enemyHP);
                            break;
                        }
                    case '2':
                        {
                            Heal(_magic1, ref yourHP);
                            break;
                        }
                }
            }
        }

        void SecondPlayerTurn(ref int enemyHP, ref int yourHP)
        {
            _turnCount++;
            if (!_gameOver)
            {
                if (enemyHP <= 0 && yourHP > 0)
                {
                    _gameOver = true;
                    Console.WriteLine(_name2 + " wins!");
                }
                else if (yourHP <= 0 && enemyHP > 0)
                {
                    _gameOver = true;
                    Console.WriteLine(_name1 + " wins!");
                }
                else
                {
                    Console.WriteLine(_name1 + ": " + _health1 + "HP");
                    Console.WriteLine(_name2 + ": " + _health2 + "HP");
                    Console.WriteLine();

                    Console.WriteLine(_name2 + ", you're up! What will you do?");
                    char input;
                    GetInputChar(out input, "Attack", "Heal");
                    switch (input)
                    {
                        case '1':
                            {
                                Attack(_damage2, _armor1, ref enemyHP);
                                break;
                            }
                        case '2':
                            {
                                Heal(_magic2, ref yourHP);
                                break;
                            }
                    }
                }
            }
        }

        void Attack(int damage, int enemyArmor, ref int enemyHP)
        {
            damage -= enemyArmor / 2;
            if(damage < 5)
            {
                damage = 5;
            }
            enemyHP -= damage;
            Console.WriteLine();
            Console.WriteLine("You did " + damage + " damage!");
            Console.ReadLine();
            Console.Clear();
        }

        void Heal(int magic, ref int yourHP)
        {
            yourHP += (magic/2);
            Console.WriteLine();
            Console.WriteLine("You healed up a bit!");
            Console.ReadLine();
            Console.Clear();
        }

        void Skill(string role, int yourHP, int yourArmor, int yourMagic, int yourDamage, int enemyHP, int enemyArmor, int enemyMagic, int enemyDamage)
        {
            switch(role)
            {
                case "Paladin":
                    {
                        int currentTurn = _turnCount;
                        //while(currentTurn == _turnCount || currentTurn == _turnCount + 1)
                        //{
                            //yourArmor = yourArmor * 2;
                            //Attack(yourDamage, );
                        //}
                        break;
                    }
                case "Warrior":
                    {

                        break;
                    }
                case "Cleric":
                    {
                        break;
                    }
            }
        }

        void Paladin(ref string role, ref int health, ref int armor, ref int magic, ref int damage)
        {
            role = "Paladin";
            health = 75;
            armor = 45;
            magic = 20;
            damage = 20;
        }

        void Warrior(ref string role, ref int health, ref int armor, ref int magic, ref int damage)
        {
            role = "Warrior";
            health = 100;
            armor = 10;
            magic = 10;
            damage = 40;
        }

        void Cleric(ref string role, ref int health, ref int armor, ref int magic, ref int damage)
        {
            role = "Cleric";
            health = 50;
            armor = 40;
            magic = 60;
            damage = 10;
        }
    }
}
