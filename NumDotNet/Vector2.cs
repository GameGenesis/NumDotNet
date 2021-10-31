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
        /// <summary> Returns this vector with a magnitude of 1 (Read Only). </summary>
        public Vector2 normalized => this / magnitude;

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

        /// <summary> Adds two Vectors. </summary>
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        /// <summary> Subtracts one vector from another. </summary>
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        /// <summary> Multiplies a vector by a number. </summary>
        public static Vector2 operator *(Vector2 a, float d) => new Vector2(a.x * d, a.y * d);
        /// <summary> Divides a vector by a number. </summary>
        public static Vector2 operator /(Vector2 a, float d) => d != 0 ? new Vector2(a.x / d, a.y / d) : throw new DivideByZeroException();
        /// <summary> Returns true if two vectors are approximately equal. </summary>
        public static bool operator ==(Vector2 a, Vector2 b) => Math.Abs(a.x - b.x) <= 0.00001f && Math.Abs(a.y - b.y) <= 0.00001f;
        /// <summary> Returns true if two vectors are not equal. </summary>
        public static bool operator !=(Vector2 a, Vector2 b) => Math.Abs(a.x - b.x) > 0.00001f || Math.Abs(a.y - b.y) > 0.00001f;

        /// <summary> Constructs a new vector with deafult Vector2(0, 0) points. </summary>
        public Vector2() : this(0, 0) { }

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
        public void Normalize()
        {
            x /= magnitude;
            y /= magnitude;
        }

        /// <summary> Returns true if the given vector is exactly equal to this vector. </summary>
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Vector2 v = (Vector2)obj;
                return (x == v.x) && (y == v.y);
            }
        }

        public override int GetHashCode()
        {
            return Tuple.Create(x, y).GetHashCode();
        }

        /// <summary> Returns a formatted string for this vector. </summary>
        public override string ToString()
        {
            return String.Format("{0}, {1}", x, y);
        }
    }
}
