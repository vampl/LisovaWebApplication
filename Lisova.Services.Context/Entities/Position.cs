namespace Lisova.Services.Context.Entities;

public class Position
{
    public string PositionCode { get; set; } = null!;

    public string PositionName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Salary { get; set; }

    public ICollection<EmployeePosition> EmployeePositions { get; set; } = new List<EmployeePosition>();
}