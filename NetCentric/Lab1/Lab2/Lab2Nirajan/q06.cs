using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 6: File copy
    class FileCopy
    {
        public static void Run()
        {
            File.WriteAllText("input.txt", "Hello and Welcome\nIt is the first content \nof the text file from first file");
            File.Copy("input.txt", "output.txt", true);
            Console.WriteLine("File copied to output.txt");
        }
    }

    internal class q06
    {
        public static void Run()
        {
            FileCopy.Run();
        }
    }
}
