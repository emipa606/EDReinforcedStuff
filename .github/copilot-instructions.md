# GitHub Copilot Instructions for ED-ReinforcedStuff (Continued) Mod

## Mod Overview and Purpose

The ED-ReinforcedStuff (Continued) mod is an update to Jaxxas mod, adding reinforced versions of some materials. These reinforced materials allow for stronger constructions in RimWorld. The mod features a Molecular Reinforcement Compressor building that can be used to create reinforced versions of materials like Steel, Plasteel, Wood, Stone, Silver, Gold, Uranium, and Jade. Reinforced materials have 10 times the hitpoints but also take 10 times longer to build. The mod also includes changes to the graphics of reinforced materials to make them easily distinguishable from basic materials.

## Key Features and Systems

### Reinforced Materials
- **Reinforced Wood, Steel, Plasteel, Stone, Silver, Gold, Uranium, and Jade**: These materials are created by the Molecular Reinforcement Compressor.
- **10x Hitpoints**: Reinforced materials are significantly stronger than their non-reinforced counterparts.
- **10x Build Time**: Building with reinforced materials takes longer due to the increased strength.

### Molecular Reinforcement Compressor
- A building that allows the creation of reinforced materials.
- Requires 10 units of the material to produce one unit of reinforced material.

### Graphics Changes
- Reinforced materials have darker graphics to distinguish them from basic materials.

### Removed Features
- **Hoppers**: No longer used; reinforced materials can be placed in any adjacent storage.
- **Spawning in World**: Deep mineral patches no longer spawn reinforced materials, and they are not used as material in items.

## Coding Patterns and Conventions

### C# Coding Standards
- **Class Naming**: Use PascalCase for class names, e.g., `Building_MolecularReinforcementCompressor`.
- **Method Naming**: Use camelCase for method names, e.g., `getReinforcedVersion`.
- **Comments**: Use XML comments for methods and classes to provide clear documentation.
- **Constants**: Define constants for values that are used multiple times, e.g., the multiplier for hitpoints and build time.

### XML Conventions
- **Def Files**: Use XML files to define game entities like buildings and items.
- **Namespace**: Ensure all XML files use the correct namespace.
- **Indentation**: Use consistent indentation for readability.

## XML Integration

XML files are used to define game entities such as buildings and items. The mod includes the following XML files:

- **Buildings_MRC.xml**: Defines the Molecular Reinforcement Compressor building.
- **Items_Resource_Stuff.xml**: Defines the reinforced versions of various resources.
- **Various_Stone.xml**: Defines additional stone types.
- **About.xml**: Provides mod metadata.
- **TranslationTemplate\ThingDef\Buildings_MRC.xml**: Template for translations.

### Example XML Definition

xml
<ThingDef Name="ReinforcedSteel" ParentName="Steel" ModExtension="ReinforcedStuffExtension">
    <label>Reinforced Steel</label>
    <description>Much stronger than regular Steel, but also heavier.</description>
    <graphicData>
        <texPath>Things/Steel/ReinforcedSteel</texPath>
    </graphicData>
</ThingDef>


## Harmony Patching

Harmony patching is used to modify existing game behavior. The mod may use Harmony patches to:

- **Modify Build Times**: Increase the build time for structures using reinforced materials.
- **Adjust Hitpoints**: Increase the hitpoints of structures built with reinforced materials.
- **Handle Resource Storage**: Ensure reinforced materials can be stored in any adjacent storage.

### Example Harmony Patch

csharp
using HarmonyLib;

namespace EDReinforcedStuff
{
    [HarmonyPatch(typeof(ThingWithComps), "GetStatValue")]
    public static class ThingWithComps_GetStatValue_Patch
    {
        public static void Postfix(ref float __result, StatDef stat)
        {
            if (stat == StatDefOf.MaxHitPoints && __result > 0)
            {
                __result *= 10; // Reinforced materials have 10x hitpoints
            }
        }
    }
}


## Suggestions for Copilot

- **C# Code Completion**: Use Copilot to complete methods and classes based on the coding patterns and conventions provided.
- **XML Generation**: Use Copilot to generate XML definitions for new game entities, ensuring consistency with existing files.
- **Harmony Patching**: Use Copilot to generate Harmony patches for modifying existing game behavior, focusing on areas where reinforced materials are used.
- **Error Handling**: Use Copilot to generate error handling code for mod interactions, especially when dealing with other mods or game updates.

## Contributing

If you have any questions or need support, please use the Discord-channel for error-reporting. If you have a solution for a problem, please post it to the GitHub repository. Use RimSort to sort your mods for better compatibility.

Happy modding!

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

