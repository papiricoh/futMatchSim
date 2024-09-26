using System;
using System.Numerics;
using futMatchSim.Models.Tactics;

public class T4_4_2 : TacticalDetail

{
	public T4_4_2() : base()
	{
		goalkeeper = new Vector3(58, 0, 0);
        defenders = new List<Vector3>
        {
            new Vector3(40, 20, 0),
            new Vector3(40, 10, 0),
            new Vector3(40, -10, 0),
            new Vector3(40, -20, 0)
        };
        midfielders = new List<Vector3>
        {
            new Vector3(30, 20, 0),
            new Vector3(30, 10, 0),
            new Vector3(30, -10, 0),
            new Vector3(30, -20, 0)
        };
        strickers = new List<Vector3>
        {
            new Vector3(10, 10, 0),
            new Vector3(10, -10, 0),
        };
    }
}

