using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 1: Finding factorial using delegate
    class FactorialProgram
    {
        public delegate int FactorialDelegate(int n);
        public static int Factorial(int n)
        {
            int fact = 1;
            for (int i = 1; i <= n; i++)
                fact *= i;
            return fact;
        }
        public static void Run()
        {
            FactorialDelegate del = new FactorialDelegate(Factorial);
            Console.Write("Enter a number to find factorial: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"Factorial of {num} is {del(num)}");
        }
    }

    internal class q01
    {
        public static void Run()
        {
            FactorialProgram.Run();
        }
    }
}
