namespace appmed.Domain.Entities;

public class DoctorSpeciality
{
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public int SpecialityId { get; set; }
    public Speciality Speciality { get; set; } = null!;
}