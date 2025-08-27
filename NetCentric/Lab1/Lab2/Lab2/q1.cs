using System;

namespace Lab2
{
    internal class q1
    {
        public delegate long FactorialDelegate(int n);
        public static long Fact(int n) => n <= 1 ? 1 : n * Fact(n - 1);

        public static void Run()
        {
            Console.WriteLine("=== Question 1: Factorial ===");
            FactorialDelegate f = Fact;
            Console.Write("Enter number: ");
            if (int.TryParse(Console.ReadLine(), out int n))
                Console.WriteLine($"Factorial of {n} = {f(n)}");
            else Console.WriteLine("Invalid!");
            Console.WriteLine();
        }
    }
}
