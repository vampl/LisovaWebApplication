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
        [HttpGet]
        public IList<FullEmployee> Get()
        {
            return new List<FullEmployee>();
        }
        
        // GET: api/Employee/5/10
        [HttpGet("{skip:int}/{count:int}", Name = "Get")]
        public IList<FullEmployee> Get(int skip, int count)
        {
            return new List<FullEmployee>();
        }


        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public FullEmployee Get(int id)
        {
            return new FullEmployee();
        }
    }
}
