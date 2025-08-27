using System;
class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("==== .NET Lab Assignments ====");
            Console.WriteLine("1. Sum of two integers");
            Console.WriteLine("2. Simple Interest Calculator");
            Console.WriteLine("3. Quadratic Equation Solver");
            Console.WriteLine("4. Student Result Calculator");
            Console.WriteLine("5. Calculator with Switch Case");
            Console.WriteLine("6. Search names containing 't'");
            Console.WriteLine("7. Sort names in alphabetical order");
            Console.WriteLine("8. Find Min and Max in an Array");
            Console.WriteLine("9. Upper Triangle of 2D Array");
            Console.WriteLine("10. Rectangle Area Comparison");
            Console.WriteLine("0. Exit");
            Console.Write("\nEnter your choice (0-10): ");
            
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.Clear();
                
                switch (choice)
                {
                    case 1:
                        SumCalculator.Run();
                        break;
                    case 2:
                        SimpleInterestCalculator.Run();
                        break;
                    case 3:
                        QuadraticEquationSolver.Run();
                        break;
                    case 4:
                        ResultCalculator.Run();
                        break;
                    case 5:
                        OperatorCalculator.Run();
                        break;
                    case 6:
                        NameFinder.Run();
                        break;
                    case 7:
                        NameSorter.Run();
                        break;
                    case 8:
                        MinMaxFinder.Run();
                        break;
                    case 9:
                        UpperTrianglePrinter.Run();
                        break;
                    case 10:
                        RectangleComparer.Run();
                        break;
                    case 0:
                        running = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 0 and 10.");
                        break;
                }
                
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        
        Console.WriteLine("Thank you for using the Lab Assignment program!");
    }
}

// Assignment 1: Sum of two integers
class SumCalculator
{
    public static void Run()
    {
        Console.WriteLine("=== Sum of Two Integers ===\n");
        
        Console.Write("Enter first number: ");
        if (!int.TryParse(Console.ReadLine(), out int num1))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer.");
            return;
        }
        
        Console.Write("Enter second number: ");
        if (!int.TryParse(Console.ReadLine(), out int num2))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer.");
            return;
        }
        
        int sum = num1 + num2;
        Console.WriteLine($"\nResult: {num1} + {num2} = {sum}");
    }
}

// Assignment 2: Simple Interest Calculator
class SimpleInterestCalculator
{
    public static void Run()
    {
        Console.WriteLine("=== Simple Interest Calculator ===\n");
        
        Console.Write("Enter principal amount: ");
        if (!double.TryParse(Console.ReadLine(), out double principal))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }
        
        Console.Write("Enter rate of interest (per year): ");
        if (!double.TryParse(Console.ReadLine(), out double rate))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }
        
        Console.Write("Enter time period (in years): ");
        if (!double.TryParse(Console.ReadLine(), out double time))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }
        
        double interest = (principal * rate * time) / 100;
        Console.WriteLine($"\nSimple Interest = {interest:F2}");
        Console.WriteLine($"Total Amount = {principal + interest:F2}");
    }
}

// Assignment 3: Quadratic Equation Solver
class QuadraticEquationSolver
{
    public static void Run()
    {
        Console.WriteLine("=== Quadratic Equation Solver ===");
        Console.WriteLine("For equation in the form: ax² + bx + c = 0\n");
        
        Console.Write("Enter coefficient a: ");
        if (!double.TryParse(Console.ReadLine(), out double a))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }
        
        if (a == 0)
        {
            Console.WriteLine("This is not a quadratic equation (a cannot be 0)!");
            return;
        }
        
        Console.Write("Enter coefficient b: ");
        if (!double.TryParse(Console.ReadLine(), out double b))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }
        
        Console.Write("Enter coefficient c: ");
        if (!double.TryParse(Console.ReadLine(), out double c))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }
        
        double discriminant = b * b - 4 * a * c;
        
        Console.WriteLine($"\nEquation: {a}x² + {b}x + {c} = 0");
        
        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine("Two distinct real roots:");
            Console.WriteLine($"x₁ = {x1:F2}");
            Console.WriteLine($"x₂ = {x2:F2}");
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("One real root (repeated):");
            Console.WriteLine($"x = {x:F2}");
        }
        else
        {
            double realPart = -b / (2 * a);
            double imaginaryPart = Math.Sqrt(-discriminant) / (2 * a);
            Console.WriteLine("Two complex roots:");
            Console.WriteLine($"x₁ = {realPart:F2} + {imaginaryPart:F2}i");
            Console.WriteLine($"x₂ = {realPart:F2} - {imaginaryPart:F2}i");
        }
    }
}

