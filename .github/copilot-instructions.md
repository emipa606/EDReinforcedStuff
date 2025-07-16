# GitHub Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose
This RimWorld mod aims to enhance gameplay by introducing the concept of reinforced materials through a new building, the Molecular Reinforcement Compressor. The purpose of the mod is to allow players to upgrade existing materials into more durable variants, improving both the functionality and aesthetics of player constructions.

## Key Features and Systems
- **Molecular Reinforcement Compressor Building**: A new building introduced by the mod, allowing players to convert standard materials into reinforced versions.
- **Reinforced Material System**: Upon processing materials in the Molecular Reinforcement Compressor, players will obtain reinforced variants used for crafting more durable structures and items.
- **Automation Potential**: The mod offers advanced players the potential to integrate automated processes for material reinforcement.

## Coding Patterns and Conventions
- **C# Naming Conventions**: We adhere to standard C# naming guidelines, such as PascalCase for class names and methods, and camelCase for local variables and method parameters.
- **Single Responsibility Principle**: Each class and method should have a clear purpose and be responsible for a single aspect of the mod's functionality.
- **Comments and Documentation**: Methods and complex code blocks are annotated with comments to improve readability and maintainability.

## XML Integration
The mod's item and building definitions are integrated via XML files. Ensure that XML files are well-structured and validated against RimWorld's expected schema. 
- **Defining New Items and Buildings**: XML files should define any new items, buildings, and recipes associated with the Molecular Reinforcement Compressor.
- **Localization Support**: Include translations within XML files to support multiple languages.

## Harmony Patching
We utilize the Harmony library to perform runtime modifications without altering the base game's code, ensuring compatibility with future updates.
- **Safe Patching**: Always check for null references and other potential issues within patches to prevent runtime errors.
- **Method Patching**: We typically prefix or postfix methods to change their behavior or outcomes while preserving existing functionality.

## Suggestions for Copilot
- **Implement Additional Methods**: Use Copilot to suggest optimizations or variations of existing methods, like the reinforcement logic within `TrySpawnReinforcedStuff`.
- **Generate XML Templates**: Leverage Copilot's capabilities to auto-generate XML structure templates, such as item or building definitions.
- **Harmony Patch Suggestions**: Allow Copilot to assist in syntax and structure for creating Harmony patches effectively.
- **Code Comments**: Use Copilot to help add relevant comments in less-documented parts of the codebase.
- **Automated Testing Snippets**: Encourage Copilot to generate test cases or methods for unit testing the mod's functionality.

By following these guidelines and leveraging GitHub Copilot effectively, contributors can ensure the mod is robust, extensible, and maintains excellent code quality.
