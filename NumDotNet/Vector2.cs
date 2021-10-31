using System;

namespace NumDotNet
{
    public class Vector2
    {
        /// <summary> Shorthand for writing Vector2(0, 0). </summary>
        public static Vector2 zero => new Vector2(0, 0);
        /// <summary> Shorthand for writing Vector2(1, 1). </summary>
        public static Vector2 one => new Vector2(1, 1);

        /// <summary> Shorthand for writing Vector2(0, 1). </summary>
        public static Vector2 up => new Vector2(0, 1);
        /// <summary> Shorthand for writing Vector2(0, -1). </summary>
        public static Vector2 down => new Vector2(0, -1);
        /// <summary> Shorthand for writing Vector2(-1, 0). </summary>
        public static Vector2 left => new Vector2(-1, 0);
        /// <summary> Shorthand for writing Vector2(1, 0). </summary>
        public static Vector2 right => new Vector2(1, 0);

        /// <summary> Shorthand for writing Vector2(float.NegativeInfinity, float.NegativeInfinity). </summary>
        public static Vector2 negativeInfinity => new Vector2(float.NegativeInfinity, float.PositiveInfinity);
        /// <summary> Shorthand for writing Vector2(float.PositiveInfinity, float.PositiveInfinity). </summary>
        public static Vector2 positiveInfinity => new Vector2(float.PositiveInfinity, float.PositiveInfinity);

        /// <summary> X component of the vector. </summary>
        public float x { get; set; }
        /// <summary> Y component of the vector. </summary>
        public float y { get; set; }
        
        /// <summary> Returns the squared length of this vector (Read Only). </summary>
        public float sqrMagnitude => x * x + y * y;
        /// <summary> Returns the length of this vector (Read Only). </summary>
        public float magnitude => (float)Math.Sqrt(sqrMagnitude);

        /// <summary> Access the x or y component using [0] or [1] respectively. </summary>
        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else throw new IndexOutOfRangeException();
            }
        }

        /// <summary> Constructs a new vector with given x, y components. </summary>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary> Set x and y components of an existing Vector2. </summary>
        public void Set(float newX, float newY)
        {
            this.x = newX;
            this.y = newY;
        }

        /// <summary> Makes this vector have a magnitude of 1. </summary>
        public void Normalize(float newX, float newY)
        {
            this.x = newX;
            this.y = newY;
        }

        /// <summary> Returns true if the given vector is exactly equal to this vector. </summary>
        public bool Equals(Vector2 other)
        {
            if (x == other.x && y == other.y)
                return true;
            else
                return false;
        }

        /// <summary> Returns a formatted string for this vector. </summary>
        public override string ToString()
        {
            return String.Format("{0}, {1}", x, y);
        }
    }
}
