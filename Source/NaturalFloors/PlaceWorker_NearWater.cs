using Verse;

namespace NaturalFloors;

public class PlaceWorker_NearWater : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 location, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        foreach (var current in GenRadial.RadialCellsAround(location, 5f, true))
        {
            if (current.GetTerrain(map).IsRiver || current.GetTerrain(map).IsWater ||
                current.GetTerrain(map) == TerrainDef.Named("Ice"))
            {
                return true;
            }
        }

        return "MustBeNearWaterSource".Translate();
    }
}