namespace Lisova.Services.Context.Entities;

public class Employee
{
    public long EmployeeNo { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public DateTime BirthDate { get; set; }
    
    public string? Location { get; set; }
    
    public string HomeAddress { get; set; } = null!;
    
    public string ContactPhone { get; set; } = null!;

    public ICollection<EmployeePosition> EmployeePositions { get; set; } = new List<EmployeePosition>();
    
    public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();
}