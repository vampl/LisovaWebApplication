namespace Lisova.WebAPI.Models;

public class FullEmployee
{
    public long EmployeeNo { get; set; }

    public string Fullname { get; set; } = default!;

    public DateTime BirthDate { get; set; }

    public string? Location { get; set; }

    public string HomeAddress { get; set; } = default!;

    public string ContactPhone { get; set; } = default!;

    public IList<FullEmployeePosition> EmployeePositions { get; set; } = default!;

    public IList<FullEmployeeDepartment> EmployeeDepartments { get; set; } = default!;
}