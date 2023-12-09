using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace appmed.Domain.Entities;

[Table("Doctors")]
public class Doctor
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string CRM { get; set; }
    
    
    public List<Consultation> Consultations { get; set; } = new List<Consultation>();
    
    
    public List<DoctorSpeciality> DoctorSpecialities { get; set; } = new List<DoctorSpeciality>();

}