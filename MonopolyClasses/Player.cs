using MonopolyClasses;

namespace MonopolyClasses
{
    // Class to represent a player in the game
    public class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public int Position { get; set; }
        public List<Property> Properties { get; set; }
        

        public Player(string name)
        {
            Name = name;
            Money = 1500; // Each player starts with $1500
            Properties = new List<Property>();
        }

        public void BuyProperty(Property property)
        {
            Properties.Add(property);
            Money -= property.Price;
        }

        public void RentProperty(Property property)
        {
            Money -= property.Rent;
        }
    }
}