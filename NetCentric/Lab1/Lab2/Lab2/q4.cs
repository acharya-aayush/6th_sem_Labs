using System;

namespace Lab2
{
    class Student
    {
        public int age, roll;
        public string name;
        
        public void input()
        {
            Console.Write("Name: "); name = Console.ReadLine();
            Console.Write("Age: "); age = int.Parse(Console.ReadLine());
            Console.Write("Roll: "); roll = int.Parse(Console.ReadLine());
        }
    }

    class Imain
    {
        public static void main()
        {
            Student[] s = new Student[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Student {i + 1}: ");
                s[i] = new Student();
                s[i].input();
            }
            
            Console.WriteLine("\nAge >= 24:");
            for (int i = 0; i < 5; i++)
                if (s[i].age >= 24)
                    Console.WriteLine($"{s[i].roll} {s[i].name} {s[i].age}");
        }
    }

    internal class q4
    {
        public static void Run()
        {
            Console.WriteLine("=== Q4: Student Array ===");
            Imain.main();
            Console.WriteLine();
        }
    }
}
