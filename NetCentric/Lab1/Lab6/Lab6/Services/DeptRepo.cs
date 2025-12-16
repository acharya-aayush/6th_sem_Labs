using Lab6.Models;
using Microsoft.Data.SqlClient;

namespace Lab6.Services
{
    public class DeptRepo : IDeptRepo
    {
        private readonly string _conn;

        public DeptRepo(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
        }

        public List<Department> GetAll()
        {
            var depts = new List<Department>();
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Departments", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                depts.Add(new Department
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                });
            }
            return depts;
        }

        public Department GetById(int id)
        {
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Departments WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Department
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };
            }
            return null;
        }

        public void Add(Department dept)
        {
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Departments (Name) VALUES (@name)", conn);
            cmd.Parameters.AddWithValue("@name", dept.Name);
            cmd.ExecuteNonQuery();
        }

        public void Update(Department dept)
        {
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("UPDATE Departments SET Name = @name WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", dept.Id);
            cmd.Parameters.AddWithValue("@name", dept.Name);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_conn);
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Departments WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}