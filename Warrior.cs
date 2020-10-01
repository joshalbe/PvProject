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
		}
	}

}