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
		public string _name = "";
		protected double _maxHealth = 100.00;
		protected double _health = 100.00;
		protected double _armor = 10.00;
		protected double _damage = 1.00;
		protected int _magic = 10;
		protected int _skillPoints = 0;
		protected int _gold = 0;

		public bool _shielding;
		public bool _enraged;
		public bool _praying;
		public int _skillTurn;

		public Player(string name)
		{
			_name = name;
		}

		public virtual void Attack(Player enemy)
        {
			double damage = _damage;
            damage -= enemy.GetArmor() / 2;
            if(damage < 5)
            {
                damage = 5;
            }
            enemy.TakeDamage(damage);
            Console.WriteLine();
            Console.WriteLine(_name + " did " + damage + " damage!");
            Console.ReadLine();
            Console.Clear();
        }

		public void Heal() 
		{
			double _prevHP = _health;
			_health += (_magic/2);
			if(_health > _maxHealth)
            {
				_health = _maxHealth;
            }
			double _amountHealed = _health - _prevHP;
			Console.WriteLine();
            Console.WriteLine(_name + " healed up " + _amountHealed + "!");
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

		public virtual void SkillPart2(Player enemy)
        {

        }

		public virtual void EndSkill()
        {

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

		public double GetArmor()
        {
			return _armor;
        }

		public void ReturnToFull()
        {
			_health = _maxHealth;
			_skillPoints++;
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
