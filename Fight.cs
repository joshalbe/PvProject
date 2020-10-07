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
                PlayerTurn(_player1, _player2);
                PlayerTurn(_player2, _player1);
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

        void PlayerTurn(Player player, Player enemy)
        {
            //Increase the turn count
            _turnCount++;
            //Determine whether Player 2 is defeated
            if (enemy.GetHP() <= 0 && player.GetHP() > 0)
            {
                //and if they are, end the fight
                _fightOver = true;
                //and declare the victor
                Console.WriteLine(player._name + " wins!");
                Console.ReadLine();
            }
            //Determine whether Player 1 was defeated in the last round
            else if (player.GetHP() <= 0 && enemy.GetHP() > 0)
            {
                //if they were, end the fight
                _fightOver = true;
                //and declare the victor
                Console.WriteLine(enemy._name + " wins!");
                Console.ReadLine();
            }
            //If nobody's defeated, then continue the fight
            else
            {
                //Show the players' statuses
                Console.Clear();
                player.PrintStats();
                Console.WriteLine();
                enemy.PrintStats();
                Console.WriteLine();

                //Check if they're a Paladin
                if (player is Paladin)
                {
                    //And if they are, end their skill
                    player.EndSkill();
                }
                //If the player is a Cleric and 5 turns have passed
                else if (player is Cleric && (player._skillTurn + 3) <= _turnCount)
                {
                    //End their skill
                    player.EndSkill();
                }
                //if the player's a Warrior and 3 turns have passed
                else if (player is Warrior && (player._skillTurn + 3) <= _turnCount)
                {
                    //End their skill
                    player.EndSkill();
                }

                //Ask for the input from the player for their turn
                Console.WriteLine(player._name + ", you're up! What will you do?");
                char input;
                GetInputChar(out input, "Attack", "Heal", "Skill", "Taunt");
                //Depending on their choice...
                switch (input)
                {
                    case '1':
                        {
                            //if the enemy is a paladin and has their shield up
                            if (enemy is Paladin && enemy._shielding == true)
                            {
                                //initiate the paladin skill
                                enemy.SkillPart2(player);
                            }
                            //else, attack as normal
                            else
                            {
                                //Attack the enemy player
                                player.Attack(enemy);
                            }
                            break;
                        }
                    case '2':
                        {
                            //The player heals themselves
                            player.Heal();
                            break;
                        }
                    case '3':
                        {
                            //Activates the player's skill, if possible
                            if(player.Skill())
                            {
                                //Marks the turn the skill was activated
                                player._skillTurn = _turnCount;
                            }
                            else
                            {
                                //If the player doesn't have the SP, returns them to taking their turn
                                PlayerTurn(player, enemy);
                                //Ensures the turn count remains the same
                                _turnCount--;
                            }
                            break;
                        }
                    case '4':
                        {
                            //Taunts the opposing player
                            player.Taunt(enemy);
                            break;
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