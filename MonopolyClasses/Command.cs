using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyClasses
{
    public interface ICommand
    {
        void Execute(Player player); // Or Game game
    }

    public class PlayTurnCommand : ICommand
    {
        private int spaces;

        public PlayTurnCommand()
        {

        }

        public PlayTurnCommand(int spaces)
        {
            this.spaces = spaces;
        }

        public int RollDice()
        {
            Random rand = new Random();
            int diceResult = rand.Next(0, 12);
            spaces = diceResult;
            return diceResult;
        }

        public void Execute(Player player)
        {
            //player.MovePlayer(spaces);
        }
    }

    public class EndTurnCommand : ICommand
    {
        public void Execute(Player player)
        {
            //player.EndTurn();
        }
    }

    public class BuyPropertyCommand : ICommand
    {
        private Property property;

        public BuyPropertyCommand(Property property)
        {
            this.property = property;
        }

        public void Execute(Player player)
        {
            player.BuyProperty(property);
        }
    }

    public class RentPropertyCommand : ICommand
    {
        private Property property;

        public RentPropertyCommand(Property property)
        {
            this.property = property;
        }

        public void Execute(Player player)
        {
            player.RentProperty(property);
        }
    }

    public class CommandExecutor
    {
        private List<ICommand> commands = new List<ICommand>();

        public void QueueCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void ExecuteCommands(Player player)
        {
            foreach (ICommand command in commands)
            {
                command.Execute(player);
            }
            commands.Clear();
        }
    }
}
