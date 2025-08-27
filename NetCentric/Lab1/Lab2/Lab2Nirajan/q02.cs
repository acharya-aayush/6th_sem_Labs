using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 2: Custom Event demonstration
    class CustomEventProgram
    {
        public delegate void ProgressHandler(int percent);
        public static event ProgressHandler OnProgress;

        public static void Run()
        {
            OnProgress += percent => Console.WriteLine($"Progress: {percent}%");

            for (int i = 1; i <= 10000; i++)
            {
                if (i % 500 == 0)
                    OnProgress?.Invoke((i * 100) / 10000);
            }
        }
    }

    internal class q02
    {
        public static void Run()
        {
            CustomEventProgram.Run();
        }
    }
}
