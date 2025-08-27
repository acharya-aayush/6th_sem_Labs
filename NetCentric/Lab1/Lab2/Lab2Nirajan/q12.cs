using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 12: Lambda Expression for odd sum
    class OddSumLambda
    {
        public static void Run()
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            int sum = arr.Where(x => x % 2 != 0).Sum();
            Console.WriteLine($"Sum of odd numbers: {sum}");
        }
    }

    internal class q12
    {
        public static void Run()
        {
            OddSumLambda.Run();
        }
    }
}
