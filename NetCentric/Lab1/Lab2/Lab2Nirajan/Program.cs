using System;

namespace Lab2Nirajan
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("\nQuestion 1: Finding factorial");
            FactorialProgram.Run();

            Console.WriteLine("\nQuestion 2: Custom Event demonstration");
            CustomEventProgram.Run();

            Console.WriteLine("\nQuestion 3: Quadratic Equation Roots");
            Quadratic.Run();

            Console.WriteLine("\nQuestion 4: Student Age Filter");
            Student.Run();

            Console.WriteLine("\nQuestion 5: Time Addition");
            Time.Run();

            Console.WriteLine("\nQuestion 6: File Copy");
            FileCopy.Run();

            Console.WriteLine("\nQuestion 7: Words Ending with 'g'");
            WordEndsWithG.Run();

            Console.WriteLine("\nQuestion 8: ICalculator Interface");
            Calculator.Run();

            Console.WriteLine("\nQuestion 9: Shape Interface Implementation");
            Square.Run();

            Console.WriteLine("\nQuestion 10: Abstract Vehicle Class");
            Airplane.Run();

            Console.WriteLine("\nQuestion 11: Employee LINQ Query");
            Employee.Run();

            Console.WriteLine("\nQuestion 12: Lambda Expression Odd Sum");
            OddSumLambda.Run();
        }
    }
}
