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
        public int CurrentPlayer { get; set; }
        public int CurrentRoll { get; set; }
        public Property CurrentProperty { get; set; }

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

        public void GetPropertyAtPosition(int position)
        {
            foreach (var planet in Properties)
            {
                if (position == planet.Position)
                {
                    CurrentProperty = planet;
                }
                else
                {
                    continue;
                }
            }
        }

        public void PlayRound()
        {
            // Roll the dice to determine the player's move
            CurrentRoll = RollDice();

            // Advance the player's position
            Players[CurrentPlayer].Position += CurrentRoll;

            // Check if the player landed on a property
            GetPropertyAtPosition(Players[CurrentPlayer].Position);
            var property = CurrentProperty;
            if (property != null)
            {
                if (property.Owner == null)
                {
                    // Prompt the player to buy the property
                    Console.WriteLine($"{Players[CurrentPlayer].Name}, do you want to buy {property.Name} for {property.Price}? (Y/N)");
                    var response = Console.ReadLine();
                    if (response == "Y")
                    {
                        Players[CurrentPlayer].BuyProperty(property);
                        property.Owner = Players[CurrentPlayer];
                    }
                }
                else
                {
                    // Pay rent to the property owner
                    Players[CurrentPlayer].Money -= property.Rent;
                    property.Owner.Money += property.Rent;
                }
            }

            // Move to the next player
            CurrentPlayer = (CurrentPlayer + 1) % Players.Count;
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
