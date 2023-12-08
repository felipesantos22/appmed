using appmed.Domain.Entities;
using appmed.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace appmed.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecialityController: ControllerBase
{
    private readonly SpecialityRepository _specialityRepository;

    public SpecialityController(SpecialityRepository specialityRepository)
    {
        _specialityRepository = specialityRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<Speciality>> Create([FromBody] Speciality speciality)
    {
        var newSpeciality = await _specialityRepository.Create(speciality);
        return Ok(newSpeciality);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Speciality>>> Index()
    {
        var specialitys = await _specialityRepository.Index();
        return Ok(specialitys);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Speciality>> Show(int id)
    {
        var speciality = await _specialityRepository.Show(id);
        if (speciality == null)
        {
            return NotFound(new { message = "Speciality not found" });
        }
        return Ok(speciality);
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Speciality>> Update(int id, [FromBody] Speciality speciality)
    {
        var updateSpeciliaty = await _specialityRepository.Show(id);
        if (updateSpeciliaty == null)
        {
            return NotFound(new { message = "Speciality not found" });
        }
        var specialityUpdate = await _specialityRepository.Update(id, speciality);
        return Ok(specialityUpdate);
    }
    
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Speciality>> Destroy(int id)
    {
        var specialityId = await _specialityRepository.Show(id);
        if (specialityId == null)
        {
            return NotFound(new { message = "Speciality not found" });
        }
        var deleteSpecilaity = await _specialityRepository.Destroy(id);
        return Ok(new {message = "Speciality deleted"});
    }
}