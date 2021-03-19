using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace BiomesBunnies
{
	public class CompChocolateEggLayer : ThingComp
	{
		private float eggProgress;

		private bool Active
		{
			get
			{
				Pawn pawn = parent as Pawn;

				if (pawn != null && !pawn.ageTracker.CurLifeStage.milkable)
				{
					return false;
				}
				return true;
			}
		}

		public CompProperties_ChocolateEggLayer Props => (CompProperties_ChocolateEggLayer)props;

		public override void PostExposeData()
		{
			base.PostExposeData();
			Scribe_Values.Look(ref eggProgress, "eggProgress", 0f);
		}

		public override void CompTick()
		{
			if (Active)
			{
				float num = 1f / (Props.eggLayIntervalDays * 60000f);
				Pawn pawn = parent as Pawn;
				if (pawn != null)
				{
					num *= PawnUtility.BodyResourceGrowthSpeed(pawn);
				}
				eggProgress += num;
				if (eggProgress > 1f)
				{
					eggProgress = 1f;
					if (pawn.Awake() && !pawn.Downed)
                    {
						ProduceEgg(pawn);
						eggProgress = 0f;
                    }
				}
			}
		}


		public void ProduceEgg(Pawn pawn)
		{
			if (!Active)
			{
				Log.Error("LayEgg while not Active: " + parent);
			}
			eggProgress = 0f;
			Thing egg;
			int randomInRange = Props.eggCountRange.RandomInRange;
			if (randomInRange == 0)
			{
				egg = null;
			}

			egg = ThingMaker.MakeThing(Props.eggDef);
			egg.stackCount = randomInRange;

			GenSpawn.Spawn(egg, pawn.Position, pawn.Map).SetForbiddenIfOutsideHomeArea();
		}

		public override string CompInspectStringExtra()
		{
			if (!Active)
			{
				return null;
			}
			string text = "EggProgress".Translate() + ": " + eggProgress.ToStringPercent();

			return text;
		}
	}
}
