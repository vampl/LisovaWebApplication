namespace Lisova.Services.Context.Entities;

public class EmployeeDepartment
{
    public long EmployeeNo { get; set; }

    public string DepartmentCode { get; set; } = null!;

    public DateTime From { get; set; }
    
    public DateTime To { get; set; }

    public Employee Employee { get; set; } = null!;

    public Department Department { get; set; } = null!;
}