using appmed.Domain.Entities;
using appmed.Domain.Interfaces;
using appmed.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace appmed.Infrastructure.Repository;

public class DoctorRepository : IDoctor
{
    private readonly DataContext _dataContext;

    public DoctorRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<Doctor> Create(Doctor doctor)
    {
        await _dataContext.Doctors.AddAsync(doctor);
        await _dataContext.SaveChangesAsync();
        return doctor;
    }

    public async Task<List<Doctor>> Index()
    {
        var doctor = await _dataContext.Doctors.ToListAsync();
        return doctor;
    }

    public async Task<Doctor?> Show(int id)
    {
        var doctor = await _dataContext.Doctors.FirstOrDefaultAsync(c => c.Id == id);
        return doctor;
    }

    public async Task<Doctor> Update(int id, Doctor doctor)
    {
        var doctorUpdate = await _dataContext.Doctors.FirstOrDefaultAsync(c => c.Id == id);
        doctorUpdate!.Name = doctor.Name;
        doctorUpdate.CRM = doctor.CRM;
        doctorUpdate.Consultations = doctor.Consultations;
        await _dataContext.SaveChangesAsync();
        return doctorUpdate;
    }

    public async Task<Doctor> Destroy(int id)
    {
        var deleteDoctor= await _dataContext.Doctors.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Doctors.Remove(deleteDoctor);
        await _dataContext.SaveChangesAsync();
        return deleteDoctor;
    }
    
}