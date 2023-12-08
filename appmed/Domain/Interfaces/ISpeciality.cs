using appmed.Domain.Entities;

namespace appmed.Domain.Interfaces;

public interface ISpeciality
{
    public Task<Speciality> Create(Speciality speciality);
    public Task<List<Speciality>> Index();
    public Task<Speciality> Show(int id);
    public Task<Speciality> Update(int id, Speciality speciality);
    public Task<Speciality> Destroy(int id);
}