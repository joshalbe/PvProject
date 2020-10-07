| Josh Albe |
| :--- |
| s208068 |
| PvProject Documentation |
| https://github.com/joshalbe/PvProject |
| Programming Class of 2022 |
| October 5, 2020 |

## I. Requirements

1. Description of Problem

  - **Name**: PvProject
  - **Problem Statement**: Check all requirements for Assessment
  - **Problem Specification**: Must be based on either Shop, PvP or text RPG


2. Input Information
- Get Input String - Players will be asked to type in their names
- Get Input Numbers - Players will be asked to select options from a list via inputting numbers

3. Output Information
- Damage when a player attacks
- Any health restored upon healing
- Activation of a skill
- Each player's stats
- Shop item options

## II. Errors

1. Once decided to shop, players must buy something or they won't be allowed to return to the previous menu

## III. Future Ideas

1. More classes 
 - Possibilities like Ranger, Rogue or Wizard
2. Leveling
 - An exp system connecting to a skill tree; aka more choices
3. More items
 - More items with different stat combos
4. Dynamic Shop
 - Randomized shop options for more replayability value
5. Dynamic Taunts
 - Randomized taunts from a list of possibilities
6. Accuracy
 - Give a possibility to miss based on a Dexterity stat
7. Campaign?
 - Story for the players to cooperate in

### Object Information


**File**: Game.cs

**Attributes**
 - Name: Run()
    Description: Has the program go through the paces of starting, updating and ending the game
    Type: public void
 - Name: Start()
    Description: Initiates the StartGame function
    Type: public void
 - Name: Update()
    Description: Keeps the game going while the game isn't over
    Type: public void
 - Name: End()
    Description: Gives a short parting message before the game closes
    Type: public void
 - Name: StartGame()
    Description: Get the player initialization started, and initialize the shop
    Type: void
 - Name: InitiatePlayer(ref Player player)
    Description: Ask the player for their name and class, and create their character based on that
    Type: void
 - Name: Menu()
    Description: Give the players a choice between the shop, fighting, saving their score or loading previous scores
    Type: void
 - Name: GetInputString(out string input)
    Description: Accept a string as input for later use
    Type: void
 - Name: GetInputChar(out char input, string option1, string option2)
    Description: List 2 options and accept a character as an answer
    Type: void
 - Name: GetInputChar(out char input, string option1, string option2, string option3)
    Description: List 3 options and accept a character as an answer
    Type: void
 - Name: GetInputChar(out char input, string option1, string option2, string option3, string option4, string option5)
    Description: List 5 options and accept a character as an answer
    Type: void
 - Name: SaveScore(string path)
    Description: Write the winning character's name, class and score to a text file for later use
    Type: void
 - Name: LoadScore(string path)
    Description: Read the saved text file (if it exists) and print out its information
    Type: bool

**File**: Shop.cs

**Attributes**
 - Name: Shop(Player player1, Player player2)
    Description: Accept two players as shoppers, and determine the shop's inventory
    Type: public constructor
 - Name: Menu()
    Description: Determine which player will shop, bring players back to the main menu, and begin display of any available items
    Type: public void
 - Name: DisplayItems(Item[] inventory)
    Description: Display the items available to purchase
    Type: void
 - Name: CheckGold(Player shopper, int price)
    Description: Ensure the player can buy the item they want, and spend the gold if they can
    Type: bool
 - Name: GetInputChar(out char input, string option1, string option2, string option3)
    Description: List 3 options and accept a character as an answer
    Type: void
 - Name: GetInputChar(out char input)
    Description: Accept a character between 1 and 5 as an input
    Type: void

**File**: Fight.cs

**Attributes**
 - Name: Fight(Player player1, Player player2)
    Description: Builds a fight with two opposing players
    Type: public constructor
 - Name: StartFight()
    Description: Initiates the players' turns, rewards them upon completion and returns them to their original state after fighting
    Type: public void
 - Name: PlayerTurn(Player player, Player enemy)
    Description: Make sure both players are still able to fight, end any needed conditions, and allow the player to attack, heal, use a skill or taunt
    Type: void
 - Name: GetInputChar(out char input, string option1, string option2, string option3, string option4)
    Description: List 4 options and accept a character as an answer
    Type: void

**File**: Player.cs

