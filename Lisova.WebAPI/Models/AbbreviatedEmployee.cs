namespace Lisova.WebAPI.Models;

public class AbbreviatedEmployee
{
    public long EmployeeNo { get; set; }

    public IList<AbbreviatedEmployeePosition> EmployeePositions { get; set; } = default!;

    public IList<AbbreviatedEmployeeDepartment> EmployeeDepartments { get; set; } = default!;
}