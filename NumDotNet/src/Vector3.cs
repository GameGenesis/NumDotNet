using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NumDotNet
{
    public struct Vector3 : IReadOnlyList<float>, IEquatable<Vector3>, IFormattable
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
        /// Z component of the vector.
        /// </summary>
        public float z { get; set; }

        /// <summary>
        /// Returns the squared length of this vector (Read Only).
        /// </summary>
        public float sqrMagnitude => x * x + y * y + z * z;

        /// <summary>
        /// Returns the length of this vector (Read Only).
        /// </summary>
        public float magnitude => MathF.Sqrt(sqrMagnitude);

        /// <summary>
        /// Returns this vector with a magnitude of 1 (Read Only).
        /// </summary>
        public Vector3 normalized => magnitude > Mathf.Epsilon ? new Vector3(x / magnitude, y / magnitude, z / magnitude) : new Vector3(0, 0, 0);

        /// <summary>
        /// Returns the number of components in this vector (Read Only).
        /// </summary>
        public int Count => 3;

        /// <summary>
        /// Access the x, y, z components using [0], [1], [2] respectively.
        /// </summary>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index.");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index.");
                }
            }
        }

        /// <summary>
        /// Constructs a new vector with given x, y points.
        /// </summary>
        public Vector3(float x, float y) : this(x, y, 0) { }

        /// <summary>
        /// Constructs a new vector with given x, y, z components.
        /// </summary>
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Constructs a new vector with given Vector2 x, y values.
        /// </summary>
        public Vector3(Vector2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = 0;
        }

        /// <summary>
        /// Constructs a new vector with given Vector3 x, y, z values.
        /// </summary>
        public Vector3(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// Constructs a new vector with given array values (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public Vector3(float[] v, int startIndex = 0)
        {
            this.x = v.Length < 1 + startIndex ? 0f : v[startIndex];
            this.y = v.Length < 2 + startIndex ? 0f : v[startIndex + 1];
            this.z = v.Length < 3 + startIndex ? 0f : v[startIndex + 2];
        }

        /// <summary>
        /// Constructs a new vector with given IEnumerable values (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public Vector3(IEnumerable<float> v, int startIndex = 0) : this(v.ToArray(), startIndex) { }

        /// <summary>
        /// Set x, y and z components of an existing Vector3.
        /// </summary>
        public void Set(float newX, float newY, float newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }

        /// <summary>
        /// Returns true if the given vector is exactly equal to this vector.
        /// </summary>
        public bool Equals(Vector3 other)
        {
            return (x == other.x) && (y == other.y) && (z == other.z);
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
                return Equals((Vector3)obj);
        }

        /// <summary>
        /// Returns a hash code for the current object.
        /// Allows a Vector3 to be used as a key in hash tables.
        /// </summary>
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
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
            return $"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
        }

        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        public IEnumerator<float> GetEnumerator()
        {
            yield return x;
            yield return y;
            yield return z;
        }

        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Shorthand for writing Vector3(0, 0, -1).
        /// </summary>
        public static Vector3 back => new Vector3(0, 0, -1);

        /// <summary>
        /// Shorthand for writing Vector3(0, 0, 1).
        /// </summary>
        public static Vector3 forward => new Vector3(0, 0, 1);

        /// <summary>
        /// Shorthand for writing Vector3(0, -1, 0).
        /// </summary>
        public static Vector3 down => new Vector3(0, -1, 0);

        /// <summary>
        /// Shorthand for writing Vector3(0, 1, 0).
        /// </summary>
        public static Vector3 up => new Vector3(0, 1, 0);

        /// <summary>
        /// Shorthand for writing Vector3(-1, 0, 0).
        /// </summary>
        public static Vector3 left => new Vector3(-1, 0, 0);

        /// <summary>
        /// Shorthand for writing Vector3(1, 0, 0).
        /// </summary>
        public static Vector3 right => new Vector3(1, 0, 0);

        /// <summary>
        /// Shorthand for writing Vector3(0, 0, 0).
        /// </summary>
        public static Vector3 zero => new Vector3(0, 0, 0);

        /// <summary>
        /// Shorthand for writing Vector3(1, 1, 1).
        /// </summary>
        public static Vector3 one => new Vector3(1, 1, 1);

        /// <summary>
        /// Shorthand for writing Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity).
        /// </summary>
        public static Vector3 negativeInfinity => new Vector3(float.NegativeInfinity, float.PositiveInfinity, float.NegativeInfinity);

        /// <summary>
        /// Shorthand for writing Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity).
        /// </summary>
        public static Vector3 positiveInfinity => new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

    }
}
