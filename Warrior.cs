using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Warrior : Player
	{
		public Warrior(string name) : base(name)
		{
			_name = name;
			_maxHealth = 100.00;
			_health = 100.00;
			_armor = 10.00;
			_damage = 40.00;
			_magic = 10;
			_skillPoints = 1;
			_enraged = false;
		}

        public override void Attack(Player enemy)
        {
			double damage = _damage;

			if (_enraged == false)
            {
				damage -= enemy.GetArmor() / 2;
			}
			if (damage < 5)
			{
				damage = 5;
			}
			enemy.TakeDamage(damage);
			Console.WriteLine();
			Console.WriteLine("You did " + damage + " damage!");
			Console.ReadLine();
			Console.Clear();
		}

        public override void Skill()
		{
			if (_skillPoints <= 0)
			{
				Console.WriteLine("You don't have enough SP!");
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine("Feel my rage!");
				_enraged = true;
				_skillPoints--;
				Console.ReadLine();
			}
		}

        public override void EndSkill()
        {
			_enraged = false;
        }
    }

}