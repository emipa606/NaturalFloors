using System;
using System.Linq;
using RimWorld;
using Verse;

namespace NaturalFloors;

public class Building_Composter : Building_Storage
{
    private readonly DamageInfo _damageInfo = new(DamageDefOf.Rotting, 1);
    private int _stackCount;

    public override void TickRare()
    {
        //List all things in cell
        var thingsInComposter = Map.thingGrid.ThingsListAt(Position);
        if (thingsInComposter.Count <= 0)
        {
            return;
        }

        //Loop over things
        foreach (var thing in thingsInComposter.ToList())
        {
            if (thing.def.category != ThingCategory.Item || thing.def.defName == "freshCompost")
            {
                continue;
            }

            if (thing.def.IsCorpse)
            {
                if (thing is not Corpse corpse)
                {
                    throw new InvalidOperationException(
                        $"Unable to cast {thing.Label} to a corpse. Something went wrong");
                }

                if (corpse.InnerPawn.def.race.Animal || corpse.InnerPawn.def.race.Humanlike)
                {
                    thing.TakeDamage(_damageInfo);
                    _stackCount = 25;
                }
            }
            else
            {
                thing.TakeDamage(_damageInfo);
                _stackCount = thing.stackCount;
            }

            if (thing.HitPoints >= 10)
            {
                continue;
            }

            thing.Destroy();
            var compost = ThingMaker.MakeThing(ThingDef.Named("freshCompost"));
            compost.stackCount = _stackCount;
            GenSpawn.Spawn(compost, Position, Map);
        }
    }
}