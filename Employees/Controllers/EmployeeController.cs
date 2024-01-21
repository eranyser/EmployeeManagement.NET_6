using Employees.models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
        
        IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public Employee GetEmployeeById(int id) 
        {
            return _employeeRepository.GetEmployeeById(id);
        }
    }
}
