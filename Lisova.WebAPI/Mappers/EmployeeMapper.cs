using Lisova.Services.Models;
using Lisova.WebAPI.Models;

namespace Lisova.WebAPI.Mappers;

/// <summary>
/// An utility class implementing IEmployeeMapper to transform data.
/// </summary>
public class EmployeeMapper : IEmployeeMapper
{
    /// <summary>
    /// Map an employee object from repository employee model to full data representation.
    /// </summary>
    /// <param name="employee">The repository employee data to map into full employee model.</param>
    /// <returns>Returns a full employee model with all required fields.</returns>
    public FullEmployee MapToFullEmployee(Employee employee)
    {
        return new FullEmployee
        {
            EmployeeNo = employee.EmployeeNo,
            Fullname = employee.Fullname,
            BirthDate = employee.BirthDate.Date,
            Location = employee.Location,
            HomeAddress = employee.HomeAddress,
            ContactPhone = employee.ContactPhone,
            EmployeePositions = MapToFullEmployeePositions(employee.EmployeePositions),
            EmployeeDepartments = MapToFullEmployeeDepartments(employee.EmployeeDepartments)
        };
    }
    
    /// <summary>
    /// Map an employee object from repository employee model to abbreviated data representation.
    /// </summary>
    /// <param name="employee">The repository employee data to map into abbreviated employee model.</param>
    /// <returns>Returns a abbreviated employee model with all required fields.</returns>
    public AbbreviatedEmployee MapToAbbreviatedEmployee(Employee employee)
    {
        return new AbbreviatedEmployee
        {
            EmployeeNo = employee.EmployeeNo,
            EmployeePositions = MapToAbbreviatedEmployeePositions(employee.EmployeePositions),
            EmployeeDepartments = MapToAbbreviatedEmployeeDepartments(employee.EmployeeDepartments)
        };
    }
    
    /// <summary>
    /// Maps a list of employee position objects from repository model to full data representation.
    /// </summary>
    /// <param name="employeePositions">The list of repository employee positions data to map into full employee position models</param>
    /// <returns>Returns a list of all full employee position models with all required fields.</returns>
    private static IList<FullEmployeePosition> MapToFullEmployeePositions(IList<EmployeePosition> employeePositions)
    {
        return employeePositions.Select(MapToFullEmployeePosition).ToList();
    }

    /// <summary>
    /// Maps a list of employee departments objects from repository model to full data representation.
    /// </summary>
    /// <param name="employeeDepartments">The list of repository employee departments data to map into full employee department models</param>
    /// <returns>Returns a list of all full employee department models with all required fields.</returns>
    private static IList<FullEmployeeDepartment> MapToFullEmployeeDepartments(IList<EmployeeDepartment> employeeDepartments)
    {
        return employeeDepartments.Select(MapToFullEmployeeDepartment).ToList();
    }
    
    /// <summary>
    /// Maps a employee position object from repository model to full data representation.
    /// </summary>
    /// <param name="employeePosition">The repository employee position data to map into full employee position model</param>
    /// <returns>Returns full employee position model with all required fields.</returns>
    private static FullEmployeePosition MapToFullEmployeePosition(EmployeePosition employeePosition)
    {
        return new FullEmployeePosition
        {
            EmployeeNo = employeePosition.EmployeeNo,
            PositionCode = employeePosition.Position.PositionCode,
            PositionName = employeePosition.Position.PositionName,
            Salary = employeePosition.Position.Salary,
            From = employeePosition.From.Date,
            To = employeePosition.To.Date
        };
    }

    /// <summary>
    /// Maps a employee department object from repository model to full data representation.
    /// </summary>
    /// <param name="employeeDepartment">The repository employee department data to map into full employee department model</param>
    /// <returns>Returns full employee department model with all required fields.</returns>
    private static FullEmployeeDepartment MapToFullEmployeeDepartment(EmployeeDepartment employeeDepartment)
    {
        return new FullEmployeeDepartment
        {
            EmployeeNo = employeeDepartment.EmployeeNo,
            DepartmentCode = employeeDepartment.Department.DepartmentCode,
            DepartmentName = employeeDepartment.Department.DepartmentName,
            From = employeeDepartment.From.Date,
            To = employeeDepartment.To.Date
        };
    }
    
    /// <summary>
    /// Maps a list of employee position objects from repository model to abbreviate data representation.
    /// </summary>
    /// <param name="employeePositions">The list of repository employee positions data to map into abbreviate employee position models</param>
    /// <returns>Returns a list of all abbreviate employee position models with all required fields.</returns>
    private static IList<AbbreviatedEmployeePosition> MapToAbbreviatedEmployeePositions(IList<EmployeePosition> employeePositions)
    {
        return employeePositions.Select(MapToAbbreviatedEmployeePosition).ToList();
    }

    /// <summary>
    /// Maps a list of employee departments objects from repository model to abbreviate data representation.
    /// </summary>
    /// <param name="employeeDepartments">The list of repository employee departments data to map into abbreviate employee department models</param>
    /// <returns>Returns a list of all abbreviate employee department models with all required fields.</returns>
    private static IList<AbbreviatedEmployeeDepartment> MapToAbbreviatedEmployeeDepartments(IList<EmployeeDepartment> employeeDepartments)
    {
        return employeeDepartments.Select(MapToAbbreviatedEmployeeDepartment).ToList();
    }
    
    /// <summary>
    /// Maps a employee position object from repository model to abbreviate data representation.
    /// </summary>
    /// <param name="employeePosition">The repository employee position data to map into abbreviate employee position model</param>
    /// <returns>Returns abbreviate employee position model with all required fields.</returns>
    private static AbbreviatedEmployeePosition MapToAbbreviatedEmployeePosition(EmployeePosition employeePosition)
    {
        return new AbbreviatedEmployeePosition
        {
            EmployeeNo = employeePosition.EmployeeNo,
            PositionCode = employeePosition.Position.PositionCode,
        };
    }

    /// <summary>
    /// Maps a employee department object from repository model to abbreviate data representation.
    /// </summary>
    /// <param name="employeeDepartment">The repository employee department data to map into abbreviate employee department model</param>
    /// <returns>Returns abbreviate employee department model with all required fields.</returns>
    private static AbbreviatedEmployeeDepartment MapToAbbreviatedEmployeeDepartment(EmployeeDepartment employeeDepartment)
    {
        return new AbbreviatedEmployeeDepartment
        {
            EmployeeNo = employeeDepartment.EmployeeNo,
            DepartmentCode = employeeDepartment.Department.DepartmentCode,
        };
    }
}