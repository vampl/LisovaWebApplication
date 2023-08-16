using Lisova.Services.Models;
using Lisova.WebAPI.Models;

namespace Lisova.WebAPI.Mappers;

public class EmployeeMapper : IEmployeeMapper
{
    public FullEmployee MapToFullEmployeeModel(Employee employee)
    {
        throw new NotImplementedException();
    }

    public FullEmployeePosition MapToFullEmployeePositionModel(EmployeePosition employeePosition)
    {
        throw new NotImplementedException();
    }

    public FullEmployeeDepartment MapToFullEmployeeDepartmentModel(EmployeeDepartment employeeDepartment)
    {
        throw new NotImplementedException();
    }

    public FullEmployee MapToAbbreviatedEmployeeModel(Employee employee)
    {
        throw new NotImplementedException();
    }

    public FullEmployeePosition MapToAbbreviatedEmployeePositionModel(EmployeePosition employeePosition)
    {
        throw new NotImplementedException();
    }

    public FullEmployeeDepartment MapToAbbreviatedEmployeeDepartmentModel(EmployeeDepartment employeeDepartment)
    {
        throw new NotImplementedException();
    }
}