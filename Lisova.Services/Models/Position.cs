namespace Lisova.Services.Models;

public class Position
{
    public Position(string positionCode)
    {
        PositionCode = positionCode;
    }
    
    public string PositionCode { get; private set; }

    public string PositionName { get; init; } = default!;

    public string? Description { get; init; } = default!;

    public decimal Salary { get; init; } = default!;
}