namespace Lisova.Services.Models;

public class Department
{
    public Department(string departmentCode)
    {
        DepartmentCode = departmentCode;
    }
    
    public string DepartmentCode { get; private set; }

    public string DepartmentName { get; init; } = default!;

    public string? Description { get; init; } = default!;
}