using Lisova.Services.Context.Data;
using Lisova.Services.Models;

namespace Lisova.Services.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly LisovaContext _lisovaContext;
    
    public EmployeeRepository(LisovaContext lisovaContext)
    {
        _lisovaContext = lisovaContext;
    }
    
    public IList<Employee> GetEmployees()
    {
        throw new NotImplementedException();
    }

    public IList<Employee> GetEmployeesRange(int skip, int count)
    {
        throw new NotImplementedException();
    }

    public Employee GetEmployee(long employeeNo)
    {
        throw new NotImplementedException();
    }
}