using System;

namespace wowow;

internal class Rectangle
{
    // Instance variables
    public double Length { get; set; }
    public double Breadth { get; set; }
    private double area;

    // Method to compute area (no parameters, no return)
    public void ComputeArea()
    {
        area = Length * Breadth;
    }

    // Method to display area (no parameters, no return)
    public void DisplayArea()
    {
        Console.WriteLine($"Area of rectangle (Length={Length}, Breadth={Breadth}) is: {area}");
    }

    // Method to get area value for comparison
    public double GetArea()
    {
        return area;
    }
}
