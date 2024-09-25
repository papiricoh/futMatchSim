using System;
using futMatchSim.Models.Tactics;

namespace futMatchSim.Models
{
	public class Team
	{
		public string name;
		public string fullName;
		public List<PlayerEntity> benchPlayers;
		public Tactic tactic; //Players in tactic

		public Team()
		{
			this.tactic = new Tactic();
		}
	}
}

