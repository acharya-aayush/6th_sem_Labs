using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 5: Time addition
    class Time
    {
        public int hr, min, sec;
        public Time() { }
        public Time(int h, int m, int s) { hr = h; min = m; sec = s; }
        public Time Sum(Time t1, Time t2)
        {
            Time result = new Time();
            int totalSec = t1.sec + t2.sec;
            result.sec = totalSec % 60;
            int totalMin = t1.min + t2.min + totalSec / 60;
            result.min = totalMin % 60;
            result.hr = t1.hr + t2.hr + totalMin / 60;
            return result;
        }
        public static void Run()
        {
            Time t1 = new Time(5, 40, 40);
            Time t2 = new Time(4, 40, 50);
            Time t3 = new Time();
            Time result = t3.Sum(t1, t2);
            Console.WriteLine($"Total Sum: {result.hr}:{result.min}:{result.sec}");
        }
    }

    internal class q05
    {
        public static void Run()
        {
            Time.Run();
        }
    }
}