**Attributes**
 - Name: Player(string name)
    Description: Creates a new player instance with a specified name
    Type: constructor
 - Name: Attack(Player enemy)
    Description: Calculates the player's power against the enemy's armor, and makes the enemy take the appropriate damage
    Type: virtual void
 - Name: Heal()
    Description: Makes sure the player has enough mana to heal, then calculates the player's healing power and heals them by that amount
    Type: virtual void
 - Name: Skill()
    Description: Tells the player they have no equipped skills, as they aren't a specific class
    Type: virtual void
 - Name: SkillPart2(Player enemy)
    Description: An empty function as regular players wouldn't have access to this function
    Type: virtual void
 - Name: EndSkill()
    Description: Empty function, as regular players wouldn't have a skill comndition to end
    Type: virtual void
 - Name: Taunt(Player enemy)
    Description: Prints out a taunt against the enemy player
    Type: virtual void
 - Name: TakeDamage()
    Description: Makes the player take damage from an attack
    Type: virtual void
 - Name: PrintStats()
    Description: Displays the various stats of the player
    Type: void
 - Name: AddItem(Item item)
    Description: Adds an item to the player's inventory, and adds the item's various stats to the player's
    Type: void
 - Name: RemoveItem()
    Description: Subtracts the item's stats from the player's, and then replaces it in the inventory with a blank item
    Type: void
 - Name: GetHP()
    Description: Returns the player's health value
    Type: double
 - Name: GetName()
    Description: Returns the player's name string
    Type: string
 - Name: GetArmor()
    Description: Returns the player's armor value
    Type: double
 - Name: GetItem()
    Description: Returns the player's item
    Type: Item
 - Name: GetGold()
    Description: Returns the player's gold value
    Type: int
 - Name: SpendGold()
    Description: Subtracts the spent gold from the player's gold
    Type: void
 - Name: GetScore()
    Description: Returns the player's score value
    Type: int
 - Name: ReturnToFull()
    Description: Restores the inventory to default, as well as health, mana, and skill points. Any and all skill conditions become false
    Type: void
 - Name: WinReward()
    Description: Rewards the player with gold and score for winning
    Type: void
 - Name: LoseReward()
    Description: Gives the player gold and score upon losing
    Type: void
 - Name: TieReward()
    Description: Gives the player gold and score upon a tie
    Type: void

**File**: Cleric.cs

**Attributes**
 - Name: Cleric(string name)
    Description: Constructs a Player : Cleric, with the stats unique to a Cleric
    Type: constructor
 - Name: Attack(Player enemy)
    Description: Calculates the damage to the enemy Player, increasing the damage if the praying condition is active while also depleting some mana
    Type: override void
 - Name: Heal()
    Description: Makes sure the Cleric has enough mana to heal, then calculates the healing power and restores that much health. The healing is increased if the praying condition is active, but more mana is consumed
    Type: override void
 - Name: TakeDamage(Player enemy, double damage)
    Description: Calculates the damage the cleric will take, then deals it. The Cleric will take less damage if the praying condition is active at the cost of some mana
    Type: override void
 - Name: Skill()
    Description: Confirms the Cleric has the skill points to use a skill, then activates the praying condition and subtracts a skill point
    Type: override void
 - Name: EndSkill()
    Description: Ends the praying condition
    Type: override void

**File**: Paladin.cs

**Attributes**
 - Name: Paladin(string name)
    Description: Creates a Player : Paladin, with the stats unique to a Paladin
    Type: constructor
 - Name: Skill()
    Description: Confirms the Paladin has skill points available, then activates the shielding condition and subtracts a skill point
    Type: override void
 - Name: SkillPart2(Player enemy)
    Description: Makes the enemy attack itself, and heals damage from the Paladin
    Type: override void
 - Name: EndSkill()
    Description: Ends the shielding condition
    Type: override void

**File**: Warrior.cs

**Attributes**
 - Name: Warrior(string name)
    Description: Creates a Player : Warrior, with the stats unique to a Warrior
    Type: constructor
 - Name: Attack(Player enemy)
    Description: Calculates the damage to the enemy player, ignoring the enemy's armor if the Warrior has the enraged condition active
    Type: override void
 - Name: Skill()
    Description: Confirms the Warrior has skill points available, then activates the enraged condition and subtracts a skill point
    Type: override void
 - Name: EndSkill()
    Description: Ends the enraged condition
    Type: override void