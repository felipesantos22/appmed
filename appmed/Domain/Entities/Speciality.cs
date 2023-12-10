using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace appmed.Domain.Entities;

public class Speciality
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<DoctorSpeciality> DoctorSpecialities { get; set; } = new List<DoctorSpeciality>();
    
}