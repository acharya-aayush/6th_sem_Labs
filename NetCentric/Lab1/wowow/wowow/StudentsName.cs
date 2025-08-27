using System;

namespace wowow
{
    internal class StudentNames
    {
        public void DisplayNamesWithT()
        {
            string[] students = new string[4];

            // Input names
            for (int i = 0; i < students.Length; i++)
            {
                Console.Write($"Enter name of student {i + 1}: ");
                students[i] = Console.ReadLine();
            }

            Console.WriteLine("\nStudents whose names contain the character 't' (case-insensitive):");

            foreach (string name in students)
            {
                if (!string.IsNullOrEmpty(name) && name.IndexOf('t', StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
