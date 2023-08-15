namespace Lisova.Services.Models;

public class EmployeeDepartment
{
    public EmployeeDepartment(long employeeNo, Department department)
    {
        EmployeeNo = employeeNo;
        Department = department;
    }
    
    public long EmployeeNo { get; private set; }

    public Department Department { get; private set; }

    public DateTime From { get; init; }
    
    public DateTime To { get; init; }
}