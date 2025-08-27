using System;
using System.IO;

namespace Lab2
{
    internal class q6
    {
        public static void Run()
        {
            Console.WriteLine("=== Q6: File Copy ===");
            string content = "Hello and Welcome\nIt is the first content\nof the text file from first file";
            File.WriteAllText("input.txt", content);
            File.WriteAllText("output.txt", File.ReadAllText("input.txt"));
            Console.WriteLine("Copied content:");
            Console.WriteLine(File.ReadAllText("output.txt"));
            Console.WriteLine();
        }
    }
}
