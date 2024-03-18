using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BiomesBunnies
{
	public class BiomeWorker_Carrotopia : BiomeWorker
	{
		public override float GetScore(Tile tile, int tileID)
		{
			if (tile.WaterCovered)
			{
				return -100f;
			}
			if (tile.rainfall < 600f)
			{
				return 0f;
			}
			if (tile.temperature < -1f)
			{
				return 0f;
			}
			if (Rand.Value < 0.995f)
			{
				return 0f;
			}

			if (tile.temperature > 20f)
			{
				if(tile.temperature < 30f && tile.rainfall > 2200f)
                {
					return 50f;
                }
				else
                {
					return 0f;
                }
			}
			
			return 50f;
		}
	}
}
