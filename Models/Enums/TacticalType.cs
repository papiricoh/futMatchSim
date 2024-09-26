using System;
using System.Numerics;
using futMatchSim.Models.Tactics;

namespace futMatchSim.Models.Enums
{
	public enum TacticalType
	{
		t4_4_2,
		t4_5_1,
		t4_3_3,
		t4_3_2_1,
		t5_4_1,
        t4_1_2_1_2
	}

	public class TacticalAsign
	{
		public static readonly Dictionary<TacticalType, TacticalDetail> tacticsDic = new Dictionary<TacticalType, TacticalDetail>
		{
			{ TacticalType.t4_4_2, new T4_4_2() }
		};
    }
}

