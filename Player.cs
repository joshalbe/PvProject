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
		protected double _health = 100.00;
		protected double _armor = 10.00;
		protected double _damage = 1.00;
		protected int _magic = 10;

		public Player(string name)
		{
			_name = name;
		}

		public Attack(Player enemy)
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

		public virtual Skill() 
		{

		}

		public virtual Taunt() 
		{

		}

		public TakeDamage(double damage) 
		{
			_health -= damage;
		}

		public PrintStats() 
		{

		}
	}
}
