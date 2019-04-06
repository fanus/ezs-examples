# EZS & Examples

## Requirements
- Unity 2018.1.x or newer

## Design Rules
Specifically for C# there are a few rules that you will have to follow in order to keep the design safe from breaking as you develop your game.

### Components
- None UnityEngine's initialization/execution functions should be used. e.g. Awake, Start, Update, OnTriggerEnter, etc. Remember components mustn't contain any logic or scripts. See it as a struct.

### Systems
- No public variables. That also means no references to GameObjects in your scene. Use the "RegisterComponents" function from the examples to understand how references to components are achieved.

### Events
- They are player interactions or global events. Something that changes the state of the player's game. e.g. MoveForward, Jump, Open Menu, CloseApplication, etc.
- If we have no events, the game can still simulate itself. e.g. AI still does AI things, collisions still occur, etc.
