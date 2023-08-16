using Lisova.Services.Repositories;
using Lisova.WebAPI.Mappers;
using Lisova.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lisova.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeMapper _employeeMapper;
        
        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeMapper employeeMapper)
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = employeeMapper;
        }
        
        // GET: api/Employee/
        [HttpGet(Name = "GetFullAll")]
        public IEnumerable<FullEmployee> GetAllFull()
        {
            var employees = _employeeRepository.GetAll();
            var fullEmployees = employees.Select(e => _employeeMapper.MapToFullEmployee(e));

            return fullEmployees;
        }
        
        // GET: api/Employee/5/10
        [HttpGet("{skip:int}/{count:int}", Name = "GetFullRange")]
        public IEnumerable<FullEmployee> GetFullRange(int skip, int count)
        {
            var employees = _employeeRepository.GetRange(skip, count);
            var fullEmployeesRange = employees.Select(e => _employeeMapper.MapToFullEmployee(e));

            return fullEmployeesRange;
        }


        // GET: api/Employee/5
        [HttpGet("{employeeNo:long}", Name = "GetFullBy")]
        public FullEmployee GetFullBy(int employeeNo)
        {
            var employee = _employeeRepository.GetBy(employeeNo);
            var fullEmployee = _employeeMapper.MapToFullEmployee(employee);

            return fullEmployee;
        }
        
        // GET: api/Employee/
        [HttpGet(Name = "GetAbbreviatedAll")]
        public IEnumerable<AbbreviatedEmployee> GetAbbreviatedFull()
        {
            var employees = _employeeRepository.GetAll();
            var abbreviatedEmployees = employees.Select(e => _employeeMapper.MapToAbbreviatedEmployee(e));
        
            return abbreviatedEmployees;
        }
        
        // GET: api/Employee/5/10
        [HttpGet("{skip:int}/{count:int}", Name = "GetAbbreviatedRange")]
        public IEnumerable<AbbreviatedEmployee> GetAbbreviatedRange(int skip, int count)
        {
            var employees = _employeeRepository.GetRange(skip, count);
            var abbreviatedEmployeeRange = employees.Select(e => _employeeMapper.MapToAbbreviatedEmployee(e));
        
            return abbreviatedEmployeeRange;
        }
        
        
        // GET: api/Employee/5
        [HttpGet("{employeeNo:long}", Name = "GetAbbreviatedBy")]
        public AbbreviatedEmployee GetAbbreviatedBy(int employeeNo)
        {
            var employee = _employeeRepository.GetBy(employeeNo);
            var abbreviatedEmployee = _employeeMapper.MapToAbbreviatedEmployee(employee);
        
            return abbreviatedEmployee;
        }
    }
}
