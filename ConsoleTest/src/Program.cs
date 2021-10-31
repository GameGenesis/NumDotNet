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

            Console.ReadKey();
        }
    }
}
