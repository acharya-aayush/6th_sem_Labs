using System;

namespace Lab2
{
    interface ICalculator
    {
        int add(int x, int y);
        int diff(int x, int y);
    }

    class Calculator : ICalculator
    {
        public int add(int x, int y) { return x + y; }
        public int diff(int x, int y) { return x - y; }
    }

    internal class q8
    {
        public static void Run()
        {
            Console.WriteLine("=== Q8: Calculator Interface ===");
            ICalculator calc = new Calculator();
            
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Addition: " + a + " + " + b + " = " + calc.add(a, b));
            Console.WriteLine("Difference: " + a + " - " + b + " = " + calc.diff(a, b));
            Console.WriteLine();
        }
    }
}
