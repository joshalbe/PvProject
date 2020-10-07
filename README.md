| Josh Albe |
| Introduction to C# Assessment |

##PvProject

The game is a simple text-based Player vs Player combat arena. Upon opening the game, the
first player enters their name, confirms it, then chooses one of three classes to play as.
Afterwords, the second player will do the same. Once both players have chosen their name and
class, the game opens to a menu. Here, you can Visit the Shop, Fight, Save your High Scores,
See the previous High Score or quit the game.

**The Shop**
Visiting the Shop will give the players a choice of who will do the shopping, or whether to
just leave the shop. Once a player has decided they want to shop, the various items will be
put on display. If the player has the funds to buy their item of choice, then any previous
items they had on them will be destroyed and the new one shall be equipped. Only one item
may be equipped by a player at a time. Once the player has bought an item, they will be
returned to the menu.

**Fight**
Once a fight is initiated, the players will be able to see their stats, equipped items and
combat choices. Starting with Player 1, the players can either Attack, Heal, use a class
Skill or Taunt. The first player to lose all of their HP loses. Once a player is defeated,
any equipped items will be consumed, their stats will be restored and the players will be 
sent back to the menu.

**Known Bugs**
- There is a good chance that intentionally answering incorrectly can lead to faulty 
responses.
- Clerics can go below zero mana if they heal or attack during their skill's effects. 
This is intentional.