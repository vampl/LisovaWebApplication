using Lisova.Services.Models;
using Lisova.WebAPI.Models;

namespace Lisova.WebAPI.Mappers;

public class EmployeeMapper : IEmployeeMapper
{
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

    public IList<FullEmployeePosition> MapToFullEmployeePositions(IList<EmployeePosition> employeePositions)
    {
        return employeePositions.Select(MapToFullEmployeePosition).ToList();
    }

    public IList<FullEmployeeDepartment> MapToFullEmployeeDepartments(IList<EmployeeDepartment> employeeDepartments)
    {
        return employeeDepartments.Select(MapToFullEmployeeDepartment).ToList();
    }

    public AbbreviatedEmployee MapToAbbreviatedEmployee(Employee employee)
    {
        return new AbbreviatedEmployee
        {
            EmployeeNo = employee.EmployeeNo,
            EmployeePositions = MapToAbbreviatedEmployeePositions(employee.EmployeePositions),
            EmployeeDepartments = MapToAbbreviatedEmployeeDepartments(employee.EmployeeDepartments)
        };
    }

    public IList<AbbreviatedEmployeePosition> MapToAbbreviatedEmployeePositions(IList<EmployeePosition> employeePositions)
    {
        return employeePositions.Select(MapToAbbreviatedEmployeePosition).ToList();
    }

    public IList<AbbreviatedEmployeeDepartment> MapToAbbreviatedEmployeeDepartments(IList<EmployeeDepartment> employeeDepartments)
    {
        return employeeDepartments.Select(MapToAbbreviatedEmployeeDepartment).ToList();
    }
    
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
    
    private static AbbreviatedEmployeePosition MapToAbbreviatedEmployeePosition(EmployeePosition employeePosition)
    {
        return new AbbreviatedEmployeePosition
        {
            EmployeeNo = employeePosition.EmployeeNo,
            PositionCode = employeePosition.Position.PositionCode,
        };
    }

    private static AbbreviatedEmployeeDepartment MapToAbbreviatedEmployeeDepartment(EmployeeDepartment employeeDepartment)
    {
        return new AbbreviatedEmployeeDepartment
        {
            EmployeeNo = employeeDepartment.EmployeeNo,
            DepartmentCode = employeeDepartment.Department.DepartmentCode,
        };
    }
}