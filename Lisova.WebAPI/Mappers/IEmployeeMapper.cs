using Lisova.Services.Models;
using Lisova.WebAPI.Models;

namespace Lisova.WebAPI.Mappers;

public interface IEmployeeMapper
{
    public FullEmployee MapToFullEmployee(Employee employee);

    public IList<FullEmployeePosition> MapToFullEmployeePositions(IList<EmployeePosition> employeePositions);
    
    public IList<FullEmployeeDepartment> MapToFullEmployeeDepartments(IList<EmployeeDepartment> employeeDepartments);
    
    public AbbreviatedEmployee MapToAbbreviatedEmployee(Employee employee);

    public IList<AbbreviatedEmployeePosition> MapToAbbreviatedEmployeePositions(IList<EmployeePosition> employeePositions);

    public IList<AbbreviatedEmployeeDepartment> MapToAbbreviatedEmployeeDepartments(IList<EmployeeDepartment> employeeDepartments);
}