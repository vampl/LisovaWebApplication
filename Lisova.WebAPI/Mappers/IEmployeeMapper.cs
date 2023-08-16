using Lisova.Services.Models;
using Lisova.WebAPI.Models;

namespace Lisova.WebAPI.Mappers;

public interface IEmployeeMapper
{
    public FullEmployee MapToFullEmployeeModel(Employee employee);

    public FullEmployeePosition MapToFullEmployeePositionModel(EmployeePosition employeePosition);

    public FullEmployeeDepartment MapToFullEmployeeDepartmentModel(EmployeeDepartment employeeDepartment);
    
    public AbbreviatedEmployee MapToAbbreviatedEmployeeModel(Employee employee);

    public AbbreviatedEmployeePosition MapToAbbreviatedEmployeePositionModel(EmployeePosition employeePosition);

    public AbbreviatedEmployeeDepartment MapToAbbreviatedEmployeeDepartmentModel(EmployeeDepartment employeeDepartment);
}