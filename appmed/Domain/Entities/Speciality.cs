using System.ComponentModel.DataAnnotations;

namespace appmed.Domain.Entities;

public class Speciality
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    public List<DoctorSpeciality> DoctorSpecialities { get; set; } = new List<DoctorSpeciality>();
}