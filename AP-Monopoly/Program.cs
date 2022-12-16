// Start of game loop

using MonopolyClasses;

bool gameNotOver = true;

while (gameNotOver)
{
    Game game = new Game();
    PlayTurnCommand playerTurn = new PlayTurnCommand();

    // Roll the dice to determine the player's current position
    int diceRoll = playerTurn.RollDice();
    game.CurrentPlayer.Position += diceRoll;

    // Check if the player has passed "Go" and should collect $200
    if (game.CurrentPlayer.Position > game.TotalSpaces)
    {
        game.CurrentPlayer.Position -= game.TotalSpaces;
        game.CurrentPlayer.Money += 200;
    }

    // Check if the player landed on a property and should pay rent
    Property property = game.GetPropertyAtPosition(game.CurrentPlayer.Position);
    if (property != null && property.Owner != game.CurrentPlayer)
    {
        game.CurrentPlayer.Money -= property.Rent;
        property.Owner.Money += property.Rent;
    }

    // Check if the player has gone bankrupt and should be eliminated from the game
    if (game.CurrentPlayer.Money < 0)
    {
        game.Players.Remove(game.CurrentPlayer);
    }

    // Check if there is only one player left, in which case the game is over
    if (game.Players.Count == 1)
    {
        gameNotOver = false;
    }

    // Move on to the next player
    game.CurrentPlayerIndex = (game.CurrentPlayerIndex + 1) % game.Players.Count;
    game.CurrentPlayer = game.Players[CurrentPlayerIndex];
}

// Announce the winner
Console.WriteLine($"{game.Players[0].Name} has won the game!");
