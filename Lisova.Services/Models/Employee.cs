namespace Lisova.Services.Models;

public class Employee
{
    public Employee(long employeeNo)
    {
        EmployeeNo = employeeNo;
    }
    
    public long EmployeeNo { get; private set; }
    
    public string Fullname { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string? Location { get; set; }

    public string HomeAddress { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public ICollection<EmployeePosition> EmployeePositions { get; } = new List<EmployeePosition>();

    public ICollection<EmployeeDepartment> EmployeeDepartments { get; } = new List<EmployeeDepartment>();
}