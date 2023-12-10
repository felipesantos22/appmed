using appmed.Domain.Entities;
using appmed.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace appmed.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorSpeciliatyController: ControllerBase
{
    private readonly DoctorSpecialityRepository _doctorSpecialityRepository;

    public DoctorSpeciliatyController(DoctorSpecialityRepository doctorSpecialityRepository)
    {
        _doctorSpecialityRepository = doctorSpecialityRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<DoctorSpeciality>> Create([FromBody] DoctorSpeciality doctorSpeciality)
    {
        var newDoctorSpeciality = await _doctorSpecialityRepository.Create(doctorSpeciality);
        return Ok(newDoctorSpeciality);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<DoctorSpeciality>>> Index()
    {
        var doctorSpeciality = await _doctorSpecialityRepository.Index();
        return Ok(doctorSpeciality);
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorSpeciality>> Show(int id)
    {
        var doctorSpeciality = await _doctorSpecialityRepository.Show(id);
        if (doctorSpeciality == null)
        {
            return NotFound(new { message = "DoctorSpeciality not found" });
        }
        return Ok(doctorSpeciality);
    }
    
    
    [HttpPut("{id}")]
    public async Task<ActionResult<DoctorSpeciality>> Update(int id, [FromBody] DoctorSpeciality doctorSpeciality)
    {
        var findDoctorSpeciality = await _doctorSpecialityRepository.Show(id);
        if (findDoctorSpeciality == null)
        {
            return NotFound(new { message = "DoctorSpeciality not found" });
        }
        var doctorSpecialityUpdate = await _doctorSpecialityRepository.Update(id, doctorSpeciality);
        return Ok(doctorSpecialityUpdate);
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DoctorSpeciality>> Destroy(int id)
    {
        var doctorSpecialityId = await _doctorSpecialityRepository.Show(id);
        if (doctorSpecialityId == null)
        {
            return NotFound(new { message = "DoctorSpeciality not found" });
        }
        await _doctorSpecialityRepository.Destroy(id);
        return Ok(new {message = "DoctorSpeciality deleted"});
    }
}