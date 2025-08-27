using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 10: Abstract class Vehicle
    abstract class Vehicle
    {
        public abstract void StartEngine();
        public void StopEngine() => Console.WriteLine("Engine stopped.");
    }
    class Airplane : Vehicle
    {
        string model = "Boeing 737", manufacturer = "Boeing";
        int maxCapacity = 180;
        public override void StartEngine() => Console.WriteLine("Airplane engine started.");
        public void TakeOff() => Console.WriteLine("Airplane is taking off.");
        public void Land() => Console.WriteLine("Airplane has landed.");
        public static void Run()
        {
            Airplane a = new Airplane();
            a.StartEngine();
            a.TakeOff();
            a.Land();
            a.StopEngine();
        }
    }

    internal class q10
    {
        public static void Run()
        {
            Airplane.Run();
        }
    }
}
