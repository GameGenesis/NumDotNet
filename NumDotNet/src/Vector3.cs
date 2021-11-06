using System;
using System.Collections.Generic;
using System.Linq;

namespace NumDotNet
{
    public struct Vector3
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
