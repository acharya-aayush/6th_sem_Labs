using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 7: Display words ending with 'g'
    class WordEndsWithG
    {
        public static void Run()
        {
            File.WriteAllText("Input.txt", "C# is a OOP Programming Language\nMr Hari Gurung loves a programming");
            string[] words = File.ReadAllText("Input.txt").Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (word.EndsWith("g"))
                    Console.WriteLine(word);
            }
        }
    }

    internal class q07
    {
        public static void Run()
        {
            WordEndsWithG.Run();
        }
    }
}
