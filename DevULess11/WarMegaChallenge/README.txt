This code is still in progress. 

Need to refactor the helper methods for cleaner code and better readability.

Still want to add:
1) Exception handling if there are not enough cards in the deck for a battle scenario
2) Option to play again with the new cards each player holds.

This code was developed as an exercise following along with the DevU lessons.

It features the card game war where:
  two players each are randomly assigned half the deck
  cards are randomly drawn from those decks (to simulate a shuffle at the beginning)
  a player wins both cards played and those are added to a win deck
  if the two cards played are the same, it starts a battle mode where,
    each player draws three cards, and the last of those cards is compared
    all cards drawn go to the winner of that comparison
    if those cards match, the process of a battle repeats
  at the end of the deck, a winner is declared based on total cards won
