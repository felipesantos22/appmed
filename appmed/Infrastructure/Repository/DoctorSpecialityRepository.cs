using appmed.Domain.Entities;
using appmed.Domain.Interfaces;
using appmed.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace appmed.Infrastructure.Repository;

public class DoctorSpecialityRepository: IDoctorSpeciality
{
    private readonly DataContext _dataContext;

    public DoctorSpecialityRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<DoctorSpeciality> Create(DoctorSpeciality doctorSpeciality)
    {
        await _dataContext.DoctorSpecialities.AddAsync(doctorSpeciality);
        await _dataContext.SaveChangesAsync();
        return doctorSpeciality;
    }

    public async Task<List<DoctorSpeciality>> Index()
    {
        var doctorSpeciality = await _dataContext.DoctorSpecialities.Include(c => c.DoctorId).Include(c => c.SpecialityId).ToListAsync();
        return doctorSpeciality;
    }

    public async Task<DoctorSpeciality> Show(int id)
    {
        var doctorSpeciality = await _dataContext.DoctorSpecialities.FirstOrDefaultAsync(p => p.Id == id);
        return doctorSpeciality;
    }

    public async Task<DoctorSpeciality> Update(int id, DoctorSpeciality doctorSpeciality)
    {
        var doctorSpecialityUpdate = await _dataContext.DoctorSpecialities.FirstOrDefaultAsync(c => c.Id == id);
        doctorSpecialityUpdate!.DoctorId = doctorSpeciality.DoctorId;
        doctorSpecialityUpdate.SpecialityId = doctorSpeciality.SpecialityId;
        await _dataContext.SaveChangesAsync();
        return doctorSpeciality;
    }

    public async Task<DoctorSpeciality> Destroy(int id)
    {
        var doctorSpeciality = await _dataContext.DoctorSpecialities.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.DoctorSpecialities.Remove(doctorSpeciality);
        await _dataContext.SaveChangesAsync();
        return doctorSpeciality;
    }
}