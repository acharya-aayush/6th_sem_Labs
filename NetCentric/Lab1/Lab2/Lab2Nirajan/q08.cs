using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 8: Interface ICalculator
    interface ICalculator
    {
        int Add(int x, int y);
        int Diff(int x, int y);
    }
    class Calculator : ICalculator
    {
        public int Add(int x, int y) => x + y;
        public int Diff(int x, int y) => x - y;
        public static void Run()
        {
            Calculator calc = new Calculator();
            Console.WriteLine($"Addition: {calc.Add(10, 5)}");
            Console.WriteLine($"Difference: {calc.Diff(10, 5)}");
        }
    }

    internal class q08
    {
        public static void Run()
        {
            Calculator.Run();
        }
    }
}
