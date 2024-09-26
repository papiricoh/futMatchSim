using System;
using futMatchSim.Models.Enums;

namespace futMatchSim.Models.Tactics
{
    public class Tactic
    {
        public Dictionary<PlayerEntity, TacticalOrders> players = new Dictionary<PlayerEntity, TacticalOrders>();

        private TacticalDetail? tacDetail;

        public Tactic(Dictionary<PlayerEntity, TacticalOrders> players, TacticalType? tacticalType) 
        {
            this.players = players;
            bool hasTactic = TacticalAsign.tacticsDic.TryGetValue(tacticalType ?? TacticalType.t4_4_2, out tacDetail);

            if(hasTactic)
            {
                asignPositions();
            }

        }

        private void asignPositions()
        {
            int i = 0;
            PlayerEntity[] players = this.players.Keys.ToArray();
            players[0].setPosition(tacDetail!.goalkeeper);
            i++;
            for(int k = 0; k < tacDetail!.defenders.Count; k++)
            {
                players[i++].setPosition(tacDetail!.defenders[k]);
            }
            for (int k = 0; k < tacDetail!.midfielders.Count; k++)
            {
                players[i++].setPosition(tacDetail!.midfielders[k]);
            }
            for (int k = 0; k < tacDetail!.strickers.Count; k++)
            {
                players[i++].setPosition(tacDetail!.strickers[k]);
            }
        }

        public void makeChange(PlayerEntity newPlayer, PlayerEntity outPlayer)
        {
            if(this.players.ContainsKey(outPlayer))
            {
                TacticalOrders to = this.players.GetValueOrDefault(outPlayer) ?? new TacticalOrders(false);

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