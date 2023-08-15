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
    
    public ICollection<Employee> GetEmployees()
    {
        throw new NotImplementedException();
    }

    public ICollection<Employee> GetEmployeesRange(int skip, int count)
    {
        throw new NotImplementedException();
    }

    public Employee GetEmployee(long employeeNo)
    {
        throw new NotImplementedException();
    }
}