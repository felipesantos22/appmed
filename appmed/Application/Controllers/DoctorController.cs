using appmed.Domain.Entities;
using appmed.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace appmed.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController: ControllerBase
{
    private readonly DoctorRepository _doctorRepository;

    public DoctorController(DoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Doctor>> Create([FromBody] Doctor doctor)
    {
        var newDoctor = await _doctorRepository.Create(doctor);
        return Ok(newDoctor);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<Doctor>>> Index()
    {
        var doctors = await _doctorRepository.Index();
        return Ok(doctors);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> Show(int id)
    {
        var doctor = await _doctorRepository.Show(id);
        if (doctor == null)
        {
            return NotFound(new { message = "Doctor not found" });
        }
        return Ok(doctor);
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Doctor>> Update(int id, [FromBody] Doctor doctor)
    {
        var updateDoctor = await _doctorRepository.Show(id);
        if (updateDoctor == null)
        {
            return NotFound(new { message = "Doctor not found" });
        }
        var doctorUpdate = await _doctorRepository.Update(id, doctor);
        return Ok(doctorUpdate);
    }
    
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Employee>> Destroy(int id)
    {
        var doctorId = await _doctorRepository.Show(id);
        if (doctorId== null)
        {
            return NotFound(new { message = "Doctor not found" });
        }
        var deleteDoctor = await _doctorRepository.Destroy(id);
        return Ok(new {message = "Doctor not found"});
    }
}