using System;

namespace Lab2
{
    abstract class Vehicle
    {
        public abstract void startEngine();
        public void stopEngine() => Console.WriteLine("Engine stopped.");
    }

    class Airplane : Vehicle
    {
        public string model, manufacturer;
        public int maxCapacity;

        public Airplane(string m, string mf, int c) { model = m; manufacturer = mf; maxCapacity = c; }
        public override void startEngine() => Console.WriteLine($"Starting {manufacturer} {model} engine...");
        public void takeOff() => Console.WriteLine($"{manufacturer} {model} taking off...");
        public void land() => Console.WriteLine($"{manufacturer} {model} landing...");
    }

    internal class q10
    {
        public static void Run()
        {
            Console.WriteLine("=== Question 10: Abstract Vehicle ===");
            var plane = new Airplane("Boeing 737", "Boeing", 180);
            Console.WriteLine($"Aircraft: {plane.manufacturer} {plane.model} (Capacity: {plane.maxCapacity})");
            plane.startEngine();
            plane.takeOff();
            plane.land();
            plane.stopEngine();
            Console.WriteLine();
        }
    }
}
