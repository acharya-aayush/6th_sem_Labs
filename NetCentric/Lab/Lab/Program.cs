using System;

namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] marks = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter marks for subject {i + 1}:  ");
                    marks[i] = Convert.ToInt32(Console.ReadLine());
            }

            ResultCalculator result = new ResultCalculator(marks);

            if (result.IsPassed())
            {
                double percentage = result.CalculatePercentage();
                string division = result.GetDivision(percentage);
                Console.WriteLine($"Congratulations! You have passed with Percentage: {percentage:F2}% and You have secured {division} Division");
            }
            else
            {
                Console.WriteLine("Sorry, you have failed.");
            }
        }
    }
}
