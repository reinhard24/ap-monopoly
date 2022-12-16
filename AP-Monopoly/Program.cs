// Start of game loop

using MonopolyClasses;

while (gameNotOver)
{
    
    
    
    PlayTurnCommand playerTurn = new PlayTurnCommand();
    // Roll the dice to determine the player's current position
    int diceRoll = playerTurn.RollDice();
    currentPlayer.Position += diceRoll;

    // Check if the player has passed "Go" and should collect $200
    if (currentPlayer.Position > Board.TotalSpaces)
    {
        currentPlayer.Position -= Board.TotalSpaces;
        currentPlayer.Balance += 200;
    }

    // Check if the player landed on a property and should pay rent
    Property property = Board.GetPropertyAtPosition(currentPlayer.Position);
    if (property != null && property.Owner != currentPlayer)
    {
        currentPlayer.Balance -= property.Rent;
        property.Owner.Balance += property.Rent;
    }

    // Check if the player has gone bankrupt and should be eliminated from the game
    if (currentPlayer.Balance < 0)
    {
        players.Remove(currentPlayer);
    }

    // Check if there is only one player left, in which case the game is over
    if (players.Count == 1)
    {
        gameNotOver = false;
    }

    // Move on to the next player
    currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
    currentPlayer = players[currentPlayerIndex];
}

// Announce the winner
Console.WriteLine($"{players[0].Name} has won the game!");
