using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Warrior : Player
	{
		//Constructor for the Warrior player class
		public Warrior(string name) : base(name)
		{
			//Set the necessary stats
			_name = name;
			_role = "Warrior";
			_maxHealth = 85.00;
			_health = 85.00;
			_armor = 10.00;
			_damage = 40.00;
			_magic = 10;
			_mana = 10;
			_skillPoints = 1;
			_enraged = false;
		}

		//Unique function for the warrior's attack
        public override void Attack(Player enemy)
        {
			//Take the original damage stat
			double damage = _damage;

			//Then check if the skill condition is active
			if (_enraged == false)
            {
				//If it isn't then use the enemy's armor bonus as usual
				damage -= enemy.GetArmor() / 2;
			}
			//If the skill condition is active, then the damage won't be affected by the enemy armor
			//Make sure the damage doesn't fall below the minimum amount
			if (damage < 5)
			{
				//And if it does, then raise it to the minimum
				damage = 5;
			}
			//Make the enemy take the determined damage
			enemy.TakeDamage(this, damage);
		}

        public override bool Skill()
		{
			//Check to make sure the player has enough skill points
			if (_skillPoints <= 0)
			{
				//If not, alert them to their deficiency
				Console.WriteLine();
				Console.WriteLine("You don't have enough SP!");
				Console.ReadLine();
				return false;
			}
			//If they do
			else
			{
				Console.WriteLine();
				//Activate the skill condition
				Console.WriteLine("Feel my rage!");
				_enraged = true;
				//And deduct the used skill points
				_skillPoints--;
				Console.ReadLine();
				return true;
			}
		}

        public override void EndSkill()
        {
			//End the skill condition
			_enraged = false;
        }
    }

}