// Assignment 4: Student Result Calculator
class ResultCalculator
{
    public static void Run()
    {
        Console.WriteLine("=== Student Result Calculator ===\n");
        
        const int passMarks = 35;
        const int fullMarks = 100;
        int[] marks = new int[5];
        string[] subjects = { "English", "Math", "Science", "Social Studies", "Computer" };
        
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter marks for {subjects[i]} (0-{fullMarks}): ");
            if (!int.TryParse(Console.ReadLine(), out marks[i]) || marks[i] < 0 || marks[i] > fullMarks)
            {
                Console.WriteLine($"Invalid input! Please enter a valid number between 0 and {fullMarks}.");
                i--; // Retry this subject
            }
        }
        
        bool allPassed = true;
        int totalMarks = 0;
        
        Console.WriteLine("\n=== Result ===");
        for (int i = 0; i < 5; i++)
        {
            string status = marks[i] >= passMarks ? "Pass" : "Fail";
            if (status == "Fail") allPassed = false;
            
            Console.WriteLine($"{subjects[i]}: {marks[i]}/{fullMarks} - {status}");
            totalMarks += marks[i];
        }
        
        double percentage = (double)totalMarks / (5 * fullMarks) * 100;
        
        Console.WriteLine($"\nTotal Marks: {totalMarks}/{5 * fullMarks}");
        Console.WriteLine($"Percentage: {percentage:F2}%");
        
        if (allPassed)
        {
            string division;
            if (percentage >= 80)
                division = "Distinction";
            else if (percentage >= 60)
                division = "First Division";
            else if (percentage >= 45)
                division = "Second Division";
            else
                division = "Third Division";
                
            Console.WriteLine($"Result: Pass ({division})");
        }
        else
        {
            Console.WriteLine("Result: Fail");
        }
    }
}

// Assignment 5: Calculator with Switch Case
class OperatorCalculator
{
    public static void Run()
    {
        Console.WriteLine("=== Calculator with Switch Case ===\n");
        
        Console.Write("Enter first number: ");
        if (!double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }
        
        Console.Write("Enter second number: ");
        if (!double.TryParse(Console.ReadLine(), out double num2))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }
        
        Console.Write("Enter operator (+, -, *, /): ");
        string op = Console.ReadLine() ?? "";
        
        double result = 0;
        bool validOperation = true;
        
        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("\nError: Division by zero is not allowed!");
                    validOperation = false;
                }
                else
                {
                    result = num1 / num2;
                }
                break;
            default:
                Console.WriteLine("\nInvalid operator! Please use +, -, *, or /");
                validOperation = false;
                break;
        }
        
        if (validOperation)
        {
            Console.WriteLine($"\nResult: {num1} {op} {num2} = {result}");
        }
    }
}

// Assignment 6: Search names containing 't'
class NameFinder
{
    public static void Run()
    {
        Console.WriteLine("=== Names Containing 't' Finder ===\n");
        
        string[] students = new string[4];
        
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Enter name of student {i + 1}: ");
            students[i] = Console.ReadLine() ?? "";
        }
        
        Console.WriteLine("\nNames containing 't' or 'T':");
        bool found = false;
        
        foreach (string name in students)
        {
            if (name.ToLower().Contains('t'))
            {
                Console.WriteLine($"- {name}");
                found = true;
            }
        }
        
        if (!found)
        {
            Console.WriteLine("No names containing 't' were found.");
        }
    }
}

// Assignment 7: Sort names in alphabetical order
class NameSorter
{
    public static void Run()
    {
        Console.WriteLine("=== Name Sorter ===\n");
        
        Console.Write("Enter the number of names: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive number.");
            return;
        }
        
