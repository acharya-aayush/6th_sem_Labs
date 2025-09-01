# Lab 5: MVC Employee & Department Management System

## Models

### 1. Employee Model
**File Path:** `Lab5/Models/Employee.cs`

```csharp
namespace Lab5.Models;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Position { get; set; } = "";
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
}
```

### 2. Department Model
**File Path:** `Lab5/Models/Department.cs`

```csharp
namespace Lab5.Models;
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Manager { get; set; } = "";
}
```

## Service Interfaces

### 3. Department Interface
**File Path:** `Lab5/Services/IDepartmentRepository.cs`

```csharp
using Lab5.Models;
namespace Lab5.Services;
public interface IDepartmentRepository
{
    List<Department> GetAll();
    Department? GetById(int id);
    void Add(Department department);
    void Update(Department department);
    void Delete(int id);
}
```

### 4. Employee Interface
**File Path:** `Lab5/Services/IEmployeeRepository.cs`

```csharp
using Lab5.Models;
namespace Lab5.Services;
public interface IEmployeeRepository
{
    List<Employee> GetAll();
    Employee? GetById(int id);
    void Add(Employee employee);
    void Update(Employee employee);
    void Delete(int id);
}
```

## Service Implementations

### 5. Department Repository
**File Path:** `Lab5/Services/DepartmentRepository.cs`

```csharp
using Lab5.Models;
namespace Lab5.Services;
public class DepartmentRepository : IDepartmentRepository
{
    private readonly List<Department> _departments = new()
    {
        new() { Id = 1, Name = "IT", Description = "Tech", Manager = "John" },
        new() { Id = 2, Name = "HR", Description = "People", Manager = "Jane" }
    };

    public List<Department> GetAll() => _departments;
    public Department? GetById(int id) => _departments.Find(d => d.Id == id);
    public void Add(Department d) { d.Id = _departments.Max(x => x.Id) + 1; _departments.Add(d); }
    public void Update(Department d) { var e = GetById(d.Id); if (e != null) { e.Name = d.Name; e.Description = d.Description; e.Manager = d.Manager; } }
    public void Delete(int id) { var d = GetById(id); if (d != null) _departments.Remove(d); }
}
```

### 6. Employee Repository
**File Path:** `Lab5/Services/EmployeeRepository.cs`

```csharp
using Lab5.Models;
namespace Lab5.Services;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new()
    {
        new() { Id = 1, Name = "John", Position = "Dev", Salary = 50000, DepartmentId = 1 },
        new() { Id = 2, Name = "Jane", Position = "Manager", Salary = 60000, DepartmentId = 2 }
    };

    public List<Employee> GetAll() => _employees;
    public Employee? GetById(int id) => _employees.Find(e => e.Id == id);
    public void Add(Employee e) { e.Id = _employees.Max(x => x.Id) + 1; _employees.Add(e); }
    public void Update(Employee e) { var ex = GetById(e.Id); if (ex != null) { ex.Name = e.Name; ex.Position = e.Position; ex.Salary = e.Salary; ex.DepartmentId = e.DepartmentId; } }
    public void Delete(int id) { var e = GetById(id); if (e != null) _employees.Remove(e); }
}
```

## Controllers

### 7. Department Controller
**File Path:** `Lab5/Controllers/DepartmentController.cs`

```csharp
using Lab5.Models;
using Lab5.Services;
using Microsoft.AspNetCore.Mvc;
namespace Lab5.Controllers;
public class DepartmentController : Controller
{
    private readonly IDepartmentRepository _repo;
    public DepartmentController(IDepartmentRepository repo) => _repo = repo;
    public IActionResult Index() => View(_repo.GetAll());
    public IActionResult Create() => View();
    [HttpPost] public IActionResult Create(Department d) => ModelState.IsValid ? (_repo.Add(d), RedirectToAction("Index")) : View(d);
    public IActionResult Edit(int id) => View(_repo.GetById(id));
    [HttpPost] public IActionResult Edit(Department d) => ModelState.IsValid ? (_repo.Update(d), RedirectToAction("Index")) : View(d);
    public IActionResult Delete(int id) { _repo.Delete(id); return RedirectToAction("Index"); }
}
```

### 8. Employee Controller
**File Path:** `Lab5/Controllers/EmployeeController.cs`

```csharp
using Lab5.Models;
using Lab5.Services;
using Microsoft.AspNetCore.Mvc;
namespace Lab5.Controllers;
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _repo;
    public EmployeeController(IEmployeeRepository repo) => _repo = repo;
    public IActionResult Index() => View(_repo.GetAll());
    public IActionResult Create() => View();
    [HttpPost] public IActionResult Create(Employee e) => ModelState.IsValid ? (_repo.Add(e), RedirectToAction("Index")) : View(e);
    public IActionResult Edit(int id) => View(_repo.GetById(id));
    [HttpPost] public IActionResult Edit(Employee e) => ModelState.IsValid ? (_repo.Update(e), RedirectToAction("Index")) : View(e);
    public IActionResult Delete(int id) { _repo.Delete(id); return RedirectToAction("Index"); }
}
```

