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

/// <summary>
/// Represents a repository for storing a collection of objects of the <see cref="RepositoryEmployee"/> type.
/// </summary>
public class EmployeeRepository : IEmployeeRepository
{
    private readonly LisovaContext _lisovaContext;
    
    /// <summary>
    /// Creates an instance of repository. Injects context for data access.
    /// </summary>
    /// <param name="lisovaContext">The entity framework context to access data from database.</param>
    public EmployeeRepository(LisovaContext lisovaContext)
    {
        _lisovaContext = lisovaContext;
    }
    
    /// <summary>
    /// Gets all employees data from context.
    /// </summary>
    /// <returns></returns>
    public IList<RepositoryEmployee> GetAll()
    {
        return GetEmployeesData();
    }

    /// <summary>
    /// Gets list of employees in range defined by <see cref="skip"/> and <see cref="count"/>.
    /// </summary>
    /// <param name="skip">The quantity of employees to be skipped.</param>
    /// <param name="count">The quantity of employees to be got.</param>
    /// <returns>Returns list of employees in specified range.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If the <see cref="skip"/> quantity is less than zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException">If the <see cref="count"/> quantity is less or equal to zero.</exception>
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
    
    /// <summary>
    /// Gets an employee instance by its identifier.
    /// </summary>
    /// <param name="employeeNo">The identifier of instance to be received.</param>
    /// <returns>Returns an employee instance by its identifier.</returns>
    /// <exception cref="ArgumentNullException">If the <see cref="employeeNo"/> does not belong to any record.</exception>
    public RepositoryEmployee GetBy(long employeeNo)
    {
        if (_lisovaContext.Employees.FirstOrDefault(e => e.EmployeeNo == employeeNo) is null)
        {
            throw new ArgumentNullException(nameof(employeeNo), $"{nameof(employeeNo)} does not belong to any record.");
        }
        
        return GetEmployeesData().Single(e => e.EmployeeNo == employeeNo);
    }

    /// <summary>
    /// Maps repository model by employee context data.
    /// </summary>
    /// <param name="employeeRecord">The record of employee in context entity model.</param>
    /// <returns>Returns mapped repository model of an employee.</returns>
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
    
    /// <summary>
    /// Maps repository model by employee position context data.
    /// </summary>
    /// <param name="employeePositionRecord">The record of employee position in context entity model.</param>
    /// <param name="position">The mapped instance of position data to be inserted.</param>
    /// <returns>Returns mapped repository model of an employee position.</returns>
    private static RepositoryEmployeePosition MapEmployeePosition(
        ContextEmployeePosition employeePositionRecord,
        RepositoryPosition position)
    {
        return new RepositoryEmployeePosition(employeePositionRecord.EmployeeNo, position)
            { From = employeePositionRecord.From, To = employeePositionRecord.To };
    }
    
    /// <summary>
    /// Maps repository model by employee department context data.
    /// </summary>
    /// <param name="employeeDepartmentRecord">The record of employee department in context entity model.</param>
    /// <param name="department">The mapped instance of department data to be inserted.</param>
    /// <returns>Returns mapped repository model of an employee department.</returns>
    private static RepositoryEmployeeDepartment MapEmployeeDepartment(
        ContextEmployeeDepartment employeeDepartmentRecord, 
        RepositoryDepartment department)
    {
        return new RepositoryEmployeeDepartment(employeeDepartmentRecord.EmployeeNo, department)
            { From = employeeDepartmentRecord.From, To = employeeDepartmentRecord.To };
    }

    /// <summary>
    /// Maps repository model by position context data.
    /// </summary>
    /// <param name="positionRecord">The record of position in context entity model.</param>
    /// <returns>Returns mapped repository model of a position.</returns>
    private static RepositoryPosition MapPosition(ContextPosition positionRecord)
    {
        return new RepositoryPosition(positionRecord.PositionCode)
        {
            PositionName = positionRecord.PositionName, Description = positionRecord.Description,
            Salary = positionRecord.Salary
        };
    }
    
    /// <summary>
    /// Maps repository model by department context data.
    /// </summary>
    /// <param name="departmentRecord">The record of department in context entity model.</param>
    /// <returns>Returns mapped repository model of a department.</returns>
    private static RepositoryDepartment MapDepartment(ContextDepartment departmentRecord)
    {
        return new RepositoryDepartment(departmentRecord.DepartmentCode)
            { DepartmentName = departmentRecord.DepartmentName, Description = departmentRecord.Description };
    }

    /// <summary>
    /// Gets all employees data and mapping it to repository model.
    /// </summary>
    /// <returns>Returns list of all employees in repository model representation.</returns>
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
    
    /// <summary>
    /// Gets employee position data and assigning to repository employee model.
    /// </summary>
    /// <param name="employeeRecord">The context instance to get employee position data from.</param>
    /// <param name="employee">The instance of repository model to assign employee position data.</param>
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
    
    /// <summary>
    /// Gets employee department data and assigning to repository employee model.
    /// </summary>
    /// <param name="employeeRecord">The context instance to get employee department data from.</param>
    /// <param name="employee">The instance of repository model to assign employee department data.</param>
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