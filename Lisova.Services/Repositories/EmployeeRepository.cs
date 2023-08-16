using Lisova.Services.Context.Data;
using ContextEmployee = Lisova.Services.Context.Entities.Employee;
using ContextEmployeePosition = Lisova.Services.Context.Entities.EmployeePosition;
using ContextEmployeeDepartment = Lisova.Services.Context.Entities.EmployeeDepartment;
using ContextPosition = Lisova.Services.Context.Entities.Position;
using ContextDepartment = Lisova.Services.Context.Entities.Department;
using RepositoryEmployee = Lisova.Services.Models.Employee;
using RepositoryEmployeePosition = Lisova.Services.Models.EmployeePosition;
using RepositoryEmployeeDepartment = Lisova.Services.Models.EmployeeDepartment;
using RepositoryPosition = Lisova.Services.Models.Position;
using RepositoryDepartment = Lisova.Services.Models.Department;

namespace Lisova.Services.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly LisovaContext _lisovaContext;
    
    public EmployeeRepository(LisovaContext lisovaContext)
    {
        _lisovaContext = lisovaContext;
    }
    
    public IList<RepositoryEmployee> GetAll()
    {
        return GetEmployeesData();
    }

    public IList<RepositoryEmployee> GetRange(int skip, int count)
    {
        if (skip < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(skip), $"{nameof(skip)} must be non less that zero.");
        }
        
        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} must be non less or equal zero.");
        }

        return GetEmployeesData().Skip(skip).Take(count).ToList();
    }
    
    public RepositoryEmployee GetBy(long employeeNo)
    {
        if (_lisovaContext.Employees.FirstOrDefault(e => e.EmployeeNo == employeeNo) is null)
        {
            throw new ArgumentNullException(nameof(employeeNo), $"{nameof(employeeNo)} does not belong to any record.");
        }
        
        return GetEmployeesData().Single(e => e.EmployeeNo == employeeNo);
    }

    private IList<RepositoryEmployee> GetEmployeesData()
    {
        var employeeRecords = _lisovaContext.Employees.ToList();
        var employees = new List<RepositoryEmployee>();

        foreach (var employeeRecord in employeeRecords)
        {
            var employee = MapEmployee(employeeRecord);
            GetEmployeePositionsData(employeeRecord, employee);
            GetEmployeeDepartmentsData(employeeRecord, employee);
            
            employees.Add(employee);
        }
        
        return employees;
    }

    private static RepositoryEmployee MapEmployee(ContextEmployee employeeRecord)
    {
        return new RepositoryEmployee(employeeRecord.EmployeeNo)
            {
                Fullname = $"{employeeRecord.FirstName} {employeeRecord.LastName}",
                BirthDate = employeeRecord.BirthDate,
                Location = employeeRecord.Location,
                HomeAddress = employeeRecord.HomeAddress,
                ContactPhone = employeeRecord.ContactPhone
            };
    }
    
    private static RepositoryEmployeePosition MapEmployeePosition(
        ContextEmployeePosition employeePositionRecord,
        RepositoryPosition position)
    {
        return new RepositoryEmployeePosition(employeePositionRecord.EmployeeNo, position)
            { From = employeePositionRecord.From, To = employeePositionRecord.To };
    }
    
    private static RepositoryEmployeeDepartment MapEmployeeDepartment(
        ContextEmployeeDepartment employeeDepartmentRecord, 
        RepositoryDepartment department)
    {
        return new RepositoryEmployeeDepartment(employeeDepartmentRecord.EmployeeNo, department)
            { From = employeeDepartmentRecord.From, To = employeeDepartmentRecord.To };
    }

    private static RepositoryPosition MapPosition(ContextPosition positionRecord)
    {
        return new RepositoryPosition(positionRecord.PositionCode)
        {
            PositionName = positionRecord.PositionName, Description = positionRecord.Description,
            Salary = positionRecord.Salary
        };
    }
    
    private static RepositoryDepartment MapDepartment(ContextDepartment departmentRecord)
    {
        return new RepositoryDepartment(departmentRecord.DepartmentCode)
            { DepartmentName = departmentRecord.DepartmentName, Description = departmentRecord.Description };
    }

    private void GetEmployeePositionsData(ContextEmployee employeeRecord, RepositoryEmployee employee)
    {
        var employeePositionRecords = _lisovaContext.EmployeePositions
            .Where(ep => ep.EmployeeNo == employeeRecord.EmployeeNo)
            .ToList();
        
        foreach (var employeePositionRecord in employeePositionRecords)
        {
            var positionRecord = _lisovaContext.Positions
                .Single(p => p.PositionCode == employeePositionRecord.PositionCode);
            
            var position = MapPosition(positionRecord);
            var employeePosition = MapEmployeePosition(employeePositionRecord, position);
            
            employee.EmployeePositions.Add(employeePosition);
        }
    }
    
    private void GetEmployeeDepartmentsData(ContextEmployee employeeRecord, RepositoryEmployee employee)
    {
        var employeeDepartmentRecords = _lisovaContext.EmployeeDepartments
            .Where(ep => ep.EmployeeNo == employeeRecord.EmployeeNo)
            .ToList();
        
        foreach (var employeeDepartmentRecord in employeeDepartmentRecords)
        {
            var departmentRecord = _lisovaContext.Departments
                .Single(d => d.DepartmentCode == employeeDepartmentRecord.DepartmentCode);

            var department = MapDepartment(departmentRecord);
            var employeeDepartment = MapEmployeeDepartment(employeeDepartmentRecord, department);
            
            employee.EmployeeDepartments.Add(employeeDepartment);
        }
    }
}