using System;

namespace Lab2
{
    internal class q12
    {
        public static void Run()
        {
            Console.WriteLine("=== Q12: Sum Odd Numbers ===");
            Console.Write("Enter array size: ");
            int n = int.Parse(Console.ReadLine());
            
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element " + (i + 1) + ": ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            
            int oddSum = 0;
            for (int i = 0; i < n; i++)
            {
                if (numbers[i] % 2 != 0)
                    oddSum = oddSum + numbers[i];
            }
            
            Console.Write("Array: [");
            for (int i = 0; i < n; i++)
            {
                Console.Write(numbers[i]);
                if (i < n - 1) Console.Write(", ");
            }
            Console.WriteLine("]");
            Console.WriteLine("Sum of odd numbers: " + oddSum);
            Console.WriteLine();
        }
    }
}
