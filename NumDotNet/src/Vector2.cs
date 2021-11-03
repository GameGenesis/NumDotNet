using System;

namespace NumDotNet
{
    public class Vector2
    {
        /// <summary> X component of the vector. </summary>
        public float x { get; set; }
        /// <summary> Y component of the vector. </summary>
        public float y { get; set; }
        
        /// <summary> Returns the squared length of this vector (Read Only). </summary>
        public float sqrMagnitude => x * x + y * y;
        /// <summary> Returns the length of this vector (Read Only). </summary>
        public float magnitude => (float)Math.Sqrt(sqrMagnitude);
        /// <summary> Returns this vector with a magnitude of 1 (Read Only). </summary>
        public Vector2 normalized => magnitude > Mathf.Epsilon ? new Vector2(x / magnitude, y / magnitude) : new Vector2(0, 0);

        public const float kEpsilon = 0.00001f;

        /// <summary> Access the x or y component using [0] or [1] respectively. </summary>
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

        /// <summary> Constructs a new vector with default Vector2(0, 0) points. </summary>
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
            x = newX;
            y = newY;
        }

        /// <summary> Makes this vector have a magnitude of 1. </summary>
        public void Normalize()
        {
            if (magnitude > kEpsilon)
                Set(x / magnitude, y / magnitude);
            else
                Set(0, 0);
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

        public override int GetHashCode() => Tuple.Create(x, y).GetHashCode();

        /// <summary> Returns a formatted string for this vector. </summary>
        public override string ToString() => $"({x}, {y})";

        /// <summary> Returns the distance between a and b. </summary>
        public static float Distance(Vector2 a, Vector2 b)
        {
            return (a - b).magnitude;
        }

        /// <summary> Dot Product of two vectors. </summary>
        public static float Dot(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        /// <summary> Returns the unsigned angle in degrees between a and b. </summary>
        public static float Angle(Vector2 a, Vector2 b)
        {
            return (float)Math.Acos((a.x * b.x + a.y * b.y) / (a.magnitude * b.magnitude));
        }

        /// <summary> Returns a copy of vector with its magnitude clamped to maxLength. </summary>
        public static Vector2 ClampMagnitude(Vector2 vector, float maxLength)
        {
            float sqrMagnitude = vector.sqrMagnitude;

            if (sqrMagnitude > maxLength * maxLength)
            {
                float magnitude = (float)Math.Sqrt(sqrMagnitude);
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

        /// <summary> Linearly interpolates between vectors a and b by t. </summary>
        public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
        {
            return new Vector2(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
        }

        /// <summary> Returns a vector that is made from the largest components of two vectors. </summary>
        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            return new Vector2(Math.Max(a.x, b.x), Math.Max(a.y, b.y));
        }

        /// <summary> Returns a vector that is made from the smallest components of two vectors. </summary>
        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            return new Vector2(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
        }

        /// <summary> Multiplies two vectors component-wise. </summary>
        public static Vector2 Scale(Vector2 a, Vector2 b)
        {
            return a * b;
        }

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

        /// <summary> Adds two Vectors. </summary>
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        /// <summary> Subtracts one vector from another. </summary>
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        /// <summary> Negates a Vector. </summary>
        public static Vector2 operator -(Vector2 a) => new Vector2(-a.x, -a.y);
        /// <summary> Multiplies a vector by a number. </summary>
        public static Vector2 operator *(Vector2 a, float d) => new Vector2(a.x * d, a.y * d);
        /// <summary> Multiplies a vector by a number. </summary>
        public static Vector2 operator *(float d, Vector2 a) => new Vector2(a.x * d, a.y * d);
        /// <summary> Multiplies a vector by another vector. </summary>
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
        /// <summary> Divides a vector by a number. </summary>
        public static Vector2 operator /(Vector2 a, float d) => d != 0 ? new Vector2(a.x / d, a.y / d) : throw new DivideByZeroException();
        /// <summary> Divides a vector by another vector. </summary>
        public static Vector2 operator /(Vector2 a, Vector2 b) => b.x != 0 && b.y != 0 ? new Vector2(a.x / b.x, a.y / b.y) : throw new DivideByZeroException();
        /// <summary> Returns true if two vectors are approximately equal. </summary>
        public static bool operator ==(Vector2 a, Vector2 b) => Math.Abs(a.x - b.x) <= kEpsilon && Math.Abs(a.y - b.y) <= kEpsilon;
        /// <summary> Returns true if two vectors are not equal. </summary>
        public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);
        /// <summary> Converts a Vector3 to a Vector2. </summary>
        public static implicit operator Vector2(Vector3 v) => new Vector2(v.x, v.y);
        /// <summary> Converts a Vector2 to a Vector3. </summary>
        public static implicit operator Vector3(Vector2 v) => new Vector3(v.x, v.y, 0);
    }
}
