using System;

namespace NumDotNet
{
    public class Vector3
    {
        /// <summary> X component of the vector. </summary>
        public float x { get; set; }
        /// <summary> Y component of the vector. </summary>
        public float y { get; set; }
        /// <summary> Z component of the vector. </summary>
        public float z { get; set; }

        /// <summary> Constructs a new vector with deafult Vector3(0, 0, 0) points. </summary>
        public Vector3() : this(0, 0, 0) { }

        /// <summary> Constructs a new vector with given x, y, z components. </summary>
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
