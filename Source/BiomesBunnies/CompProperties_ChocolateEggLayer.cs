using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BiomesBunnies
{
	public class CompProperties_ChocolateEggLayer : CompProperties
	{
		public float eggLayIntervalDays = 5f;

		public IntRange eggCountRange = IntRange.one;

		public ThingDef eggDef;

		//public ThingDef eggFertilizedDef;

		//public int eggCountMax = 1;

		//public bool eggLayFemaleOnly = false;

		//public float eggProgressUnfertilizedMax = 1f;

		public CompProperties_ChocolateEggLayer()
		{
			compClass = typeof(CompChocolateEggLayer);
		}
	}
}