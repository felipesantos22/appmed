using appmed.Domain.Entities;

namespace appmed.Domain.Interfaces;

public interface IPatiente
{   
    public Task<Patiente> Create(Patiente patiente);
    public Task<List<Patiente>> Index();
    public Task<Patiente> Show(int id);
    public Task<Patiente> Update(int id, Patiente patiente);
    public Task<Patiente> Destroy(int id);
}