using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class ResultCalculator
    {
        private int[] marks;
        private const int PassMarks = 35;
        private const int FullMarks = 100;

        public ResultCalculator(int[] marks)
        {
            this.marks = marks;
        }

        public bool IsPassed()
        {
            foreach (int mark in marks)
            {
                if (mark < PassMarks)
                    return false;
            }
            return true;
        }

        public double CalculatePercentage()
        {
            int total = 0;
            foreach (int mark in marks)
                total += mark;
            return (double)total / (marks.Length * FullMarks) * 100;
        }

        public string GetDivision(double percentage)
        {
            if (percentage >= 80) return "Distinction";
            if (percentage >= 60) return "First Division";
            if (percentage >= 45) return "Second Division";
            if (percentage >= 35) return "Third Division";
            return "Fail";
        }
    }
}
