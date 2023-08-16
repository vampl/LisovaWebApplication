namespace Lisova.WebAPI.Models;

public class FullEmployee
{
    public long EmployeeNo { get; set; }

    public string Fullname { get; set; } = default!;

    public DateTime BirthDate { get; init; }

    public string? Location { get; init; }

    public string HomeAddress { get; init; } = default!;

    public string ContactPhone { get; init; } = default!;

    public IList<FullEmployeePosition> EmployeePositions { get; set; } = default!;

    public IList<FullEmployeePosition> EmployeeDepartments { get; set; } = default!;
}