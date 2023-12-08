using appmed.Domain.Entities;
using appmed.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace appmed.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController: ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Employee>> Create([FromBody] Employee employee)
    {
        var newPatient = await _employeeRepository.Create(employee);
        return Ok(newPatient);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> Index()
    {
        var employees = await _employeeRepository.Index();
        return Ok(employees);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> Show(int id)
    {
        var employee = await _employeeRepository.Show(id);
        if (employee == null)
        {
            return NotFound(new { message = "Employee not found" });
        }
        return Ok(employee);
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Employee>> Update(int id, [FromBody] Employee employee)
    {
        var updateEmployee = await _employeeRepository.Show(id);
        if (updateEmployee == null)
        {
            return NotFound(new { message = "Employee not found" });
        }
        var employeeUpdate = await _employeeRepository.Update(id, employee);
        return Ok(employee);
    }
    
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Employee>> Destroy(int id)
    {
        var employeeId = await _employeeRepository.Show(id);
        if (employeeId == null)
        {
            return NotFound(new { message = "Employee not found" });
        }
        var deleteEmployee = await _employeeRepository.Destroy(id);
        return Ok(new {message = "Employee not found"});
    }
}