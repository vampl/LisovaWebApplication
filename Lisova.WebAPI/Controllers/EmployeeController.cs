using Lisova.Services.Repositories;
using Lisova.WebAPI.Mappers;
using Lisova.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lisova.WebAPI.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet(Name = "GetAllFull")]
        public IList<FullEmployee> GetAllFull()
        {
            return new List<FullEmployee>();
        }
        
        // GET: api/Employee/5/10
        [HttpGet("{skip:int}/{count:int}", Name = "GetFullRange")]
        public IList<FullEmployee> GetFullRange(int skip, int count)
        {
            return new List<FullEmployee>();
        }


        // GET: api/Employee/5
        [HttpGet("{employeeNo:long}", Name = "GetByFull")]
        public FullEmployee GetBy(int employeeNo)
        {
            return new FullEmployee();
        }
    }
}
