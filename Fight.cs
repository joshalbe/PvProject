using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Fight
	{
        int _turnCount = 0;
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

            _player1.ReturnToFull();
            _player2.ReturnToFull();
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
                Console.Clear();
                _player1.PrintStats();
                _player2.PrintStats();
                Console.WriteLine();

                if (_player1 is Paladin)
                {
                    _player1.EndSkill();
                }
                else if (_player1 is Cleric && (_player1._skillTurn + 3) <= _turnCount)
                {
                    _player1.EndSkill();
                }
                else if (_player1 is Warrior && (_player1._skillTurn + 3) <= _turnCount)
                {
                    _player1.EndSkill();
                }

                Console.WriteLine(_player1._name + ", you're up! What will you do?");
                char input;
                GetInputChar(out input, "Attack", "Heal", "Skill", "Taunt");
                switch (input)
                {
                    case '1':
                        {
                            //if the enemy is a paladin and has their shield up
                            if (_player2 is Paladin && _player2._shielding == true)
                            {
                                //initiate the paladin skill
                                _player2.SkillPart2(_player1);
                            }
                            //else, attack as normal
                            else
                            {
                                _player1.Attack(_player2);
                            }
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
                            _player1._skillTurn = _turnCount;
                            break;
                        }
                    case '4':
                        {
                            _player1.Taunt(_player2);
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
                    Console.Clear();
                    _player1.PrintStats();
                    _player2.PrintStats();
                    Console.WriteLine();

                    if(_player2 is Paladin)
                    {
                        _player2.EndSkill();
                    }
                    else if(_player2 is Cleric)
                    {
                        if (_player2._skillTurn == (_turnCount + 4))
                        {
                            _player2.EndSkill();
                        }
                    }
                    else if(_player2 is Warrior)
                    {
                        if(_player2._skillTurn == (_turnCount + 2))
                        {
                            _player2.EndSkill();
                        }
                    }

                    Console.WriteLine(_player2.GetName() + ", you're up! What will you do?");
                    char input;
                    GetInputChar(out input, "Attack", "Heal", "Skill", "Taunt");
                    switch (input)
                    {
                        case '1':
                            {
                                //if the enemy is a paladin and has their shield up
                                if(_player1 is Paladin && _player1._shielding == true)
                                {
                                    //initiate the paladin skill
                                    _player1.SkillPart2(_player2);
                                }
                                //else, attack as normal
                                else
                                {
                                    _player2.Attack(_player1);
                                }
                                break;
                            }
                        case '2':
                            {
                                _player2.Heal();
                                break;
                            }
                        case '3':
                            {
                                _player2.Skill();
                                _player2._skillTurn = _turnCount;
                                break;
                            }
                        case '4':
                            {
                                _player2.Taunt(_player1);
                                break;
                            }
                    }
                }
            }
        }

        void GetInputChar(out char input, string option1, string option2, string option3, string option4)
        {
            //Initialize input
            input = ' ';
            //Loop until the player enters a valid input
            while (input != '1' && input != '2' && input != '3' && input != '4')
            {
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                Console.WriteLine("3." + option3);
                Console.WriteLine("4." + option4);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
            }
        }
    }
}