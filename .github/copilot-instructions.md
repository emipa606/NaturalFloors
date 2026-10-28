# GitHub Copilot Instructions for NaturalFloors (Continued)

## Mod Overview and Purpose

NaturalFloors is a mod for RimWorld that provides buildable natural floors. It extends the gameplay by allowing players to interact with their environment in a more natural way. The mod introduces various features such as wells, compost bins, and the ability to create different terrains like soil, gravel, and sand.

## Key Features and Systems

### Wells
- **Placement**: Can be placed near a natural water source.
- **Functionality**: Collects water at the cost of some wood.
- **Usage**: Allows the player to lay water terrain.

### Compost Bins
- **Placement**: Can be placed anywhere.
- **Functionality**: Takes foods and corpses, turns them into compost over time.
- **Usage**: Allows the player to lay soil terrain.

### Sand
- **Acquisition**: Can be obtained from chunks at the stoneworking bench.
- **Usage**: Allows the player to lay sand terrain.

### Rock Terrain
- **Usage**: Natural tone rock terrain can be created using normal stone blocks.

## Coding Patterns and Conventions

### C# Code
- **Building_Composter.cs**: Contains the `Building_Composter` class with a `TickRare` method that handles the composting process.
- **PlaceWorker_NearWater.cs**: Contains the `PlaceWorker_NearWater` class with an `AllowsPlacing` method that checks if a well can be placed near a water source.

### XML Integration
- **Defs Directory**: Contains XML files that define various game objects such as `ThingDef`, `RecipeDef`, and `TerrainDef`.
- **Well.xml**: Defines the well building.
- **CompostBin.xml**: Defines the compost bin building.
- **Items_Resources.xml**: Defines resources like sand.
- **Recipes_Production.xml**: Defines recipes for creating terrains.
- **Terrain_Floors.xml**: Defines different floor terrains.

## Harmony Patching

Harmony patching is used to modify the behavior of existing RimWorld code without altering the original codebase. This is crucial for maintaining compatibility with future updates of RimWorld.

### Example Harmony Patch
csharp
using HarmonyLib;
using RimWorld;
using Verse;

namespace NaturalFloors
{
    [HarmonyPatch(typeof(SomeExistingClass), nameof(SomeExistingClass.SomeExistingMethod))]
    static class Patch_SomeExistingMethod
    {
        static void Postfix(ref SomeType someParameter)
        {
            // Custom behavior here
        }
    }
}


## Suggestions for Copilot

1. **XML Defs Creation**: Use Copilot to generate XML definitions for new game objects, ensuring they follow the conventions used in existing files.
2. **C# Method Implementations**: Use Copilot to generate method implementations, especially for new classes or methods that follow established patterns.
3. **Harmony Patches**: Use Copilot to scaffold Harmony patches, providing a starting point that can be customized to meet specific needs.

## Contributing

- **Issues and Support**: Use the Discord channel for error reporting and support.
- **Solutions**: If you have a solution for a problem, please post it to the GitHub repository.
- **Mod Sorting**: Use RimSort to sort your mods for optimal compatibility.

## Conclusion

NaturalFloors enhances the RimWorld experience by adding natural elements to the game. By following the coding patterns and conventions outlined here, you can contribute effectively to the mod and help create a more immersive world for players.

Feel free to reach out for support or to share your contributions!

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

