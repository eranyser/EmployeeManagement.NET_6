using Employees.models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("")]
        [Route("all")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeRepository.GetAllEmployees());
        }


        [HttpGet]
        [Route("{id:int}", Name = "GetSpecificEmployee")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee? employee = _employeeRepository.GetEmployeeById(id);
            if (employee != null)
                return Ok(employee);
            else
                return BadRequest($"No Employee with  Id: {id}");
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee newEmployee) 
        {
            Employee addedEmployee = _employeeRepository.AddEmployee(newEmployee);
            return CreatedAtRoute("GetSpecificEmployee", new { Id = addedEmployee.Id }, addedEmployee);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmpoyee(int id, [FromBody] Employee updatedEmployee)
        {
            Employee? employee = _employeeRepository.UpdateEmploeye(id, updatedEmployee);
            if (employee != null)
                return Ok(employee);
            else
                return BadRequest($"No Employee with Id: {id}");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (_employeeRepository.DeleteEmployee(id))
            {
                return NoContent();
            }
            else
            {
                return BadRequest($"No Employee with Id: {id}");
            }
        }
    }
}
