using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 4: Student class
    class Student
    {
        public int age;
        public string name;
        public void Input()
        {
            Console.Write("Enter name: "); name = Console.ReadLine();
            Console.Write("Enter age: "); age = int.Parse(Console.ReadLine());
        }
        public static void Run()
        {
            Student[] lstStudent = new Student[5];
            for (int i = 0; i < 5; i++)
            {
                lstStudent[i] = new Student();
                lstStudent[i].Input();
            }
            Console.WriteLine("Students with age >= 24:");
            foreach (var s in lstStudent)
            {
                if (s.age >= 24)
                    Console.WriteLine($"Name: {s.name}, Age: {s.age}");
            }
        }
    }

    internal class q04
    {
        public static void Run()
        {
            Student.Run();
        }
    }
}
