namespace Lisova.WebAPI.Models;

public class FullEmployeeDepartment
{
    public long EmployeeNo { get; set; }

    public string DepartmentCode { get; set; } = default!;

    public string DepartmentName { get; set; } = default!;

    public DateTime From { get; set; }
    
    public DateTime To { get; set; }
}