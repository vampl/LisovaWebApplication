namespace Lisova.Services.Context.Entities;

public class Department
{
    public string DepartmentCode { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public string? Description { get; set; }

    public IList<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();
}