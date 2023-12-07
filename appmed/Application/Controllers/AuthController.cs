using appmed.Domain.Entities;
using appmed.Infrastructure.Repository;
using appmed.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace appmed.Application.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController: ControllerBase
{
    
    private readonly EmployeeRepository _employeeRepository;

    public AuthController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<object>> CreateToken([FromBody] Employee employee)
    {
        var authEmployee = await _employeeRepository.ShowEmployee(employee.Name, employee.Password);
        if (authEmployee != null)
        {
            var tokenResult = TokenService.GenerateToken(authEmployee);
            return Ok(tokenResult);
        }

        return BadRequest("Employee not found in the database");
    }



    
}