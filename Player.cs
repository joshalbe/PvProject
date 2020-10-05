using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Player
	{
		//Initialize the Player's stats and maximums
		public string _name = "";
		public string _role = "";
		protected double _maxHealth = 100.00;
		protected double _health = 100.00;
		protected double _armor = 10.00;
		protected double _damage = 1.00;
		protected int _magic = 10;
		protected int _mana = 10;
		protected int _skillPoints = 0;
		protected int _gold = 50;
		public int _score = 0;

		//Declare the player's inventory, which is empty at first
		protected Item[] _inventory = new Item[1];

		//Initialize the conditions pertaining to specific classes
		public bool _shielding;
		public bool _enraged;
		public bool _praying;
		public int _skillTurn;

		//Constructor for the player
		public Player(string name)
		{
			//Accept input as the name
			_name = name;
		}

		//Function to attack the enemy
		public virtual void Attack(Player enemy)
        {
			//First take the damage stat as a base
			double damage = _damage;
			//Calculate it against the enemy's defense
            damage -= enemy.GetArmor() / 2;
			//If the damage is too little
            if(damage < 5)
            {
				//Make it the damage minimum
                damage = 5;
            }
			//Make the enemy take the necessary damage
            enemy.TakeDamage(this, damage);
        }

		//Function to heal the player
		public virtual void Heal() 
		{
			//Check that there's enough mana to heal
			if(_mana <= 0)
            {
				//If there isn't let the player know
				Console.Clear();
				Console.WriteLine("You don't have enough mana to heal!");
				Console.ReadLine();
            }
			//If there is, then proceed
			else
            {
				//Subtract the used mana
				_mana -= 5;
				//Mark what the HP was at before healing
				double _prevHP = _health;
				//Heal the player according to the formula
				_health += (_magic / 2);
				//If the healing would bring the player above their max health
				if (_health > _maxHealth)
				{
					//Set the HP equal to their max health
					_health = _maxHealth;
				}
				//Subtract the previous HP from the current to find out how much they healed
				double _amountHealed = _health - _prevHP;
				//Announce how much the player healed
				Console.WriteLine();
				Console.WriteLine(_name + " healed up " + _amountHealed + "!");
				Console.ReadLine();
				Console.Clear();
			}

			
		}

		//Function for the player's skill
		public virtual void Skill() 
		{
			//Classless players wouldn't have a skill, so it tells them this
			Console.WriteLine();
			Console.WriteLine("You have no equipped skills!");
			Console.ReadLine();
            Console.Clear();
		}

		//Function for the part of a skill that would activate on an enemy's turn
		public virtual void SkillPart2(Player enemy)
        {
			//Classless players don't have skills, so there's nothing that would activate here
        }

		//Function to end the Skill
		public virtual void EndSkill()
        {
			//Classless players have no skill to end, so nothing would need to end
        }

		//Function to taunt the enemy player
		public virtual void Taunt(Player enemy) 
		{
			//Declares an insult with the full knowledge that this takes their entire turn
			Console.WriteLine();
			Console.WriteLine(enemy._name + "'s mother was a hamster, and their father smelt of elderberries!");
			Console.ReadLine();
            Console.Clear();
		}

		//Function to make the player take damage
		public virtual void TakeDamage(Player enemy, double damage) 
		{
			//When hit, this subtracts the necessary damage from the player
			_health -= damage;
			//And declares how much damage they took
			Console.WriteLine();
			Console.WriteLine(enemy.GetName() + " did " + damage + " damage!");
			Console.ReadLine();
			Console.Clear();
		}

		//Fucntion to print out all of the necessary stats of the player
		public void PrintStats() 
		{
			//The stats act as a battle display to keep the players updated on their various stats
			Console.WriteLine(_name + "   " + _skillPoints + "SP");
			Console.WriteLine("(" + _inventory[0]._name + ")");
			Console.WriteLine("HP: " + _health + "/" + _maxHealth);
			Console.WriteLine("Armor: " + _armor);
			Console.WriteLine("Power: " + _damage);
			Console.WriteLine("Magic: " + _mana + "/" + _magic);
		}

		public void AddItem(Item item)
        {
			//Add the item to the player's inventory
			_inventory[0] = item;
			//Then add all of its stats to the player
			_maxHealth += item._hpMod;
			_health += item._hpMod;
			_damage += item._strMod;
			_armor += item._armorMod;
			_mana += item._manaMod;
			_magic += item._magicMod;
			_skillPoints += item._skillMod;
        }

		public void RemoveItem(Item item)
        {
			//Remove all the item's stats from the player
			_maxHealth -= item._hpMod;
			_health -= item._hpMod;
			_damage -= item._strMod;
			_armor -= item._armorMod;
			_mana -= item._manaMod;
			_magic -= item._magicMod;
			_skillPoints -= item._skillMod;
			//Then remove the item itself from the inventory
			_inventory[0] = new Item("Empty", 0, 0, 0, 0, 0, 0, 0);
        }
		public double GetHP()
        {
			//Function to return the HP value of the player
			return _health;
        }

		public string GetName()
        {
			//Function to return the name value of the player
			return _name;
        }

		public double GetArmor()
        {
			//Function to return the armor value of the player
			return _armor;
        }

		public Item GetItem()
        {
			//Return the player's equipped item
			return _inventory[0];
        }

		public int GetGold()
        {
			//Return the player's gold
			return _gold;
        }

		public void SpendGold(int price)
        {
			//Remove the gold that the player is spending
			_gold -= price;
        }

		public int GetScore()
        {
			//Return the player's score
			return _score;
        }

		public void ReturnToFull()
        {
			//Function to restore the player back to full HP, mana and skillpoints after a battle is over
			//As well as remove the player's equipped item
			RemoveItem(_inventory[0]);
			_health = _maxHealth;
			_mana = _magic;
			_skillPoints = 1;
			//Ensure the statuses are reset
			_enraged = false;
			_shielding = false;
			_praying = false;
        }

		public void WinReward()
        {
			//Upon victory, grants the winner 100 gold
			_gold += 100;
			//As well as a nice score
			_score += 300;
        }

		public void LoseReward()
        {
			//Upon defeat, grants the loser 10 gold
			_gold += 10;
			//And at least something
			_score += 100;
        }

		public void TieReward()
        {
			//Upon the code breaking and a tied result, both players gain 50 gold
			_gold += 50;
			//And a bit of score
			_score += 200;
        }
	}
}
