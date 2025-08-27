using System;

namespace wowow;

internal class QuadraticEquation
{
    public void FindRoots()
    {
        Console.WriteLine("Enter coefficient a:");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter coefficient b:");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter coefficient c:");
        double c = Convert.ToDouble(Console.ReadLine());

        double discriminant = b * b - 4 * a * c;

        if (a == 0)
        {
            Console.WriteLine("Coefficient 'a' cannot be zero in a quadratic equation.");
            return;
        }

        if (discriminant > 0)
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Roots are real and different: Root1 = {root1}, Root2 = {root2}");
        }
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            Console.WriteLine($"Roots are real and same: Root = {root}");
        }
        else
        {
            double realPart = -b / (2 * a);
            double imaginaryPart = Math.Sqrt(-discriminant) / (2 * a);
            Console.WriteLine($"Roots are complex and different:");
            Console.WriteLine($"Root1 = {realPart} + {imaginaryPart}i");
            Console.WriteLine($"Root2 = {realPart} - {imaginaryPart}i");
        }
    }
}
