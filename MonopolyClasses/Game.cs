using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyClasses;

// Add loop in which every turn, player changes and prompts users what to do
// Seperate all methods into Command class
// Pure game logic
// User inputs in separate class

namespace MonopolyClasses
{
    // Main Monopoly class
    public class Game
    {
        public List<Player> Players { get; set; }
        public List<Property> Properties { get; set; }
        public Player CurrentPlayer { get; set; }
        public int CurrentRoll { get; set; }
        public Property CurrentProperty { get; set; }
        public int TotalSpaces { get; set; }
        public int CurrentPlayerIndex { get; set; } = 0;


        public Game()
        {
            Players = new List<Player>();
            Properties = new List<Property>();
        }

        public void AddPlayer(string name)
        {
            Players.Add(new Player(name));
        }

        // Only for console
        public void AddProperty(string name, int price)
        {
            Properties.Add(new Property(name, price));
        }

        public Property GetPropertyAtPosition(int position)
        {
            foreach (var planet in Properties)
            {
                if (position == planet.Position)
                {
                    return CurrentProperty = planet;
                }
                else
                {
                    return CurrentProperty = null;
                }
            }
            return CurrentProperty = null;
        }

        public void PlayRound()
        {
            // Roll the dice to determine the player's move
            CurrentRoll = RollDice();

            // Advance the player's position
            CurrentPlayer.Position += CurrentRoll;

            // Check if the player landed on a property
            GetPropertyAtPosition(CurrentPlayer.Position);
            var property = CurrentProperty;
            if (property != null)
            {
                if (property.Owner == null)
                {
                    // Prompt the player to buy the property
                    Console.WriteLine($"{CurrentPlayer.Name}, do you want to buy {property.Name} for {property.Price}? (Y/N)");
                    var response = Console.ReadLine();
                    if (response == "Y")
                    {
                        CurrentPlayer.BuyProperty(property);
                        property.Owner = CurrentPlayer;
                    }
                }
                else
                {
                    // Pay rent to the property owner
                    CurrentPlayer.Money -= property.Rent;
                    property.Owner.Money += property.Rent;
                }
            }

            // Move to the next player
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
            CurrentPlayer = Players[CurrentPlayerIndex];
        }

        public int RollDice()
        {
            // Generate random numbers for the dice roll
            var random = new Random();
            var die1 = random.Next(1, 7);
            var die2 = random.Next(1, 7);

            // Return the total roll
            return die1 + die2;
        }

        public Property GetProperty;

        private CommandExecutor executor = new CommandExecutor();

        public CommandExecutor GetCommandExecutor()
        {
            return executor;
        }
    }
}
