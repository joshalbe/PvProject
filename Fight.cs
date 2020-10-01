using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Fight
	{
        int _turnCount = 1;
        bool _fightOver = false;
        Player _player1;
        Player _player2;

		public Fight(Player player1, Player player2)
		{
            _player1 = player1;
            _player2 = player2;
        }

        public void StartFight()
        {
            while (_fightOver == false)
            {
                FirstPlayerTurn(_player2.GetHP(), _player1.GetHP());
                SecondPlayerTurn(_player1.GetHP(), _player2.GetHP());
            }

            if (_player1.GetHP() > _player2.GetHP())
            {
                _player1.WinReward();
                _player2.LoseReward();
            }
            else if (_player2.GetHP() > _player1.GetHP())
            {
                _player2.WinReward();
                _player1.LoseReward();
            }
            else
            {
                _player1.TieReward();
                _player2.TieReward();
            }
        }

        void FirstPlayerTurn(double enemyHP, double yourHP)
        {
            _turnCount++;
            if (enemyHP <= 0 && yourHP > 0)
            {
                _fightOver = true;
                Console.WriteLine(_player1._name + " wins!");
            }
            else if (yourHP <= 0 && enemyHP > 0)
            {
                _fightOver = true;
                Console.WriteLine(_player2._name + " wins!");
            }
            else
            {
                Console.WriteLine(_player1._name + ": " + _player1.GetHP() + "HP");
                Console.WriteLine(_player2._name + ": " + _player2.GetHP() + "HP");
                Console.WriteLine();

                Console.WriteLine(_player1._name + ", you're up! What will you do?");
                char input;
                GetInputChar(out input, "Attack", "Heal", "Skill");
                switch (input)
                {
                    case '1':
                        {
                            //Attack(_player1._damage, _player2._armor, ref enemyHP);
                            _player1.Attack(_player2);
                            break;
                        }
                    case '2':
                        {
                            //Heal(_player1._magic, ref yourHP);
                            _player1.Heal();
                            break;
                        }
                    case '3':
                        {
                            _player1.Skill();
                            break;
                        }
                }
            }
        }

        void SecondPlayerTurn(double enemyHP, double yourHP)
        {
            _turnCount++;
            if (!_fightOver)
            {
                if (enemyHP <= 0 && yourHP > 0)
                {
                    _fightOver = true;
                    Console.WriteLine(_player2._name + " wins!");
                }
                else if (yourHP <= 0 && enemyHP > 0)
                {
                    _fightOver = true;
                    Console.WriteLine(_player1._name + " wins!");
                }
                else
                {
                    Console.WriteLine(_player1._name + ": " + _player1.GetHP() + "HP");
                    Console.WriteLine(_player2._name + ": " + _player2.GetHP() + "HP");
                    Console.WriteLine();

                    Console.WriteLine(_player2.GetName() + ", you're up! What will you do?");
                    char input;
                    GetInputChar(out input, "Attack", "Heal", "Skill");
                    switch (input)
                    {
                        case '1':
                            {
                                //Attack(_player2._damage, _player1._armor, ref enemyHP);
                                _player2.Attack(_player1);
                                break;
                            }
                        case '2':
                            {
                                //Heal(_player2._magic, ref yourHP);
                                _player2.Heal();
                                break;
                            }
                        case '3':
                            {
                                _player2.Skill();
                                break;
                            }
                    }
                }
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