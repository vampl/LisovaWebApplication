namespace Lisova.Services.Context.Entities;

public class EmployeePosition
{
    public long EmployeeNo { get; set; }

    public string PositionCode { get; set; } = null!;

    public DateTime From { get; set; }
    
    public DateTime To { get; set; }

    public Employee Employee { get; set; } = null!;

    public Position Position { get; set; } = null!;
}