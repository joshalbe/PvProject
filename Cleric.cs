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
		}
	}

}