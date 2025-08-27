using System;

namespace Lab2
{
    class Time
    {
        public int hr, min, sec;
        public Time(int h = 0, int m = 0, int s = 0) { hr = h; min = m; sec = s; }

        public Time Sum(Time t1, Time t2)
        {
            int s = t1.sec + t2.sec, m = t1.min + t2.min + s / 60, h = t1.hr + t2.hr + m / 60;
            return new Time(h, m % 60, s % 60);
        }

        public override string ToString() { return hr + ":" + min.ToString("D2") + ":" + sec.ToString("D2"); }
    }

    class TimeDemo
    {
        public static void main()
        {
            Time t1 = new Time(5, 40, 40);
            Time t2 = new Time(4, 40, 50);
            Time t3 = new Time().Sum(t1, t2);
            
            Console.WriteLine("t1 -> " + t1);
            Console.WriteLine("t2 -> " + t2);
            Console.WriteLine("Total Sum t3 -> " + t3);
        }
    }

    internal class q5
    {
        public static void Run()
        {
            Console.WriteLine("=== Q5: Time Addition ===");
            TimeDemo.main();
            Console.WriteLine();
        }
    }
}
