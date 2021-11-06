This page provides documentation of the NumDotNet Math Library.  
For the official Microsoft C# Documentation, Visit the official website: [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/).

## Table Of Contents
* [Vectors](https://github.com/GameGenesis/NumDotNet/wiki/Documentation#vectors)

# Vectors
A Point represents a fixed position, but a Vector represents a direction and a magnitude (for example, velocity or acceleration). Thus, the endpoints of a line segment are points but their difference is a vector; that is, the direction and length of that line segment. (Microsoft Docs)
* [Vector2](https://github.com/GameGenesis/NumDotNet/wiki/Documentation#vector2)
* [Vector3](https://github.com/GameGenesis/NumDotNet/wiki/Documentation#vector3)

## Vector2
### Description
Type: `struct`  
Representation of 2D vectors and points. Represents a vector with two single-precision floating-point values.

### Static Properties
|Property         |  Description                                                                   |
|:----------------|:-------------------------------------------------------------------------------|
|down             |  Shorthand for writing Vector2(0, -1).                                         |
|left             |  Shorthand for writing Vector2(-1, 0).                                         |
|negativeInfinity |  Shorthand for writing Vector2(float.NegativeInfinity, float.NegativeInfinity).|
|one              |  Shorthand for writing Vector2(1, 1).                                          |
|positiveInfinity |  Shorthand for writing Vector2(float.PositiveInfinity, float.PositiveInfinity).|
|right            |  Shorthand for writing Vector2(1, 0).                                          |
|up               |  Shorthand for writing Vector2(0, 1).                                          |
|zero             |  Shorthand for writing Vector2(0, 0).                                          |

### Properties
|Property        |  Description                                               |
|:---------------|:-----------------------------------------------------------|
|magnitude       |  Returns the length of this vector (Read Only).            |
|normalized      |  Returns this vector with a magnitude of 1 (Read Only).    |
|sqrMagnitude    |  Returns the squared length of this vector (Read Only).    |
|this[int index] |  Access the x or y component using [0] or [1] respectively.|
|x               |  X component of the vector.                                |
|y               |  Y component of the vector.                                |

### Constructors
|Property|  Description                                                   |
|:-------|:---------------------------------------------------------------|
|Vector2 |  Constructs a new vector with given x, y values.<br/>Constructs a new vector with given Vector2 x, y values.<br/>Constructs a new vector with given Vector3 x, y values.<br/>Constructs a new vector with given array values<br/>(superfluous values are ignored, missing values are zero-filled).<br/>Constructs a new vector with given IEnumerable values<br/>(superfluous values are ignored, missing values are zero-filled).|

### Public Methods
|Property    |  Description                                                      |
|:-----------|:------------------------------------------------------------------|
|Equals      |  Returns true if the given vector is exactly equal to this vector.|
|GetHashCode |  Serves as the default hash function.                             |
|Normalize   |  Makes this vector have a magnitude of 1.                         |
|Set	     |  Set x and y components of an existing Vector2.                   |
|ToString    |  Returns a formatted string for this vector.                      |

### Static Methods
|Property       |  Description                                                                                   |
|:--------------|:-----------------------------------------------------------------------------------------------|
|Angle          |  Returns the unsigned angle in degrees between a and b.                                        |
|ClampMagnitude |  Returns a copy of vector with its magnitude clamped to maxLength.                             |
|Distance       |  Returns the distance between a and b.                                                         |
|Dot            |  Dot Product of two vectors.                                                                   |
|Lerp           |  Linearly interpolates between vectors a and b by t. The value of t is clamped between 0 and 1.|
|LerpUnclamped  |  Linearly interpolates between vectors a and b by t.                                           |
|Max            |  Returns a vector that is made from the largest components of two vectors.                     |
|Min            |  Returns a vector that is made from the smallest components of two vectors.                    |
|-MoveTowards   |  Moves a point current towards target.                                                         |
|-Perpendicular |  Returns the 2D vector perpendicular to this 2D vector. The result is always rotated 90-degrees in a counter-clockwise direction for a 2D coordinate system where the positive Y axis goes up.                                                          |
|-Reflect       |  Reflects a vector off the vector defined by a normal.                                         |
|Scale          |  Multiplies two vectors component-wise.                                                        |
|-SignedAngle   |  Returns the signed angle in degrees between from and to.                                      |
|-SmoothDamp    |  Gradually changes a vector towards a desired goal over time.                                  |

### Operators
|Property    |  Description                                                                |
|:-----------|:----------------------------------------------------------------------------|
|operator +  |  Adds two vectors.                                                          |
|operator -  |  Subtracts one vector from another.<br/>Negates a vector.                   |
|operator *  |  Multiplies a vector by a number.<br/>Multiplies a vector by another vector.|
|operator /  |  Divides a vector by a number.<br/>Divides a vector by another vector.      |
|operator == |  Returns true if two vectors are approximately equal.                       |
|operator != |  Returns true if two vectors are not equal.                                 |
|Vector2     |  Converts a Vector3 to a Vector2.                                           |
|Vector3     |  Converts a Vector2 to a Vector3.                                           |
|float[]     |  Converts a Vector2 to a float array (explicit).                            |

## Vector3
Representation of 3D vectors and points. Represents a vector with three single-precision floating-point values.