        string[] names = new string[n];
        
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter name {i + 1}: ");
            names[i] = Console.ReadLine() ?? "";
        }
        
        Array.Sort(names);
        
        Console.WriteLine("\nNames in alphabetical order:");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {names[i]}");
        }
    }
}

// Assignment 8: Find Min and Max in an Array
class MinMaxFinder
{
    public static void Run()
    {
        Console.WriteLine("=== Min and Max Finder ===\n");
        
        Console.Write("Enter the number of elements: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive number.");
            return;
        }
        
        int[] numbers = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            if (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.WriteLine("Invalid input! Please enter a valid integer.");
                i--; // Retry this input
            }
        }
        
        int min = numbers[0];
        int max = numbers[0];
        
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
                min = numbers[i];
            
            if (numbers[i] > max)
                max = numbers[i];
        }
        
        Console.WriteLine("\nArray elements:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i]);
            if (i < numbers.Length - 1)
                Console.Write(", ");
        }
        
        Console.WriteLine($"\n\nMin = {min}");
        Console.WriteLine($"Max = {max}");
    }
}

// Assignment 9: Upper Triangle of 2D Array
class UpperTrianglePrinter
{
    public static void Run()
    {
        Console.WriteLine("=== Upper Triangle of 2D Array ===\n");
        
        const int size = 3;
        int[,] matrix = new int[size, size];
        
        Console.WriteLine($"Enter elements for {size}x{size} matrix:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Element at position [{i+1},{j+1}]: ");
                if (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                {
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
                    j--; // Retry this element
                }
            }
        }
        
        Console.WriteLine("\nOriginal Matrix:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{matrix[i, j],4}");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("\nUpper Triangle:");
        for (int i = 0; i < size; i++)
        {
            // Print leading spaces
            for (int s = 0; s < i; s++)
            {
                Console.Write("    ");
            }
            
            // Print values from diagonal to end of row
            for (int j = i; j < size; j++)
            {
                Console.Write($"{matrix[i, j],4}");
            }
            
            Console.WriteLine();
        }
    }
}

// Assignment 10: Rectangle Area Comparison
class Rectangle
{
    private double length;
    private double breadth;
    private double area;
    
    public Rectangle(double length, double breadth)
    {
        this.length = length;
        this.breadth = breadth;
    }
    
    public void ComputeArea()
    {
        area = length * breadth;
    }
    
    public void DisplayArea()
    {
        Console.WriteLine($"Rectangle with length = {length} and breadth = {breadth} has area = {area}");
    }
    
    public double GetArea()
    {
        return area;
    }
}

class RectangleComparer
{
    public static void Run()
    {
        Console.WriteLine("=== Rectangle Area Comparison ===\n");
        
        // First rectangle
        Console.WriteLine("Enter details for the first rectangle:");
        Console.Write("Length: ");
        if (!double.TryParse(Console.ReadLine(), out double length1) || length1 <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive number.");
            return;
        }
        
        Console.Write("Breadth: ");
        if (!double.TryParse(Console.ReadLine(), out double breadth1) || breadth1 <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive number.");
            return;
        }
        
        // Second rectangle
        Console.WriteLine("\nEnter details for the second rectangle:");
        Console.Write("Length: ");
        if (!double.TryParse(Console.ReadLine(), out double length2) || length2 <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive number.");
            return;
        }
        
        Console.Write("Breadth: ");
        if (!double.TryParse(Console.ReadLine(), out double breadth2) || breadth2 <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive number.");
            return;
        }
        
        Rectangle rect1 = new Rectangle(length1, breadth1);
        Rectangle rect2 = new Rectangle(length2, breadth2);
        
        rect1.ComputeArea();
        rect2.ComputeArea();
        
        Console.WriteLine("\nAreas of both rectangles:");
        rect1.DisplayArea();
        rect2.DisplayArea();
        
        if (rect1.GetArea() > rect2.GetArea())
        {
            Console.WriteLine("\nThe first rectangle has a larger area.");
        }
        else if (rect2.GetArea() > rect1.GetArea())
        {
            Console.WriteLine("\nThe second rectangle has a larger area.");
        }
        else
        {
            Console.WriteLine("\nBoth rectangles have the same area.");
        }
    }
}
