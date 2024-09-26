using System;
using System.Numerics;
using futMatchSim.Models.Tactics;

namespace futMatchSim.Models
{
	public class Team
	{
		public string name;
		public string fullName;
		public List<PlayerEntity> benchPlayers;
		public Tactic tactic; //Players in tactic

		public Team(string name, string fullName, Dictionary<PlayerEntity, TacticalOrders> players)
		{
			this.name = name;
			this.fullName = fullName;
			this.benchPlayers = new List<PlayerEntity>();
			this.tactic = createTactic(players);
		}

        internal void flipPlayersPos()
        {
			foreach(var player in this.tactic.players.Keys)
			{
				Vector3 oldPos = player.getPosition();
				player.setPosition(new Vector3(oldPos.X * -1, oldPos.Y, oldPos.Z));
			}
        }

        private Tactic createTactic(Dictionary<PlayerEntity, TacticalOrders> players)
        {
			List<PlayerEntity> benchPlayers = new List<PlayerEntity>();

			foreach(PlayerEntity player in players.Keys)
			{
				if(players.GetValueOrDefault(player)!.inBench)
				{
					benchPlayers.Add(player);
					players.Remove(player);
				}
			}

			this.benchPlayers = benchPlayers;
			return new Tactic(players, null);
        }
    }
}

