using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace PvProject
{
    class Shop
    {
        Player _player1;
        Player _player2;
        Player _shopper;
        bool _shopping = true;

        Item heart = new Item("Heart", 25, 10.00, 0, 0, 0, 0, 0);
        Item sword = new Item("Sword", 25, 0, 10.00, 0, 0, 0, 0);
        Item bracer = new Item("Bracer", 25, 0, 0, 10.00, 0, 0, 0);
        Item manaFount = new Item("Mana Fount", 75, 0, 0, 0, 10, 10, 0);
        Item skillBand = new Item("Skill Band", 100, 0, 0, 0, 0, 0, 1);

        Item[] _shopInventory = new Item[5];

        public Shop(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            _shopInventory[0] = heart;
            _shopInventory[1] = sword;
            _shopInventory[2] = bracer;
            _shopInventory[3] = manaFount;
            _shopInventory[4] = skillBand;
        }

        public void Menu()
        {
            _shopping = true;
            while(_shopping)
            {
                Console.Clear();
                Console.WriteLine("Hello, welcome to the Shop! Which player is buying first?");
                char input;
                GetInputChar(out input, _player1.GetName(), _player2.GetName(), "Leave the shop");
                switch (input)
                {
                    case '1':
                        {
                            _shopper = _player1;
                            break;
                        }
                    case '2':
                        {
                            _shopper = _player2;
                            break;
                        }
                    case '3':
                        {
                            Console.Clear();
                            Console.WriteLine("Alright, come back soon!");
                            _shopping = false;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                }

                if(_shopping)
                {
                    DisplayItems(_shopInventory);
                    _shopping = false;
                }
            }
        }

        void DisplayItems(Item[] inventory)
        {
            Console.Clear();
            Console.WriteLine(_shopper.GetName() + " " + _shopper.GetGold() + "gp");
            Console.WriteLine("What'll you have?");
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + "." + inventory[i]._name + "  " + inventory[i]._value + "gp");
            }
            char input;
            GetInputChar(out input);
            switch(input)
            {
                case '1':
                    {
                        if (CheckGold(_shopper, _shopInventory[0]._value))
                        {
                            _shopper.RemoveItem(_shopper.GetItem());
                            _shopper.AddItem(_shopInventory[0]);
                        }
                        break;
                    }
                case '2':
                    {
                        if (CheckGold(_shopper, _shopInventory[1]._value))
                        {
                            _shopper.RemoveItem(_shopper.GetItem());
                            _shopper.AddItem(_shopInventory[1]);
                        }
                        break;
                    }
                case '3':
                    {
                        if (CheckGold(_shopper, _shopInventory[2]._value))
                        {
                            _shopper.RemoveItem(_shopper.GetItem());
                            _shopper.AddItem(_shopInventory[2]);
                        }
                        break;
                    }
                case '4':
                    {
                        if (CheckGold(_shopper, _shopInventory[3]._value))
                        {
                            _shopper.RemoveItem(_shopper.GetItem());
                            _shopper.AddItem(_shopInventory[3]);
                        }
                        break;
                    }
                case '5':
                    {
                        if(CheckGold(_shopper, _shopInventory[4]._value))
                        {
                            _shopper.RemoveItem(_shopper.GetItem());
                            _shopper.AddItem(_shopInventory[4]);
                        }
                        break;
                    }
            }
            Console.ReadLine();
        }

        bool CheckGold(Player shopper, int price)
        {
            if(shopper.GetGold() < price)
            {
                Console.Clear();
                Console.WriteLine("You don't have enough gold for that!");
                return false;
            }
            else
            {
                shopper.SpendGold(price);
                Console.Clear();
                Console.WriteLine("You spent " + price + " gold!");
                Console.WriteLine("Thank you for your purchase!");
                return true;
            }
        }

        void GetInputChar(out char input, string option1, string option2, string option3)
        {
            //Initialize input
            input = ' ';
            //Loop until the player enters a valid input
            while (input != '1' && input != '2' && input != '3')
            {
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                Console.WriteLine("3." + option3);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
            }
        }

        void GetInputChar(out char input)
        {
            //Initialize input
            input = ' ';
            //Loop until the player enters a valid input
            while (input != '1' && input != '2' && input != '3' && input != '4' && input != '5')
            {
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
            }
        }
    }
}

public struct Item
{
    public string _name;
    public int _value;
    public double _hpMod;
    public double _strMod;
    public double _armorMod;
    public int _manaMod;
    public int _magicMod;
    public int _skillMod;

    public Item(string name, int value, double hp, double str, double armor, int mana, int magic, int skill)
    {
        _name = name;
        _value = value;
        _hpMod = hp;
        _strMod = str;
        _armorMod = armor;
        _manaMod = mana;
        _magicMod = magic;
        _skillMod = skill;
    }
}