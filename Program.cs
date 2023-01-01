using System;

namespace FibonacciPythagoras
{

    class Program
    {
        static void Main(string[] args)
        {
            //TODO input : n => nth Pythagorian integer triplet

            var n = 1; do
            {
                Console.WriteLine($"#{n}:");
                Console.WriteLine(new FiboPytha(n));
                Console.ReadLine();
                n++;
            } while (true);
        }
    }
}