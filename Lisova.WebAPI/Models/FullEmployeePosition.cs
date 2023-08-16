namespace Lisova.WebAPI.Models;

public class FullEmployeePosition
{
    public long EmployeeNo { get; set; }

    public string PositionCode { get; set; } = default!;

    public string PositionName { get; set; } = default!;

    public decimal Salary { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }
}