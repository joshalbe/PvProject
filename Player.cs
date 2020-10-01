using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Player
	{
		public string _name = "";
		protected double _maxHealth = 100.00;
		protected double _health = 100.00;
		protected double _armor = 10.00;
		protected double _damage = 1.00;
		protected int _magic = 10;
		protected int _skillPoints = 0;
		protected int _gold = 0;

		public Player(string name)
		{
			_name = name;
		}

		public void Attack(Player enemy)
        {
			double damage = _damage;
            damage -= enemy._armor / 2;
            if(damage < 5)
            {
                damage = 5;
            }
            enemy.TakeDamage(damage);
            Console.WriteLine();
            Console.WriteLine("You did " + damage + " damage!");
            Console.ReadLine();
            Console.Clear();
        }

		public void Heal() 
		{
			_health += (_magic/2);
			Console.WriteLine();
            Console.WriteLine("You healed up a bit!");
            Console.ReadLine();
            Console.Clear();
		}

		public virtual void Skill() 
		{
			Console.WriteLine();
			Console.WriteLine("You have no equipped skills!");
			Console.ReadLine();
            Console.Clear();
		}

		public virtual void Taunt(Player enemy) 
		{
			Console.WriteLine();
			Console.WriteLine(enemy._name + "'s mother was a hamster, and their father smelt of elderberries!");
			Console.ReadLine();
            Console.Clear();
		}

		public void TakeDamage(double damage) 
		{
			_health -= damage;
		}

		public void PrintStats() 
		{
			Console.WriteLine(_name + "   " + _skillPoints + "SP");
			Console.WriteLine("HP: " + _health + "/" + _maxHealth);
			Console.WriteLine("Armor: " + _armor);
			Console.WriteLine("Power: " + _damage);
			Console.WriteLine("Magic: " + _magic);
		}
		public double GetHP()
        {
			return _health;
        }

		public string GetName()
        {
			return _name;
        }

		public void ReturnToFull()
        {
			_health = _maxHealth;
        }

		public void WinReward()
        {
			_gold += 100;
        }

		public void LoseReward()
        {
			_gold += 10;
        }

		public void TieReward()
        {
			_gold += 50;
        }
	}
}
