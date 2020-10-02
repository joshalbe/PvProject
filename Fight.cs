using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Fight
	{
        //Counts the turns as they go
        int _turnCount = 0;
        //Determines if the fight is over
        bool _fightOver = false;
        //Initializes our players
        Player _player1;
        Player _player2;

        //Constructor for the individual fights
		public Fight(Player player1, Player player2)
		{
            _player1 = player1;
            _player2 = player2;
        }

        //Function start the fight
        public void StartFight()
        {
            //While the fight is continuing
            while (_fightOver == false)
            {
                //cycle through turns
                FirstPlayerTurn(_player2.GetHP(), _player1.GetHP());
                SecondPlayerTurn(_player1.GetHP(), _player2.GetHP());
            }

            //if Player 1 came out on top, reward them
            if (_player1.GetHP() > _player2.GetHP())
            {
                _player1.WinReward();
                _player2.LoseReward();
            }
            //if Player 2 came out on top, reward them
            else if (_player2.GetHP() > _player1.GetHP())
            {
                _player2.WinReward();
                _player1.LoseReward();
            }
            //otherwise, they both get the same amount of gold
            else
            {
                _player1.TieReward();
                _player2.TieReward();
            }

            //restore the players after they've finished their fight
            _player1.ReturnToFull();
            _player2.ReturnToFull();
        }

        //Function for Player 1's turn
        void FirstPlayerTurn(double enemyHP, double yourHP)
        {
            //Increase the turn count
            _turnCount++;
            //Determine whether Player 2 is defeated
            if (enemyHP <= 0 && yourHP > 0)
            {
                //and if they are, end the fight
                _fightOver = true;
                //and declare the victor
                Console.WriteLine(_player1._name + " wins!");
                Console.ReadLine();
            }
            //Determine whether Player 1 was defeated in the last round
            else if (yourHP <= 0 && enemyHP > 0)
            {
                //if they were, end the fight
                _fightOver = true;
                //and declare the victor
                Console.WriteLine(_player2._name + " wins!");
                Console.ReadLine();
            }
            //If nobody's defeated, then continue the fight
            else
            {
                //Show the players' statuses
                Console.Clear();
                _player1.PrintStats();
                Console.WriteLine();
                _player2.PrintStats();
                Console.WriteLine();

                //Check if they're a Paladin
                if (_player1 is Paladin)
                {
                    //And if they are, end their skill
                    _player1.EndSkill();
                }
                //If the player is a Cleric and 5 turns have passed
                else if (_player1 is Cleric && (_player1._skillTurn + 5) <= _turnCount)
                {
                    //End their skill
                    _player1.EndSkill();
                }
                //if the player's a Warrior and 3 turns have passed
                else if (_player1 is Warrior && (_player1._skillTurn + 3) <= _turnCount)
                {
                    //End their skill
                    _player1.EndSkill();
                }

                //Ask for the input from the player for their turn
                Console.WriteLine(_player1._name + ", you're up! What will you do?");
                char input;
                GetInputChar(out input, "Attack", "Heal", "Skill", "Taunt");
                //Depending on their choice...
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
                                //Attack the enemy player
                                _player1.Attack(_player2);
                            }
                            break;
                        }
                    case '2':
                        {
                            //The player heals themselves
                            _player1.Heal();
                            break;
                        }
                    case '3':
                        {
                            //Activates the player's skill
                            _player1.Skill();
                            //Marks the turn the skill was activated
                            _player1._skillTurn = _turnCount;
                            break;
                        }
                    case '4':
                        {
                            //Taunts the opposing player
                            _player1.Taunt(_player2);
                            break;
                        }
                }
            }
        }

        //Function for PLayer 2's turn
        void SecondPlayerTurn(double enemyHP, double yourHP)
        {
            //Increase the turn count
            _turnCount++;
            //Check if the fight ended already
            if (!_fightOver)
            {
                //if it didn't, then check if Player 1 was defeated
                if (enemyHP <= 0 && yourHP > 0)
                {
                    //If he was, then end the fight
                    _fightOver = true;
                    //And declare a victor
                    Console.WriteLine(_player2._name + " wins!");
                    Console.ReadLine();
                }
                //Check if Player 2 was defeated
                else if (yourHP <= 0 && enemyHP > 0)
                {
                    //If they were, then end the fight
                    _fightOver = true;
                    //and declare a victor
                    Console.WriteLine(_player1._name + " wins!");
                    Console.ReadLine();
                }
                //If nobody's beaten yet, continue on
                else
                {
                    //Show the Players' statuses
                    Console.Clear();
                    _player1.PrintStats();
                    Console.WriteLine();
                    _player2.PrintStats();
                    Console.WriteLine();

                    //If P2 is a Paladin
                    if(_player2 is Paladin)
                    {
                        //End their skill
                        _player2.EndSkill();
                    }
                    //If P2 is a Cleric and 5 turns have passed
                    else if(_player2 is Cleric && _player2._skillTurn <= (_turnCount + 5))
                    {
                        //End their skill
                        _player2.EndSkill();
                    }
                    //If P2 is a Warrior and 3 turns have passed
                    else if(_player2 is Warrior && _player2._skillTurn <= (_turnCount + 3))
                    {
                        //End their skill
                        _player2.EndSkill();
                    }

                    //Prompt the player to choose their turn action
                    Console.WriteLine(_player2.GetName() + ", you're up! What will you do?");
                    char input;
                    GetInputChar(out input, "Attack", "Heal", "Skill", "Taunt");
                    //Depending on their choice
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
                                    //Attack the enemy player
                                    _player2.Attack(_player1);
                                }
                                break;
                            }
                        case '2':
                            {
                                //Heal the Player
                                _player2.Heal();
                                break;
                            }
                        case '3':
                            {
                                //Activate the Player's skill
                                _player2.Skill();
                                //Mark the turn the skill was used
                                _player2._skillTurn = _turnCount;
                                break;
                            }
                        case '4':
                            {
                                //Taunt the opposing player
                                _player2.Taunt(_player1);
                                break;
                            }
                    }
                }
            }
        }

        //Fucntion to get input between four choices
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
                //Change the input to their choice
                input = Console.ReadKey().KeyChar;
            }
        }
    }
}