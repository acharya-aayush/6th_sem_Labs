using System;

namespace wowow;

internal class Result
{
    private const int PassMarks = 35;
    private const int FullMarks = 100;
    private const int SubjectCount = 5;

    public void GenerateResult()
    {
        int[] marks = new int[SubjectCount];
        int totalObtained = 0;

        for (int i = 0; i < SubjectCount; i++)
        {
            Console.Write($"Enter marks for subject {i + 1}: ");
            marks[i] = Convert.ToInt32(Console.ReadLine());

            if (marks[i] < 0 || marks[i] > FullMarks)
            {
                Console.WriteLine($"Invalid marks entered for subject {i + 1}. Please enter marks between 0 and {FullMarks}.");
                i--; // Ask again for the same subject
                continue;
            }

            if (marks[i] < PassMarks)
            {
                Console.WriteLine($"You have failed in subject {i + 1}.");
            }

            totalObtained += marks[i];
        }

        // Check if all subjects are passed
        bool allPassed = true;
        foreach (var mark in marks)
        {
            if (mark < PassMarks)
            {
                allPassed = false;
                break;
            }
        }

        if (allPassed)
        {
            double percentage = (totalObtained * 100.0) / (FullMarks * SubjectCount);
            Console.WriteLine($"Total Marks Obtained: {totalObtained} out of {FullMarks * SubjectCount}");
            Console.WriteLine($"Percentage: {percentage:F2}%");

            // Division logic
            if (percentage >= 60)
            {
                Console.WriteLine("Division: First Division");
            }
            else if (percentage >= 50)
            {
                Console.WriteLine("Division: Second Division");
            }
            else if (percentage >= 35)
            {
                Console.WriteLine("Division: Third Division");
            }
            else
            {
                Console.WriteLine("Division: Fail");
            }
        }
        else
        {
            Console.WriteLine("Result: Fail because you did not pass in all subjects.");
        }
    }
}