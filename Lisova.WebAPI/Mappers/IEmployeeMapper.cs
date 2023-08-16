using Lisova.Services.Models;
using Lisova.WebAPI.Models;

namespace Lisova.WebAPI.Mappers;

/// <summary>
/// Represents an utility to map data from repository to request different data formats.
/// </summary>
public interface IEmployeeMapper
{
    /// <summary>
    /// Map an employee object from repository employee model to full data representation.
    /// </summary>
    /// <param name="employee">The repository employee data to map into full employee model.</param>
    /// <returns>Returns a full employee model with all required fields.</returns>
    public FullEmployee MapToFullEmployee(Employee employee);

    /// <summary>
    /// Map an employee object from repository employee model to abbreviated data representation.
    /// </summary>
    /// <param name="employee">The repository employee data to map into abbreviated employee model.</param>
    /// <returns>Returns a abbreviated employee model with all required fields.</returns>
    public AbbreviatedEmployee MapToAbbreviatedEmployee(Employee employee);
}