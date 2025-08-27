using System;

namespace Lab2
{
    interface Shape
    {
        void get();
        void display();
    }

    class Rectangle : Shape
    {
        double length, width;
        
        public void get()
        {
            Console.Write("Enter length: ");
            length = double.Parse(Console.ReadLine());
            Console.Write("Enter width: ");
            width = double.Parse(Console.ReadLine());
        }
        
        public void display()
        {
            double area = length * width;
            double perimeter = 2 * (length + width);
            Console.WriteLine("Rectangle - Area: " + area + ", Perimeter: " + perimeter);
        }
    }

    class Square : Shape
    {
        double side;
        
        public void get()
        {
            Console.Write("Enter side: ");
            side = double.Parse(Console.ReadLine());
        }
        
        public void display()
        {
            double area = side * side;
            double perimeter = 4 * side;
            Console.WriteLine("Square - Area: " + area + ", Perimeter: " + perimeter);
        }
    }

    internal class q9
    {
        public static void Run()
        {
            Console.WriteLine("=== Q9: Shape Interface ===");
            Rectangle rect = new Rectangle();
            Square square = new Square();
            
            Console.WriteLine("Rectangle input:");
            rect.get();
            rect.display();
            
            Console.WriteLine("Square input:");
            square.get();
            square.display();
            Console.WriteLine();
        }
    }
}
