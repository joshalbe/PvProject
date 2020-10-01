using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Cleric : Player
	{
		public Cleric(string name) : base(name)
		{
			_name = name;
			_maxHealth = 50.00;
			_health = 50.00;
			_armor = 40.00;
			_damage = 10.00;
			_magic = 60;
			_skillPoints = 1;
			_praying = false;
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
				Console.WriteLine("Hear my prayer!");
				_praying = true;
				_skillPoints--;
				Console.ReadLine();
			}
		}

        public override void EndSkill()
        {
			_praying = false;
        }
    }

}