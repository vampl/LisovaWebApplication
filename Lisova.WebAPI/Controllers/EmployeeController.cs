using Lisova.Services.Repositories;
using Lisova.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lisova.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
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
