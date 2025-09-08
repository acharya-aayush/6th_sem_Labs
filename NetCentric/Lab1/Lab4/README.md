# Lab 4: Employee Management System

## Files to Write in Order

### 1. Model
**File Path:** `Lab4/Models/Employee.cs`
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = "";
        
        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; } = "";
        
        [Required(ErrorMessage = "Age is required")]
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int Age { get; set; }
        
        [Required(ErrorMessage = "Salary is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0")]
        public decimal Salary { get; set; }
    }
}
### 2. Controller
**File Path:** `Lab4/Controllers/EmployeeController.cs`
using Lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new()
        {
            new() { Id = 1, Name = "Aayush Acharya", Email = "aayush@gmail.com", Position = "Developer", Age = 20, Salary = 65000 },
            new() { Id = 2, Name = "Aarjanmani Kandel", Email = "aarjan@gmail.com", Position = "Manager", Age = 22, Salary = 75000 },
            new() { Id = 3, Name = "Swornimraj Dangol", Email = "sworn@gmail.com", Position = "Analyst", Age = 21, Salary = 60000 },
            new() { Id = 4, Name = "Nilima Shrestha", Email = "nilima@gmail.com", Position = "HR", Age = 22, Salary = 70000 },
            new() { Id = 5, Name = "Shiksha Karki", Email = "shiksha@gmail.com", Position = "Marketing", Age = 20, Salary = 55000 }
        };
        static int nextId = 6;

        public IActionResult Index() => View(employees);
        
        public IActionResult Create() => View();
        
        [HttpPost] 
        public IActionResult Create(Employee e) 
        { 
            if (ModelState.IsValid)
            {
                e.Id = nextId++; 
                employees.Add(e); 
                return RedirectToAction("Index"); 
            }
            return View(e);
        }
        
        public IActionResult Edit(int id) => View(employees.Find(e => e.Id == id));
        
        [HttpPost] 
        public IActionResult Edit(Employee e) 
        { 
            if (ModelState.IsValid)
            {
                var old = employees.Find(x => x.Id == e.Id); 
                if(old != null) 
                { 
                    old.Name = e.Name; 
                    old.Email = e.Email; 
                    old.Position = e.Position; 
                    old.Age = e.Age; 
                    old.Salary = e.Salary; 
                } 
                return RedirectToAction("Index"); 
            }
            return View(e);
        }
        
        [HttpPost] 
        public IActionResult Delete(int id) 
        { 
            employees.RemoveAll(e => e.Id == id); 
            return RedirectToAction("Index"); 
        }
    }
}
### 3. Views

#### 3a. Index View
**File Path:** `Lab4/Views/Employee/Index.cshtml`
@model List<Lab4.Models.Employee>

<h2>Employees</h2>
<a href="/Employee/Create" class="btn btn-primary">Add</a>

<table class="table">
    <thead>
        <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Position</th>
            <th>Age</th>
            <th>Salary</th>
            <th>Actions</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var e in Model)
        {
            <tr>
                <td>@e.Name</td>
                <td>@e.Email</td>
                <td>@e.Position</td>
                <td>@e.Age</td>
                <td>$@e.Salary</td>
                <td>
                    <a href="/Employee/Edit/@e.Id" class="btn btn-sm btn-warning">Edit</a>
                    <form method="post" action="/Employee/Delete" style="display:inline">
                        <input name="id" type="hidden" value="@e.Id">
                        <button class="btn btn-sm btn-danger">Delete</button>
                    </form>
                </td>
            </tr>
        }
    </tbody>
</table>
#### 3b. Create View
**File Path:** `Lab4/Views/Employee/Create.cshtml`
@model Lab4.Models.Employee

<h2>Add Employee</h2>

<form method="post">
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
    
    <div class="form-group">
        <input asp-for="Name" placeholder="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    
    <div class="form-group">
        <input asp-for="Email" placeholder="Email" class="form-control" />
        <span asp-validation-for="Email" class="text-danger"></span>
    </div>
    
    <div class="form-group">
        <input asp-for="Position" placeholder="Position" class="form-control" />
        <span asp-validation-for="Position" class="text-danger"></span>
    </div>
    
    <div class="form-group">
        <input asp-for="Age" type="number" placeholder="Age" class="form-control" />
        <span asp-validation-for="Age" class="text-danger"></span>
    </div>
    
    <div class="form-group">
        <input asp-for="Salary" type="number" step="0.01" placeholder="Salary" class="form-control" />
        <span asp-validation-for="Salary" class="text-danger"></span>
    </div>
    
    <button class="btn btn-primary">Save</button>
    <a href="/Employee" class="btn btn-secondary">Cancel</a>
</form>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
#### 3c. Edit View
**File Path:** `Lab4/Views/Employee/Edit.cshtml`
@model Lab4.Models.Employee

<h2>Edit Employee</h2>

<form method="post">
    <input asp-for="Id" type="hidden" />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
    
    <div class="form-group">
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    
    <div class="form-group">
        <input asp-for="Email" class="form-control" />
        <span asp-validation-for="Email" class="text-danger"></span>
    </div>
    
    <div class="form-group">
        <input asp-for="Position" class="form-control" />
        <span asp-validation-for="Position" class="text-danger"></span>
    </div>
    
    <div class="form-group">
        <input asp-for="Age" type="number" class="form-control" />
        <span asp-validation-for="Age" class="text-danger"></span>
    </div>
    
    <div class="form-group">
        <input asp-for="Salary" type="number" step="0.01" class="form-control" />
        <span asp-validation-for="Salary" class="text-danger"></span>
    </div>
    
    <button class="btn btn-primary">Update</button>
    <a href="/Employee" class="btn btn-secondary">Cancel</a>
</form>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
## Writing Order:
1. Employee.cs (Model with validation)
2. EmployeeController.cs (CRUD operations)
3. Index.cshtml (List view)
4. Create.cshtml (Add form)
5. Edit.cshtml (Edit form)