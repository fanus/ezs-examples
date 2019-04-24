# EZS & Examples

## Requirements
- Unity 2018.1.x or newer

## Usage
Download and import the latest release files and check out the examples:

https://github.com/fanus/ezs-unity/releases

## Developing & Deploying
EZS currently offers two DLL references. While you develop you game in Unity, you should be using the `EZS.Editor.dll` reference because it adds lots of convenient feature to develop your game. In the examples you will see that the GameObject named "EZS" uses the EZS component from this reference (highlighted in yellow and aqua).

![HowToDeployImage](https://github.com/fanus/ezs-unity/blob/master/HowToDeployImage.JPG "How To Deploy Image")

When you try deploy your game an error will occur because the `EZS.Editor.dll` reference uses Unity's `UnityEditor` namespace. To fix this you must first disable the `EZS.Editor.dll` reference and enable the `EZS.dll` reference. Then use the EZS component (highlighted in red) from the enabled reference instead.


## Designing your code
Specifically for C# there are a few rules that you will have to follow in order to keep the design maintained as you develop your game.
If you want to get low level you can read more about it here: [A Game Programming Experiment](https://medium.com/@HendrikduToit/a-game-programming-experiment-1b668cdb56b2)


### Components
- None of UnityEngine's initialization/execution functions should be used. e.g. Awake, Start, Update, OnTriggerEnter, etc. Remember components must not contain any logic or scripts. See them as structs.

### Systems
- No public variables. That also means no references to GameObjects or other components set in your scene. Use the "RegisterComponents" function from the examples to understand how to reference other components.

### Events
- They are either player interactions or global events. Something that changes the state of the player's game. e.g. MoveForward, Jump, Open Menu, CloseApplication, etc.
- You should be able to have no events but the game should still "simulate" itself. e.g. AI still does AI things, collisions still occur, etc.
