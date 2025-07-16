using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace EnhancedDevelopment.ReinforcedStuff;

public class Building_MolecularReinforcementCompressor : Building
{
    private const int StuffAmountRequired = 10;

    private CompPowerTrader mPower;

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);
        mPower = GetComp<CompPowerTrader>();
    }

    public override void TickRare()
    {
        base.TickRare();
        if (mPower.PowerOn)
        {
            TrySpawnReinforcedStuff();
        }
    }

    private void TrySpawnReinforcedStuff()
    {
        var validThingStack = getValidThingStack();
        if (validThingStack == null)
        {
            return;
        }

        var reinforcedVersion = getReinforcedVersion(validThingStack);
        if (reinforcedVersion == null)
        {
            return;
        }

        validThingStack.SplitOff(StuffAmountRequired);
        var thing = ThingMaker.MakeThing(reinforcedVersion);
        GenPlace.TryPlaceThing(thing, InteractionCell, Map, ThingPlaceMode.Near);
    }

    private Thing getValidThingStack()
    {
        var list = (from c in GenAdj.CellsAdjacent8Way(this)
            where c.InBounds(Map)
            select c).ToList();
        var list2 = new List<Thing>();
        foreach (var item in list)
        {
            list2.AddRange(item.GetThingList(Map));
        }

        foreach (var item2 in list2)
        {
            if (item2.stackCount < StuffAmountRequired)
            {
                continue;
            }

            var reinforcedVersion = getReinforcedVersion(item2);
            if (reinforcedVersion != null)
            {
                return item2;
            }
        }

        return null;
    }

    private static ThingDef getReinforcedVersion(Thing sourceStuff)
    {
        if (sourceStuff.def == ThingDefOf.Silver)
        {
            return ThingDef.Named("SilverReinforced");
        }

        if (sourceStuff.def == ThingDefOf.Gold)
        {
            return ThingDef.Named("GoldReinforced");
        }

        if (sourceStuff.def == ThingDefOf.Steel)
        {
            return ThingDef.Named("SteelReinforced");
        }

        if (sourceStuff.def == ThingDefOf.Plasteel)
        {
            return ThingDef.Named("PlasteelReinforced");
        }

        if (sourceStuff.def == ThingDefOf.WoodLog)
        {
            return ThingDef.Named("WoodLogReinforced");
        }

        if (sourceStuff.def == ThingDef.Named("Uranium"))
        {
            return ThingDef.Named("UraniumReinforced");
        }

        if (sourceStuff.def == ThingDef.Named("Jade"))
        {
            return ThingDef.Named("JadeReinforced");
        }

        if (sourceStuff.def == ThingDef.Named("BlocksSandstone"))
        {
            return ThingDef.Named("BlocksSandstoneReinforced");
        }

        if (sourceStuff.def == ThingDef.Named("BlocksGranite"))
        {
            return ThingDef.Named("BlocksGraniteReinforced");
        }

        if (sourceStuff.def == ThingDef.Named("BlocksLimestone"))
        {
            return ThingDef.Named("BlocksLimestoneReinforced");
        }

        if (sourceStuff.def == ThingDef.Named("BlocksSlate"))
        {
            return ThingDef.Named("BlocksSlateReinforced");
        }

        return sourceStuff.def == ThingDef.Named("BlocksMarble") ? ThingDef.Named("BlocksMarbleReinforced") : null;
    }
}