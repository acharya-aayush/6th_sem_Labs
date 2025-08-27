using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 9: Interface Shape
    interface Shape
    {
        void Get();
        void Display();
    }
    class Rectangle : Shape
    {
        int length, breadth;
        public void Get()
        {
            Console.Write("Enter length: "); length = int.Parse(Console.ReadLine());
            Console.Write("Enter breadth: "); breadth = int.Parse(Console.ReadLine());
        }
        public void Display()
        {
            Console.WriteLine($"Rectangle Area: {length * breadth}");
        }
    }
    class Square : Shape
    {
        int side;
        public void Get()
        {
            Console.Write("Enter side: "); side = int.Parse(Console.ReadLine());
        }
        public void Display()
        {
            Console.WriteLine($"Square Area: {side * side}");
        }
        public static void Run()
        {
            Shape r = new Rectangle(); r.Get(); r.Display();
            Shape s = new Square(); s.Get(); s.Display();
        }
    }

    internal class q09
    {
        public static void Run()
        {
            Square.Run();
        }
    }
}
