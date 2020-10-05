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

1. Output Information
- 

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
    Description: 
    Type: 
 - Name: Attack(Player enemy)
    Description: 
    Type: 
 - Name: Heal()
    Description: 
    Type: 
 - Name: Skill()
    Description: 
    Type: 
 - Name: SkillPart2(Player enemy)
    Description: 
    Type: 
 - Name: EndSkill()
    Description: 
    Type: 
 - Name: Taunt(Player enemy)
    Description: 
    Type: 
 - Name: TakeDamage()
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 
 - Name: 
    Description: 
    Type: 