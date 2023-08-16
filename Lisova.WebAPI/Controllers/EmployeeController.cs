using Lisova.Services.Repositories;
using Lisova.WebAPI.Mappers;
using Lisova.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lisova.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeMapper _employeeMapper;
        
    /// <summary>
    /// Creates an controller instance with injection of service, repository instances.
    /// </summary>
    /// <param name="employeeRepository">The instance of repository with data access.</param>
    /// <param name="employeeMapper">The instance of mapper to assign data for proper data format.</param>
    public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeMapper employeeMapper)
    {
        _employeeRepository = employeeRepository;
        _employeeMapper = employeeMapper;
    }
        
    // GET: api/Employee/GetFullAll
    /// <summary>
    /// Gets all employees data.
    /// </summary>
    /// <returns>Returns an list of employees in full format.</returns>
    [HttpGet(Name = "GetFullAll")]
    public IEnumerable<FullEmployee> GetAllFull()
    {
        var employees = _employeeRepository.GetAll();
        var fullEmployees = employees.Select(e => _employeeMapper.MapToFullEmployee(e));

        return fullEmployees;
    }
        
    // GET: api/Employee/GetFullRange/5/10
    /// <summary>
    /// Gets range of employees.
    /// </summary>
    /// <param name="skip">The quantity of employees to be skipped.</param>
    /// <param name="count">The quantity of employees to be retrieved.</param>
    /// <returns>Returns an list of employees in full format.</returns>
    [HttpGet("{skip:int}/{count:int}", Name = "GetFullRange")]
    public IEnumerable<FullEmployee> GetFullRange(int skip, int count)
    {
        var employees = _employeeRepository.GetRange(skip, count);
        var fullEmployeesRange = employees.Select(e => _employeeMapper.MapToFullEmployee(e));

        return fullEmployeesRange;
    }


    // GET: api/Employee/GetFullBy/5
    /// <summary>
    /// Gets an employee by identifier.
    /// </summary>
    /// <param name="employeeNo">The identifier of an employee record to get.</param>
    /// <returns>Returns an employees in full format.></returns>
    [HttpGet("{employeeNo:long}", Name = "GetFullBy")]
    public FullEmployee GetFullBy(int employeeNo)
    {
        var employee = _employeeRepository.GetBy(employeeNo);
        var fullEmployee = _employeeMapper.MapToFullEmployee(employee);

        return fullEmployee;
    }
        
    // GET: api/Employee/GetAbbreviatedAll
    /// <summary>
    /// Gets all employees data.
    /// </summary>
    /// <returns>Returns an list of employees in abbreviated format.</returns>
    [HttpGet(Name = "GetAbbreviatedAll")]
    public IEnumerable<AbbreviatedEmployee> GetAbbreviatedFull()
    {
        var employees = _employeeRepository.GetAll();
        var abbreviatedEmployees = employees.Select(e => _employeeMapper.MapToAbbreviatedEmployee(e));
        
        return abbreviatedEmployees;
    }
        
    // GET: api/Employee/GetAbbreviatedRange/5/10
    /// <summary>
    /// Gets range of employees.
    /// </summary>
    /// <param name="skip">The quantity of employees to be skipped.</param>
    /// <param name="count">The quantity of employees to be retrieved.</param>
    /// <returns>Returns an list of employees in abbreviated format.</returns>
    [HttpGet("{skip:int}/{count:int}", Name = "GetAbbreviatedRange")]
    public IEnumerable<AbbreviatedEmployee> GetAbbreviatedRange(int skip, int count)
    {
        var employees = _employeeRepository.GetRange(skip, count);
        var abbreviatedEmployeeRange = employees.Select(e => _employeeMapper.MapToAbbreviatedEmployee(e));
        
        return abbreviatedEmployeeRange;
    }
        
        
    // GET: api/Employee/GetAbbreviatedBy/5
    /// <summary>
    /// Gets an employee by identifier.
    /// </summary>
    /// <param name="employeeNo">The identifier of an employee record to get.</param>
    /// <returns>Returns an employees in full format.></returns>
    [HttpGet("{employeeNo:long}", Name = "GetAbbreviatedBy")]
    public AbbreviatedEmployee GetAbbreviatedBy(int employeeNo)
    {
        var employee = _employeeRepository.GetBy(employeeNo);
        var abbreviatedEmployee = _employeeMapper.MapToAbbreviatedEmployee(employee);
        
        return abbreviatedEmployee;
    }
}