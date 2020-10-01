using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Paladin : Player
	{
		public Paladin(string name) : base(name)
		{
			_name = name;
			_maxHealth = 75.00;
			_health = 75.00;
			_armor = 45.00;
			_damage = 20.00;
			_magic = 20;
			_skillPoints = 1;
			_shielding = false;
		}

        public override void Skill()
        {
			if(_skillPoints <= 0)
            {
				Console.WriteLine("You don't have enough SP!");
            }
			else
            {
				Console.WriteLine();
				Console.WriteLine("Shield up!");
				_shielding = true;
				_skillPoints--;
				Console.ReadLine();
            }
        }

        public override void SkillPart2(Player enemy)
        {
			enemy.Attack(enemy);
			Heal();
        }

        public override void EndSkill()
        {
			_shielding = false;
        }
    }
}