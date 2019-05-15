# EZS & Examples

## Requirements
- Unity 2018.1.x or newer

## Usage
Download and import the latest release files and check out the examples:

https://github.com/fanus/ezs-unity/releases

## Documentation
(todo)

## Developing & Deploying
EZS currently offers two DLL references. While you develop your game in Unity, you should be using the `EZS.Editor.dll` reference because it adds lots of convenient feature to develop your game. The core `EZS.dll` references should always be used.

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

## Licence

MIT License
Copyright (c) 2019 Fanus

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
