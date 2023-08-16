using Lisova.Services.Models;
using Lisova.WebAPI.Models;

namespace Lisova.WebAPI.Mappers;

public class EmployeeMapper : IEmployeeMapper
{
    public FullEmployee MapToFullEmployeeModel(Employee employee)
    {
        return new FullEmployee
        {
            EmployeeNo = employee.EmployeeNo,
            Fullname = employee.Fullname,
            BirthDate = employee.BirthDate.Date,
            Location = employee.Location,
            HomeAddress = employee.HomeAddress,
            ContactPhone = employee.ContactPhone
        };
    }

    public FullEmployeePosition MapToFullEmployeePositionModel(EmployeePosition employeePosition)
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

    public FullEmployeeDepartment MapToFullEmployeeDepartmentModel(EmployeeDepartment employeeDepartment)
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

    public AbbreviatedEmployee MapToAbbreviatedEmployeeModel(Employee employee)
    {
        throw new NotImplementedException();
    }

    public AbbreviatedEmployeePosition MapToAbbreviatedEmployeePositionModel(EmployeePosition employeePosition)
    {
        throw new NotImplementedException();
    }

    public AbbreviatedEmployeeDepartment MapToAbbreviatedEmployeeDepartmentModel(EmployeeDepartment employeeDepartment)
    {
        throw new NotImplementedException();
    }
}