using System;

namespace wowow;

internal class SimpleInterest
{
    public void CalculateSimpleInterests()
    {
        Console.WriteLine("Enter the Principal amount:");
        double principal = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the Rate of Interest (in %):");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the Time period (in years):");
        double time = Convert.ToDouble(Console.ReadLine());

        double simpleInterest = (principal * rate * time) / 100;

        Console.WriteLine($"Simple Interest = {simpleInterest}");
    }

    public void CalculateSimpleInterest()
    { Console.WriteLine("Enter the Principal amount:"); double principal = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the Rate of Interest (in %):");
        double rate = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the Time period (in years):");
        double time = Convert.ToDouble(Console.ReadLine());
        double simpleInterest = (principal * rate * time) / 100;
        Console.WriteLine($"Simple Interest = {simpleInterest}");


    }
    }

}
