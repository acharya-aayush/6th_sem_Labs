using System;
using System.IO;

namespace Lab2
{
    internal class q7
    {
        public static void Run()
        {
            Console.WriteLine("=== Q7: Words ending 'g' ===");
            string content = "C# is a OOP Programming Language\nAayush programming";
            File.WriteAllText("Input.txt", content);
            Console.WriteLine("Input text:");
            Console.WriteLine(content);
            
            string[] words = content.Split(' ', '\n');
            Console.WriteLine("\nWords ending with 'g':");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].EndsWith("g"))
                    Console.WriteLine(words[i]);
            }
            Console.WriteLine();
        }
    }
}
