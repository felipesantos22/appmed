using System.Text.Json.Serialization;

namespace appmed.Domain.Entities;

public class DoctorSpeciality
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    [JsonIgnore]
    public Doctor Doctor { get; set; }
    
    public int SpecialityId { get; set; }
    [JsonIgnore]
    public Speciality Speciality { get; set; }
}