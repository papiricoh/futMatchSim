using System;

namespace futMatchSim.Models.Tactics
{
    public class Tactic
    {
        public Dictionary<PlayerEntity, TacticalOrders> players = new Dictionary<PlayerEntity, TacticalOrders>();

        public Tactic(Dictionary<PlayerEntity, TacticalOrders> players) 
        {
            this.players = players;
        }



        public void makeChange(PlayerEntity newPlayer, PlayerEntity outPlayer)
        {
            if(this.players.ContainsKey(outPlayer))
            {
                TacticalOrders to = this.players.GetValueOrDefault(outPlayer) ?? new TacticalOrders();

                this.players.Remove(outPlayer);
                this.players.Add(newPlayer, to);

                if(Program.devMode)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("(OUT) " + outPlayer.lastName + " ==> (IN) " + newPlayer.lastName);
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
        }




    }
}