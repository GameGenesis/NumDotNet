using System;

namespace NumDotNet
{
    public class Mathf
    {
        /// <summary>
        /// The ratio of the circumference of a circle to its diameter.
        /// Note that this value is a 32-bit floating point number.
        /// Approximately seven digits of precision are provided (Read Only).
        /// </summary>
        public const float PI = 3.1415927f;

        /// <summary> Radians-to-degrees conversion constant (Read Only). </summary>
        public const float RadToDeg = 180f / PI;

        /// <summary> Degrees-to-radians conversion constant (Read Only). </summary>
        public const float DegToRad = PI  / 180f;

        /// <summary>
        /// A tiny floating point value.
        /// The smallest value that a float can have different from zero (Read Only).
        /// </summary>
        public const float Epsilon = float.Epsilon;

        /// <summary> Compares two floating point values and returns true if they are similar - within a small value (Epsilon) of each other. </summary>
        public static bool Approximately(float a, float b)
        {
            return Math.Abs(a - b) <= Math.Max(0.000001f * Math.Max(Math.Abs(a), Math.Abs(b)), Epsilon * 8);
        }

        /// <summary> Returns the smallest integer greater to or equal to f. </summary>
        public static int CeilingToInt(float f)
        {
            return (int)Math.Ceiling(f);
        }

        /// <summary> Returns the largest integer smaller to or equal to f. </summary>
        public static int FloorToInt(float f)
        {
            return (int)Math.Floor(f);
        }

        /// <summary> Clamps value between 0 and 1 and returns value. </summary>
        public static float Clamp01(float value)
        {
            if (value < 0f)
                return 0f;
            else if (value > 1f)
                return 1f;
            else
                return value;
        }
    }
}
