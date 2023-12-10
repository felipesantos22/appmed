using appmed.Domain.Entities;

namespace appmed.Domain.Interfaces;

public interface IDoctorSpeciality
{
    public Task<DoctorSpeciality> Create(DoctorSpeciality doctorSpeciality);
    public Task<List<DoctorSpeciality>> Index();
    public Task<DoctorSpeciality> Show(int id);
    public Task<DoctorSpeciality> Update(int id, DoctorSpeciality doctorSpeciality);
    public Task<DoctorSpeciality> Destroy(int id);
}