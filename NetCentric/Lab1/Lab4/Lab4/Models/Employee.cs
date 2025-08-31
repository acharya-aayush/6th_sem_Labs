using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Position { get; set; } = "";
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }
}