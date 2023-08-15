namespace Lisova.Services.Models;

public class Employee
{
    public Employee(long employeeNo)
    {
        EmployeeNo = employeeNo;
    }
    
    public long EmployeeNo { get; private set; }
    
    public string Fullname { get; init; } = null!;

    public DateTime BirthDate { get; init; }

    public string? Location { get; init; }

    public string HomeAddress { get; init; } = null!;

    public string ContactPhone { get; init; } = null!;

    public IList<EmployeePosition> EmployeePositions { get; } = new List<EmployeePosition>();

    public IList<EmployeeDepartment> EmployeeDepartments { get; } = new List<EmployeeDepartment>();
}