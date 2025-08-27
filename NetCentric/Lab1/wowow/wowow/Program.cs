using System;
using System.Drawing;

namespace wowow;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== Calculator: Add Two Numbers =====");
        Calculator calc = new Calculator();
        calc.AddTwoNumbers();

        Console.WriteLine("\n===== Simple Interest Calculator =====");
        SimpleInterest simp = new SimpleInterest();
        simp.CalculateSimpleInterest();

        Console.WriteLine("\n===== Quadratic Equation Roots Finder =====");
        QuadraticEquation quad = new QuadraticEquation();
        quad.FindRoots();

        Console.WriteLine("\n===== Result Generator =====");
        Result result = new Result();
        result.GenerateResult();

        Console.WriteLine("\n===== Calculator Operations with Switch Case =====");
        CalculatorOperations operations = new CalculatorOperations();
        operations.PerformOperation();

        Console.WriteLine("\n===== Student Names containing 't' =====");
        StudentNames studentNames = new StudentNames();
        studentNames.DisplayNamesWithT();

        //Console.WriteLine("\n===== Name Sorter =====");
        //NameSorter sorter = new NameSorter();
        //sorter.SortAndDisplayNames();

        //Console.WriteLine("\n===== Min and Max Finder in Array =====");
        //MinMaxFinder minMaxFinder = new MinMaxFinder();
        //minMaxFinder.FindMinMax();

        //Console.WriteLine("\n===== Upper Triangular Matrix Display =====");
        //UpperTriangleMatrix upperTriangle = new UpperTriangleMatrix();
        //upperTriangle.DisplayUpperTriangle();

        Console.WriteLine("\n===== Rectangle Area Comparison =====");
        Rectangle rect1 = new Rectangle();
        Rectangle rect2 = new Rectangle();

        Console.WriteLine("Enter length and breadth of first rectangle:");
        rect1.Length = Convert.ToDouble(Console.ReadLine());
        rect1.Breadth = Convert.ToDouble(Console.ReadLine());
        rect1.ComputeArea();
        rect1.DisplayArea();

        Console.WriteLine("Enter length and breadth of second rectangle:");
        rect2.Length = Convert.ToDouble(Console.ReadLine());
        rect2.Breadth = Convert.ToDouble(Console.ReadLine());
        rect2.ComputeArea();
        rect2.DisplayArea();

        if (rect1.GetArea() > rect2.GetArea())
        {
            Console.WriteLine("\nFirst rectangle has the larger area:");
            rect1.DisplayArea();
        }
        else if (rect2.GetArea() > rect1.GetArea())
        {
            Console.WriteLine("\nSecond rectangle has the larger area:");
            rect2.DisplayArea();
        }
        else
        {
            Console.WriteLine("\nBoth rectangles have equal area:");
            rect1.DisplayArea();
        }

        Console.WriteLine("\n\nAll operations completed. Press any key to exit.");
        Console.ReadKey();
    }
}
