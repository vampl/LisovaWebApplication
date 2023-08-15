namespace Lisova.Services.Models;

public class EmployeePosition
{
    public EmployeePosition(long employeeNo, Position position)
    {
        EmployeeNo = employeeNo;
        Position = position;
    }
    
    public long EmployeeNo { get; private set; }

    public Position Position { get; private set; }

    public DateTime From { get; init; } = default!;

    public DateTime To { get; init; } = default!;
}