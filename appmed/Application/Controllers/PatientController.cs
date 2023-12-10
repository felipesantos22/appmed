using appmed.Domain.Entities;
using appmed.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<ActionResult<Patiente>> Create([FromBody] Patiente patient)
    {
        var newPatient = await _patienteRepository.Create(patient);
        return Ok(newPatient);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Patiente>>> Index()
    {
        var patients = await _patienteRepository.Index();
        return Ok(patients);
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Patiente>> Show(int id)
    {
        var patient = await _patienteRepository.Show(id);
        if (patient == null)
        {
            return NotFound(new { message = "Patient not found" });
        }
        return Ok(patient);
    }
    
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Patiente>> Update(int id, [FromBody] Patiente patient)
    {
        var updatePatient = await _patienteRepository.Show(id);
        if (updatePatient == null)
        {
            return NotFound(new { message = "Patient not found" });
        }
        var patientUpdate = await _patienteRepository.Update(id, patient);
        return Ok(patientUpdate);
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Patiente>> Destroy(int id)
    {
        var patientId = await _patienteRepository.Show(id);
        if (patientId == null)
        {
            return NotFound(new { message = "Patient not found" });
        }
        var deletePatient = await _patienteRepository.Destroy(id);
        return Ok(new {message = "Patient deleted"});
    }
}