using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 3: Quadratic class
    class Quadratic
    {
        double a, b, c, x1, x2;
        public void Input()
        {
            Console.Write("Enter a: "); a = double.Parse(Console.ReadLine());
            Console.Write("Enter b: "); b = double.Parse(Console.ReadLine());
            Console.Write("Enter c: "); c = double.Parse(Console.ReadLine());
        }
        public double[] Calculate()
        {
            double d = b * b - 4 * a * c;
            x1 = (-b + Math.Sqrt(d)) / (2 * a);
            x2 = (-b - Math.Sqrt(d)) / (2 * a);
            return new double[] { x1, x2 };
        }
        public static void Run()
        {
            Quadratic q = new Quadratic();
            q.Input();
            var roots = q.Calculate();
            Console.WriteLine($"Roots are: x1 = {roots[0]}, x2 = {roots[1]}");
        }
    }

    internal class q03
    {
        public static void Run()
        {
            Quadratic.Run();
        }
    }
}
