using System;
using System.Linq;
using Verse;
using RimWorld;
namespace NaturalFloors
{
    public class Building_Composter : Building_Storage
    {
        private readonly Thing _compost = ThingMaker.MakeThing(ThingDef.Named("freshCompost"));
        private readonly DamageInfo _damageInfo = new DamageInfo(DamageDefOf.Rotting, 1);

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
                
                if (thing.def.defName.Contains("Corpse"))
                {
                    if (!(thing is Corpse corpse))
                    {
                        throw new InvalidOperationException($"Snable to cast {thing.Label} to a corpse. Something went wrong");
                    }

                    if (corpse.InnerPawn.def.race.Animal || corpse.InnerPawn.def.race.Humanlike)
                    {
                        thing.TakeDamage(_damageInfo);
                        _compost.stackCount = 25;
                    }
                }
                else
                {
                    thing.TakeDamage(_damageInfo);
                    _compost.stackCount = thing.stackCount;
                }

                if (thing.HitPoints >= 10)
                {
                    continue;
                }

                thing.Destroy();
                GenSpawn.Spawn(_compost, Position, Map);
            }
        }
    }
}
