using Lisova.Services.Models;
using Lisova.WebAPI.Models;

namespace Lisova.WebAPI.Mappers;

public interface IEmployeeMapper
{
    public FullEmployee MapToFullEmployeeModel(Employee employee);

    public FullEmployeePosition MapToFullEmployeePositionModel(EmployeePosition employeePosition);

    public FullEmployeeDepartment MapToFullEmployeeDepartmentModel(EmployeeDepartment employeeDepartment);
    
    public FullEmployee MapToAbbreviatedEmployeeModel(Employee employee);

    public FullEmployeePosition MapToAbbreviatedEmployeePositionModel(EmployeePosition employeePosition);

    public FullEmployeeDepartment MapToAbbreviatedEmployeeDepartmentModel(EmployeeDepartment employeeDepartment);
}