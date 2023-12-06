using appmed.Domain.Entities;
using appmed.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace appmed.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly PatienteRepository _patienteRepository;

    public PatientController(PatienteRepository patienteRepository)
    {
        _patienteRepository = patienteRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<Patiente>> Create([FromBody] Patiente patiente)
    {
        Patiente newPatiente = await _patienteRepository.Create(patiente);
        return Ok(newPatiente);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Patiente>>> listarClientes()
    {
        var patientes = await _patienteRepository.Index();
        return Ok(patientes);
    }
}