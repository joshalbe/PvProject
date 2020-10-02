using System;
using System.Collections.Generic;
using System.Text;

namespace PvProject
{
    class Shop
    {
        Player _player1;
        Player _player2;

        public Shop(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void Menu()
        {
            Console.WriteLine("Hello, welcome to the Shop! Which player is buying first?");
        }
    }

    public struct PowerItem
    {

    }

    public struct ArmorItem
    {

    }

    public struct ManaItem
    {

    }
}
