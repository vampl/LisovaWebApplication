using Lisova.Services.Models;

namespace Lisova.Services.Repositories;

/// <summary>
/// Represents a repository for storing a collection of objects of the <see cref="Employee"/> type.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Gets collection of all employees records in database.
    /// </summary>
    /// <returns>Returns collection of employees.</returns>
    public IList<Employee> GetAll();

    /// <summary>
    /// Gets collection of employees in specified range of records in database.
    /// </summary>
    /// <param name="skip">The number of employee records to skip before adding an employee to the result collection.</param>
    /// <param name="count">The number of employee records in the result collection.</param>
    /// <returns></returns>
    public IList<Employee> GetRange(int skip, int count);
    
    /// <summary>
    /// Get single employee record by its `employeeNo` in database.
    /// </summary>
    /// <param name="employeeNo">The unique identifier of an employee.</param>
    /// <returns></returns>
    public Employee GetBy(long employeeNo);
}