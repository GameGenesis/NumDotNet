﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NumDotNet
{
    public struct Vector2 : IReadOnlyList<float>, IEquatable<Vector2>, IFormattable
    {
        /// <summary>
        /// X component of the vector.
        /// </summary>
        public float x { get; set; }

        /// <summary>
        /// Y component of the vector.
        /// </summary>
        public float y { get; set; }

        /// <summary>
        /// Returns the squared length of this vector (Read Only).
        /// </summary>
        public float sqrMagnitude => x * x + y * y;

        /// <summary>
        /// Returns the length of this vector (Read Only).
        /// </summary>
        public float magnitude => MathF.Sqrt(sqrMagnitude);

        /// <summary>
        /// Returns this vector with a magnitude of 1 (Read Only).
        /// </summary>
        public Vector2 normalized => magnitude > Mathf.Epsilon ? new Vector2(x / magnitude, y / magnitude) : new Vector2(0, 0);

        /// <summary>
        /// Returns the vector angle in radians (Read Only).
        /// </summary>
        public float angle => MathF.Atan2(y, x);

        /// <summary>
        /// Returns the one-norm of this vector (Read Only).
        /// </summary>
        public float norm1 => (Math.Abs(x) + Math.Abs(y));

        /// <summary>
        /// Returns the max-norm of this vector (Read Only).
        /// </summary>
        public float normMax => Math.Max(Math.Abs(x), Math.Abs(y));

        /// <summary>
        /// Returns the sum of the vector components (Read Only).
        /// </summary>
        public float sum => (x + y);

        /// <summary>
        /// Returns the minimal component of this vector (Read Only).
        /// </summary>
        public float minElement => Math.Min(x, y);

        /// <summary>
        /// Returns the maximal component of this vector (Read Only).
        /// </summary>
        public float maxElement => Math.Max(x, y);

        /// <summary>
        /// Returns the number of components in this vector (Read Only).
        /// </summary>
        public int Count => 2;

        /// <summary>
        /// The smallest value that a float can have different from zero.
        /// </summary>
        public const float kEpsilon = 0.00001f;

        /// <summary>
        /// Access the x or y component using [0] or [1] respectively.
        /// </summary>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector2 index.");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector2 index.");
                }
            }
        }

        /// <summary>
        /// Constructs a new vector with given x, y values.
        /// </summary>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Constructs a new vector with given Vector2 x, y values.
        /// </summary>
        public Vector2(Vector2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        /// Constructs a new vector with given Vector3 x, y values.
        /// </summary>
        public Vector2(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        /// Constructs a new vector with given array values (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public Vector2(float[] v, int startIndex = 0)
        {
            this.x = v.Length < 1 + startIndex ? 0f : v[startIndex];
            this.y = v.Length < 2 + startIndex ? 0f : v[startIndex + 1];
        }

        /// <summary>
        /// Constructs a new vector with given IEnumerable values (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public Vector2(IEnumerable<float> v, int startIndex = 0) : this(v.ToArray(), startIndex) { }

        /// <summary>
        /// Set x and y components of an existing Vector2.
        /// </summary>
        public void Set(float newX, float newY)
        {
            x = newX;
            y = newY;
        }

        /// <summary>
        /// Makes this vector have a magnitude of 1.
        /// </summary>
        public void Normalize()
        {
            if (magnitude > kEpsilon)
                Set(x / magnitude, y / magnitude);
            else
                Set(0, 0);
        }

        /// <summary>
        /// Returns true if the given vector is exactly equal to this vector.
        /// </summary>
        public bool Equals(Vector2 other)
        {
            return (x == other.x) && (y == other.y);
        }

        /// <summary>
        /// Returns true if the given object is exactly equal to this vector.
        /// </summary>
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || !GetType().Equals(obj.GetType()))
                return false;
            else
                return Equals((Vector2)obj);
        }

        /// <summary>
        /// Returns a hash code for the current object.
        /// Allows a Vector2 to be used as a key in hash tables.
        /// </summary>
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2);
        }

        public override string ToString()
        {
            return ToString(null, CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Returns a formatted string for this vector.
        /// </summary>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Returns a formatted string for this vector.
        /// </summary>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }

        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        public IEnumerator<float> GetEnumerator()
        {
            yield return x;
            yield return y;
        }

        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns the distance between a and b.
        /// </summary>
        public static float Distance(Vector2 a, Vector2 b)
        {
            return (a - b).magnitude;
        }

        /// <summary>
        /// Dot Product of two vectors.
        /// </summary>
        public static float Dot(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        /// <summary>
        /// Returns the unsigned angle in degrees between a and b.
        /// </summary>
        public static float AngleDeg(Vector2 a, Vector2 b)
        {
            return Angle(a, b) * Mathf.RadToDeg;
        }

        /// <summary>
        /// Returns the unsigned angle in radians between a and b.
        /// </summary>
        public static float Angle(Vector2 a, Vector2 b)
        {
            return MathF.Acos((a.x * b.x + a.y * b.y) / (a.magnitude * b.magnitude));
        }

        /// <summary>
        /// Returns a copy of vector with its magnitude clamped to maxLength.
        /// </summary>
        public static Vector2 ClampMagnitude(Vector2 vector, float maxLength)
        {
            float sqrMagnitude = vector.sqrMagnitude;

            if (sqrMagnitude > maxLength * maxLength)
            {
                float magnitude = MathF.Sqrt(sqrMagnitude);
                return new Vector2((vector.x / magnitude) * maxLength, (vector.y / magnitude) * maxLength);
            }
            return vector;
        }

        /// <summary>
        /// Linearly interpolates between vectors a and b by t.
        /// The value of t is clamped between 0 and 1.
        /// </summary>
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            t = Mathf.Clamp01(t);
            return LerpUnclamped(a, b, t);
        }

        /// <summary>
        /// Linearly interpolates between vectors a and b by t.
        /// </summary>
        public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
        {
            return new Vector2(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
        }

        /// <summary>
        /// Returns a vector that is made from the largest components of two vectors.
        /// </summary>
        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            return new Vector2(Math.Max(a.x, b.x), Math.Max(a.y, b.y));
        }

        /// <summary>
        /// Returns a vector that is made from the smallest components of two vectors.
        /// </summary>
        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            return new Vector2(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
        }

        /// <summary>
        /// Multiplies two vectors component-wise.
        /// </summary>
        public static Vector2 Scale(Vector2 a, Vector2 b)
        {
            return a * b;
        }

        /// <summary>
        /// Shorthand for writing Vector2(0, 0).
        /// </summary>
        public static Vector2 zero => new Vector2(0, 0);

        /// <summary>
        /// Shorthand for writing Vector2(1, 1).
        /// </summary>
        public static Vector2 one => new Vector2(1, 1);

        /// <summary>
        /// Shorthand for writing Vector2(0, 1).
        /// </summary>
        public static Vector2 up => new Vector2(0, 1);

        /// <summary>
        /// Shorthand for writing Vector2(0, -1).
        /// </summary>
        public static Vector2 down => new Vector2(0, -1);

        /// <summary>
        /// Shorthand for writing Vector2(-1, 0).
        /// </summary>
        public static Vector2 left => new Vector2(-1, 0);

        /// <summary>
        /// Shorthand for writing Vector2(1, 0).
        /// </summary>
        public static Vector2 right => new Vector2(1, 0);

        /// <summary>
        /// Shorthand for writing Vector2(float.MinValue, float.MinValue).
        /// </summary>
        public static Vector2 minValue => new Vector2(float.MinValue, float.MinValue);

        /// <summary>
        /// Shorthand for writing Vector2(float.MaxValue, float.MaxValue).
        /// </summary>
        public static Vector2 maxValue => new Vector2(float.MaxValue, float.MaxValue);

        /// <summary>
        /// Shorthand for writing Vector2(float.NegativeInfinity, float.NegativeInfinity).
        /// </summary>
        public static Vector2 negativeInfinity => new Vector2(float.NegativeInfinity, float.PositiveInfinity);

        /// <summary>
        /// Shorthand for writing Vector2(float.PositiveInfinity, float.PositiveInfinity).
        /// </summary>
        public static Vector2 positiveInfinity => new Vector2(float.PositiveInfinity, float.PositiveInfinity);

        /// <summary>
        /// Adds two Vectors.
        /// </summary>
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);

        /// <summary>
        /// Returns a Vector.
        /// </summary>
        public static Vector2 operator +(Vector2 a) => a;

        /// <summary>
        /// Subtracts one vector from another.
        /// </summary>
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);

        /// <summary>
        /// Negates a Vector.
        /// </summary>
        public static Vector2 operator -(Vector2 a) => new Vector2(-a.x, -a.y);

        /// <summary>
        /// Multiplies a vector by a number.
        /// </summary>
        public static Vector2 operator *(Vector2 a, float d) => new Vector2(a.x * d, a.y * d);

        /// <summary>
        /// Multiplies a vector by a number.
        /// </summary>
        public static Vector2 operator *(float d, Vector2 a) => new Vector2(a.x * d, a.y * d);

        /// <summary>
        /// Multiplies a vector by another vector.
        /// </summary>
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);

        /// <summary>
        /// Divides a vector by a number.
        /// </summary>
        public static Vector2 operator /(Vector2 a, float d) => d != 0 ? new Vector2(a.x / d, a.y / d) : throw new DivideByZeroException();

        /// <summary>
        /// Divides a vector by another vector.
        /// </summary>
        public static Vector2 operator /(Vector2 a, Vector2 b) => b.x != 0 && b.y != 0 ? new Vector2(a.x / b.x, a.y / b.y) : throw new DivideByZeroException();
        
        /// <summary>
        /// Returns the remainder of a vector divided by another vector.
        /// </summary>
        public static Vector2 operator %(Vector2 a, Vector2 b) => new Vector2(a.x % b.x, a.y % b.y);
        
        /// <summary>
        /// Returns the remainder of a vector divided by a number.
        /// </summary>
        public static Vector2 operator %(Vector2 a, float d) => new Vector2(a.x % d, a.y % d);
        
        /// <summary>
        /// Returns true if two vectors are approximately equal.
        /// </summary>
        public static bool operator ==(Vector2 a, Vector2 b) => Math.Abs(a.x - b.x) <= kEpsilon && Math.Abs(a.y - b.y) <= kEpsilon;
        
        /// <summary>
        /// Returns true if two vectors are not equal.
        /// </summary>
        public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);
        
        /// <summary>
        /// Converts a Vector3 to a Vector2.
        /// </summary>
        public static implicit operator Vector2(Vector3 v) => new Vector2(v.x, v.y);

        /// <summary>
        /// Converts a Vector2 to a Vector3.
        /// </summary>
        public static implicit operator Vector3(Vector2 v) => new Vector3(v.x, v.y, 0);

        /// <summary>
        /// Converts a Vector2 to a float array (explicit).
        /// </summary>
        public static explicit operator float[](Vector2 v) => new float[] { v.x, v.y };
    }
}
