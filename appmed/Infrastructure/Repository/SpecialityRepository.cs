using appmed.Domain.Entities;
using appmed.Domain.Interfaces;
using appmed.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace appmed.Infrastructure.Repository;

public class SpecialityRepository: ISpeciality
{
    private readonly DataContext _dataContext;

    public SpecialityRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<Speciality> Create(Speciality speciality)
    {
        await _dataContext.Specialities.AddAsync(speciality);
        await _dataContext.SaveChangesAsync();
        return speciality;
    }

    public async Task<List<Speciality>> Index()
    {
        var speciality = await _dataContext.Specialities.Include(e => e.DoctorSpecialities).ToListAsync();
        return speciality;
    }

    public async Task<Speciality> Show(int id)
    {
        var speciality = await _dataContext.Specialities.FirstOrDefaultAsync(p => p.Id == id);
        return speciality;
    }

    public async Task<Speciality> Update(int id, Speciality speciality)
    {
        var specialityUpdate = await _dataContext.Specialities.FirstOrDefaultAsync(c => c.Id == id);
        specialityUpdate!.Name = speciality.Name;
        await _dataContext.SaveChangesAsync();
        return speciality;
    }

    public async Task<Speciality> Destroy(int id)
    {
        var deleteSpeciality = await _dataContext.Specialities.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Specialities.Remove(deleteSpeciality);
        await _dataContext.SaveChangesAsync();
        return deleteSpeciality;
    }
}