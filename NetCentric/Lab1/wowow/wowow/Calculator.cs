using System;

namespace wowow;

internal class Calculator
{
    public void AddTwoNumbers()
    {
        Console.WriteLine("Enter the first integer:");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the second integer:");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int sum = num1 + num2;

        Console.WriteLine($"The sum of {num1} and {num2} is: {sum}");
    }
}
