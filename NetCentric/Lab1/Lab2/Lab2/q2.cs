using System;

namespace Lab2
{
    internal class q2
    {
        public static event Action<int, double> ProgressChanged;

        public static void Run()
        {
            Console.WriteLine("=== Question 2: Custom Event ===");
            ProgressChanged += (i, p) => Console.WriteLine($"Progress: {p:F1}% (Iter: {i})");
            for (int i = 1; i <= 10000; i++)
                if (i % 5 == 0) ProgressChanged?.Invoke(i, (double)i / 100);
            Console.WriteLine("Completed!\n");
        }
    }
}
