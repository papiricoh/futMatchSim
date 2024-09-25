using System.Numerics;
using futMatchSim.Models.Enums;

namespace futMatchSim.Models.Tactics
{
    public class PlayerPosition
    {
        public Vector3 position;
        public GamePosition gamePosition;

        public PlayerPosition(Vector3 pos, GamePosition gpos) //gpos as ==> gamePosition
        {
            this.position = pos;
            this.gamePosition = gpos;
        }



    }
}