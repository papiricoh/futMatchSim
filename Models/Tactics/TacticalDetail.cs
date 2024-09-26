using System.Numerics;

namespace futMatchSim.Models.Tactics
{
    public abstract class TacticalDetail
    {
        public List<Vector3> strickers;
        public List<Vector3> midfielders;
        public List<Vector3> defenders;
        public Vector3 goalkeeper;

        public TacticalDetail()
        {
            goalkeeper = new Vector3(58, 0, 0);
            defenders = new List<Vector3>();
            midfielders = new List<Vector3>();
            strickers = new List<Vector3>();
        }

    }
}