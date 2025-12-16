using Lab6.Models;
using Microsoft.Data.SqlClient;

namespace Lab6.Services
{
    public class EmpRepo : IEmpRepo
    {
        private readonly string _conn;

        public EmpRepo(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
        }

        public List<Employee> GetAll()
        {
            var emps = new List<Employee>();
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Employees", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                emps.Add(new Employee
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    DeptId = (int)reader["DeptId"]
                });
            }
            return emps;
        }

        public Employee GetById(int id)
        {
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Employees WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Employee
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    DeptId = (int)reader["DeptId"]
                };
            }
            return null;
        }

        public void Add(Employee emp)
        {
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Employees (Name, Email, DeptId) VALUES (@name, @email, @deptId)", conn);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@deptId", emp.DeptId);
            cmd.ExecuteNonQuery();
        }

        public void Update(Employee emp)
        {
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("UPDATE Employees SET Name = @name, Email = @email, DeptId = @deptId WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@deptId", emp.DeptId);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Employees WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}