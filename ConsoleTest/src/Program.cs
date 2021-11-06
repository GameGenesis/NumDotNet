using System;
using NumDotNet;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 v1 = new Vector2();
            Vector2 v2 = new Vector2(3, 4);

            Console.WriteLine(v1.ToString());
            Console.WriteLine(v1.magnitude);

            Console.WriteLine(v2.ToString());
            Console.WriteLine(v2.magnitude);
            Console.WriteLine(v2.sqrMagnitude);
            Console.WriteLine(v2[0]);

            v2.Normalize();

            Console.WriteLine(v2.ToString());
            Console.WriteLine(v2[1]);

            v2.Set(8, 8);
            v2 /= 4;
            v1.Normalize();

            Console.WriteLine(v2);
            Console.WriteLine(v1.normalized);

            float angle = Vector2.Angle(new Vector2(2, 3), new Vector2(-5, 4)) * Mathf.RadToDeg;
            Console.WriteLine(angle);

            Console.WriteLine(Mathf.PI);
            Console.WriteLine(Mathf.Epsilon);

            Console.WriteLine(Mathf.Approximately(1.000001f, 10.0f / 10.0f));
            Console.WriteLine($"{Mathf.CeilingToInt(-10f)}, {Mathf.CeilingToInt(-10.7f)}, {Mathf.CeilingToInt(5f)}, {Mathf.CeilingToInt(5.3f)}");

            float[] fl1 = new float[0];
            float[] fl2 = new float[1] { 2 };
            float[] fl3 = new float[3] { 2, 3, 4 };

            Vector2 v3 = new Vector2(fl1);
            Console.WriteLine(v3);

            v3 = new Vector2(fl2);
            Console.WriteLine(v3);

            v3 = new Vector2(fl3, 1);
            Console.WriteLine(v3);

            v3 = new Vector2(fl3, 2);
            Console.WriteLine(v3);

            float[] fl4 = (float[])new Vector2(0, 3);
            Console.WriteLine(new Vector2(fl4));

            Console.ReadKey();
        }
    }
}
