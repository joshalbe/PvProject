using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace PvProject
{
    class Shop
    {
        //Declare the player variables, and begin shopping process
        Player _player1;
        Player _player2;
        Player _shopper;
        bool _shopping = true;

        //Declare the items that are to be sold in the shop
        Item heart = new Item("Heart", 25, 10.00, 0, 0, 0, 0, 0);
        Item sword = new Item("Sword", 25, 0, 10.00, 0, 0, 0, 0);
        Item bracer = new Item("Bracer", 25, 0, 0, 10.00, 0, 0, 0);
        Item manaFount = new Item("Mana Fount", 75, 0, 0, 0, 10, 10, 0);
        Item skillBand = new Item("Skill Band", 100, 0, 0, 0, 0, 0, 1);

        //Declare the shop's inventory
        Item[] _shopInventory = new Item[5];

        //Shop constructor
        public Shop(Player player1, Player player2)
        {
            //Get the players in their proper variables
            _player1 = player1;
            _player2 = player2;
            //Place the items within the shop's inventory
            _shopInventory[0] = heart;
            _shopInventory[1] = sword;
            _shopInventory[2] = bracer;
            _shopInventory[3] = manaFount;
            _shopInventory[4] = skillBand;
        }

        public void Menu()
        {
            //While the player's shopping
            _shopping = true;
            while(_shopping)
            {
                //Decide who will be shopping this go around via prompt
                Console.Clear();
                Console.WriteLine("Hello, welcome to the Shop! Which player is buying?");
                char input;
                GetInputChar(out input, _player1.GetName(), _player2.GetName(), "Leave the shop");
                switch (input)
                {
                    case '1':
                        {
                            //Make Player 1 the shopper
                            _shopper = _player1;
                            break;
                        }
                    case '2':
                        {
                            //Make Player 2 the shopper
                            _shopper = _player2;
                            break;
                        }
                    case '3':
                        {
                            //For if they decide they'd rather not shop
                            Console.Clear();
                            Console.WriteLine("Alright, come back soon!");
                            _shopping = false;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                }
                //If they are indeed shopping
                if(_shopping)
                {
                    //Display their options
                    DisplayItems(_shopInventory);
                    //And stop shopping afterwards
                    _shopping = false;
                }
            }
        }

        void DisplayItems(Item[] inventory)
        {
            //Display the person shopping, as well as their budget
            Console.Clear();
            Console.WriteLine(_shopper.GetName() + " " + _shopper.GetGold() + "gp");
            //Prompt them to choose something to buy
            Console.WriteLine("What'll you have?");
            //Iterate through the items within the shop's inventory
            for(int i = 0; i < inventory.Length; i++)
            {
                //Display the item's name and price
                Console.WriteLine((i + 1) + "." + inventory[i]._name + "  " + inventory[i]._value + "gp");
            }
            //Receive input from the Player on their choice
            char input;
            GetInputChar(out input);
            switch(input)
            {
                //Depending on the selected item
                case '1':
                    {
                        //Determine the player has enough gold for the item
                        if (CheckGold(_shopper, _shopInventory[0]._value))
                        {
                            //And if they do, remove any item the player might've had before
                            _shopper.RemoveItem(_shopper.GetItem());
                            //And replace it with the new item
                            _shopper.AddItem(_shopInventory[0]);
                        }
                        break;
                    }
                case '2':
                    {
                        //Determine the player has enough gold for the item
                        if (CheckGold(_shopper, _shopInventory[1]._value))
                        {
                            //And if they do, remove any item the player might've had before
                            _shopper.RemoveItem(_shopper.GetItem());
                            //And replace it with the new item
                            _shopper.AddItem(_shopInventory[1]);
                        }
                        break;
                    }
                case '3':
                    {
                        //Determine the player has enough gold for the item
                        if (CheckGold(_shopper, _shopInventory[2]._value))
                        {
                            //And if they do, remove any item the player might've had before
                            _shopper.RemoveItem(_shopper.GetItem());
                            //And replace it with the new item
                            _shopper.AddItem(_shopInventory[2]);
                        }
                        break;
                    }
                case '4':
                    {
                        //Determine the player has enough gold for the item
                        if (CheckGold(_shopper, _shopInventory[3]._value))
                        {
                            //And if they do, remove any item the player might've had before
                            _shopper.RemoveItem(_shopper.GetItem());
                            //And replace it with the new item
                            _shopper.AddItem(_shopInventory[3]);
                        }
                        break;
                    }
                case '5':
                    {
                        //Determine the player has enough gold for the item
                        if (CheckGold(_shopper, _shopInventory[4]._value))
                        {
                            //And if they do, remove any item the player might've had before
                            _shopper.RemoveItem(_shopper.GetItem());
                            //And replace it with the new item
                            _shopper.AddItem(_shopInventory[4]);
                        }
                        break;
                    }
            }
            Console.ReadLine();
        }

        bool CheckGold(Player shopper, int price)
        {
            //See if the player has enough to buy the item
            if(shopper.GetGold() < price)
            {
                //If they don't, then alert the player
                Console.Clear();
                Console.WriteLine("You don't have enough gold for that!");
                //And return false
                return false;
            }
            else
            {
                //If they do, then allow the transaction to go through
                shopper.SpendGold(price);
                Console.Clear();
                Console.WriteLine("You spent " + price + " gold!");
                Console.WriteLine("Thank you for your purchase!");
                //And return true
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
    //Initialize all the necessary variables to make items worthwhile
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
        //Construct the items with their various values
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