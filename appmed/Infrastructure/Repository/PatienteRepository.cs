using appmed.Domain.Entities;
using appmed.Domain.Interfaces;
using appmed.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace appmed.Infrastructure.Repository;

public class PatienteRepository : IPatiente
{
    private readonly DataContext _dataContext;

    public PatienteRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<Patiente> Create(Patiente patiente)
    {
        await _dataContext.Patientes.AddAsync(patiente);
        await _dataContext.SaveChangesAsync();
        return patiente;
    }

    public async Task<List<Patiente>> Index()
    {
        var patient = await _dataContext.Patientes.ToListAsync();
        return patient;
    }

    public async Task<Patiente> Show(int id)
    {
        var patient = await _dataContext.Patientes.FirstOrDefaultAsync(p => p.Id == id);
        return patient;
    }

    public async Task<Patiente> Update(int id, Patiente patiente)
    {
        var patienteUpdate = await _dataContext.Patientes.FirstOrDefaultAsync(c => c.Id == id);
        patienteUpdate!.Name = patiente.Name;
        patienteUpdate.Age = patiente.Age;
        patienteUpdate.Cpf = patiente.Cpf;
        await _dataContext.SaveChangesAsync();
        return patienteUpdate;
    }

    public async Task<Patiente> Destroy(int id)
    {
        var deletePatiente = await _dataContext.Patientes.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Patientes.Remove(deletePatiente);
        await _dataContext.SaveChangesAsync();
        return deletePatiente;
    }
}