## Configuration

### 9. Program.cs
**File Path:** `Lab5/Program.cs`

```csharp
using Lab5.Services;
var b = WebApplication.CreateBuilder(args);
b.Services.AddControllersWithViews();
b.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
b.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
var app = b.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
```

## View Infrastructure

### 10. ViewStart
**File Path:** `Lab5/Views/_ViewStart.cshtml`
```html
@{ Layout = "_Layout"; }
```

### 11. ViewImports
**File Path:** `Lab5/Views/_ViewImports.cshtml`
```html
@using Lab5.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

### 12. Layout
**File Path:** `Lab5/Views/Shared/_Layout.cshtml`
```html
<!DOCTYPE html>
<html>
<head><title>@ViewData["Title"] - Lab5</title></head>
<body>
    <nav>
        <a asp-controller="Home" asp-action="Index">Home</a> |
        <a asp-controller="Department" asp-action="Index">Departments</a> |
        <a asp-controller="Employee" asp-action="Index">Employees</a>
    </nav>
    @RenderBody()
</body>
</html>
```

## Department Views

### 13. Department Index
**File Path:** `Lab5/Views/Department/Index.cshtml`
```html
@model IEnumerable<Department>
<h2>Departments</h2>
<a asp-action="Create">Add New</a>
<table border="1">
    <tr><th>Name</th><th>Description</th><th>Manager</th><th>Actions</th></tr>
    @foreach (var d in Model)
    {
        <tr>
            <td>@d.Name</td>
            <td>@d.Description</td>
            <td>@d.Manager</td>
            <td><a asp-action="Edit" asp-route-id="@d.Id">Edit</a> | <a asp-action="Delete" asp-route-id="@d.Id">Delete</a></td>
        </tr>
    }
</table>
```

### 14. Department Create
**File Path:** `Lab5/Views/Department/Create.cshtml`
```html
@model Department
<h2>Add Department</h2>
<form asp-action="Create" method="post">
    Name: <input asp-for="Name" /><br>
    Description: <input asp-for="Description" /><br>
    Manager: <input asp-for="Manager" /><br>
    <button type="submit">Save</button>
    <a asp-action="Index">Cancel</a>
</form>
```

### 15. Department Edit
**File Path:** `Lab5/Views/Department/Edit.cshtml`
```html
@model Department
<h2>Edit Department</h2>
<form asp-action="Edit" method="post">
    <input type="hidden" asp-for="Id" />
    Name: <input asp-for="Name" /><br>
    Description: <input asp-for="Description" /><br>
    Manager: <input asp-for="Manager" /><br>
    <button type="submit">Save</button>
    <a asp-action="Index">Cancel</a>
</form>
```

## Employee Views

### 16. Employee Index
**File Path:** `Lab5/Views/Employee/Index.cshtml`
```html
@model IEnumerable<Employee>
<h2>Employees</h2>
<a asp-action="Create">Add New</a>
<table border="1">
    <tr><th>Name</th><th>Position</th><th>Salary</th><th>Dept</th><th>Actions</th></tr>
    @foreach (var e in Model)
    {
        <tr>
            <td>@e.Name</td>
            <td>@e.Position</td>
            <td>@e.Salary</td>
            <td>@e.DepartmentId</td>
            <td><a asp-action="Edit" asp-route-id="@e.Id">Edit</a> | <a asp-action="Delete" asp-route-id="@e.Id">Delete</a></td>
        </tr>
    }
</table>
```

### 17. Employee Create
**File Path:** `Lab5/Views/Employee/Create.cshtml`
```html
@model Employee
<h2>Add Employee</h2>
<form asp-action="Create" method="post">
    Name: <input asp-for="Name" /><br>
    Position: <input asp-for="Position" /><br>
    Salary: <input asp-for="Salary" type="number" step="0.01" /><br>
    Department ID: <input asp-for="DepartmentId" type="number" /><br>
    <button type="submit">Save</button>
    <a asp-action="Index">Cancel</a>
</form>
```

### 18. Employee Edit
**File Path:** `Lab5/Views/Employee/Edit.cshtml`
```html
@model Employee
<h2>Edit Employee</h2>
<form asp-action="Edit" method="post">
    <input type="hidden" asp-for="Id" />
    Name: <input asp-for="Name" /><br>
    Position: <input asp-for="Position" /><br>
    Salary: <input asp-for="Salary" type="number" step="0.01" /><br>
    Department ID: <input asp-for="DepartmentId" type="number" /><br>
    <button type="submit">Save</button>
    <a asp-action="Index">Cancel</a>
</form>
```