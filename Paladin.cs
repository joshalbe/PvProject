﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvProject
{
	public class Paladin : Player
	{
		public Paladin(string name)
		{
			_name = name;
			_health = 75.00;
			_armor = 45.00;
			_damage = 20.00;
			_magic = 20;
		}
	}
}