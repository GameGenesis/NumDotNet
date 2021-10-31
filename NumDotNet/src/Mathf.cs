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
    }
}
