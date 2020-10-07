using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Cleric : Player
	{
		//Constructor for a player Cleric
		public Cleric(string name) : base(name)
		{
			//Set all necessary stats
			_name = name;
			_role = "Cleric";
			_maxHealth = 65.00;
			_health = 65.00;
			_armor = 40.00;
			_damage = 10.00;
			_magic = 60;
			_mana = 60;
			_skillPoints = 1;
			_praying = false;
		}

		//Unique function for a Cleric's attack
        public override void Attack(Player enemy)
        {
			//Relegate the damage variable as to not alter the actual stat
			double damage = _damage;

			//if skill condition is active during the attack
			if (_praying == true)
			{
				//Reduce the enemy's armor effectiveness, and increase damage at the cost of some mana
				damage = damage + (_magic / 2);
				_mana -= 5;
				damage -= (enemy.GetArmor() / 2);
            }
			//If the skill condition's not active
			else
            {
				//Attack as normal
				damage -= enemy.GetArmor() / 2;
			}

			//if the damage falls below the minimum
			if (damage < 5)
			{
				//Relegate the damage to the minimum
				damage = 5;
			}
			//Make the enemy take the damage, and declare the amount done
			enemy.TakeDamage(this, damage);
		}

		//Unique function for a Cleric's healing
        public override void Heal()
        {
			//Check that there's enough mana to heal
			if(_mana <= 0)
            {
				//If there isn't, alert the player to it
				Console.WriteLine();
				Console.WriteLine("You don't have enough mana to heal!");
				Console.ReadLine();
			}
			//Otherwise, proceed
			else
            {
				//Determine the previous HP total
				double _prevHP = _health;

				//If the skill condition is active
				if (_praying == true)
				{
					//Consume double the mana
					_mana -= 10;
					//Heal twice as much as before
					_health += _magic;
				}
				//If the skill condition is not active
				else
				{
					//Consume mana as normal
					_mana -= 5;
					//Heal normally
					_health += (_magic / 2);
				}

				//If the healing goes over the maximum value
				if (_health > _maxHealth)
				{
					//Set the current HP value to the maximum
					_health = _maxHealth;
				}
				//Subtract the previous HP from the current and announce the amount healed
				double _amountHealed = _health - _prevHP;
				Console.WriteLine();
				Console.WriteLine(_name + " healed up " + _amountHealed + "!");
				Console.ReadLine();
				Console.Clear();
			}
		}

		//Unique function for the Cleric taking damage
        public override void TakeDamage(Player enemy, double damage)
        {
			//If skill condition is active
			if(_praying == true)
            {
				//Take less damage than normal at the cost of some mana
				damage -= (_mana / 2);
				if(damage < 5)
                {
					damage = 5;
                }
				_health -= damage;
				_mana -= 5;
            }
			//If the skill's not active
			else
            {
				//Take damage as usual
				_health -= damage;
			}
			//Announce the damage taken
			Console.WriteLine();
			Console.WriteLine(enemy.GetName() + " did " + damage + " damage!");
			Console.ReadLine();
			Console.Clear();
		}

        public override bool Skill()
		{
			//Check to make sure the player has enough skill points
			if (_skillPoints <= 0)
			{
				//If they don't have enough, let the player know
				Console.WriteLine();
				Console.WriteLine("You don't have enough SP!");
				Console.ReadLine();
				return false;
			}
			//if they have enough
			else
			{
				Console.WriteLine();
				//Activate the skill condition
				Console.WriteLine("Hear my prayer!");
				_praying = true;
				//And subtract the used skill points
				_skillPoints--;
				Console.ReadLine();
				return true;
			}
		}

        public override void EndSkill()
        {
			//End the skill condition
			_praying = false;
        }
    }

}