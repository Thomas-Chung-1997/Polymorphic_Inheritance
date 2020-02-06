Thomas Chung's Portfolio
==================================================
Polymorphic Inheritance

This project is was originally a lab in a programming class I took at NAIT.

The major aspects of programming thats are in this projects are:
- Collections
- Class and class inheritance
- Polymorphism
- Thread management

The living background is created by creating a snake like object using a
Fisher-Yates algorithm to colour the back buffer pixels. As the snake 
continues along its path it will add +16 to its specific RNG value into
the BBPixel. Theoretically if a single colored snake were to progress for
an extended amount of time it would cover the entire screen with 256 of its
RBG value. But with the other coloured snakes also active, they will 
overwrite previous RNG values that that colour does not control.

The moving spheres and square anchors are all part of a large class
heirarchy to effectively differentiate certain aspects and movements.
All under the base abstract class of Shape, FixedSquares are inanimate
shapes that most other moving shapes will be anchored too; while AniShape
and all classes deriving from it are all animated shapes. AniPoly are 
shapes that similared anchored to one place like FixedSquares but have 
the ability to rotate. AniChild and classes derived will be moved 
differently as they will be attached to a parent shape that it would move
aligned with.
