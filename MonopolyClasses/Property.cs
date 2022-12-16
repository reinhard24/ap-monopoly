using MonopolyClasses;

namespace MonopolyClasses
{
    // Class to represent a property in the game
    public class Property
    {
        public string Name { get; set; }
        public Player Owner { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }
        public int Position { get; set; }

        public Property(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}