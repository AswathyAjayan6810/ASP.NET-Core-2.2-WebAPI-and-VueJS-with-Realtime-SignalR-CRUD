using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepo;

        public EmployeesController(IEmployeeRepository employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await employeeRepo.Employees().ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await employeeRepo.EmployeeById(id).FirstOrDefaultAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!await employeeRepo.Create(employee))
                return BadRequest("Something went wrong");

            return Ok("Successfully saved");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            employee.EmployeeId = id;
            if (!await employeeRepo.Update(employee))
                return BadRequest("Something went wrong");

            return Ok("Successfully saved");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await employeeRepo.DeleteById(id))
                return BadRequest("Something went wrong");

            return Ok("Successfully saved");
        }
    }
}
