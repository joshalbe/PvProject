using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Paladin : Player
	{
		//Constructor for a Player Paladin
		public Paladin(string name) : base(name)
		{
			//Set all the necessary stats
			_name = name;
			_role = "Paladin";
			_maxHealth = 75.00;
			_health = 75.00;
			_armor = 45.00;
			_damage = 20.00;
			_magic = 20;
			_mana = 20;
			_skillPoints = 1;
			_shielding = false;
		}

        public override void Skill()
        {
			//Check if there are another skill points
			if(_skillPoints <= 0)
            {
				//if not, then let the player know
				Console.WriteLine("You don't have enough SP!");
            }
			else
            {
				//If there are...
				Console.WriteLine();
				Console.WriteLine("Shield up!");
				//Set the skill condition to true
				_shielding = true;
				//and subtract the used skill points
				_skillPoints--;
				Console.ReadLine();
            }
        }

        public override void SkillPart2(Player enemy)
        {
			//If attacked during the skill, divert the enemy's attack
			enemy.Attack(enemy);
			//And heal the player
			Heal();
        }

        public override void EndSkill()
        {
			//End the skill condition
			_shielding = false;
        }
    }
}