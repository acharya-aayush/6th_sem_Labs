using System;

namespace Lab2
{
    class Quadratic
    {
        public double a, b, c, x1, x2;

        public void Input()
        {
            Console.Write("Enter a: "); a = double.Parse(Console.ReadLine());
            Console.Write("Enter b: "); b = double.Parse(Console.ReadLine());
            Console.Write("Enter c: "); c = double.Parse(Console.ReadLine());
        }

        public double[] Calculate()
        {
            double d = b * b - 4 * a * c;
            if (d >= 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                return new double[] { x1, x2 };
            }
            Console.WriteLine("Complex roots!");
            return new double[] { double.NaN, double.NaN };
        }
    }

    class ImainQuadratic
    {
        public static void main()
        {
            var q = new Quadratic();
            q.Input();
            var roots = q.Calculate();
            if (!double.IsNaN(roots[0]))
                Console.WriteLine($"Roots: {roots[0]:F2}, {roots[1]:F2}");
        }
    }

    internal class q3
    {
        public static void Run()
        {
            Console.WriteLine("=== Question 3: Quadratic Equation ===");
            ImainQuadratic.main();
            Console.WriteLine();
        }
    }
}
