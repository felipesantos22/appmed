using System.ComponentModel.DataAnnotations;

namespace appmed.Domain.Entities;

public class Consultation
{
    [Key]
    public int Id { get; set; }
    public DateTime DateTime{get; set; }
    
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    
    public int PatienteId { get; set; }
    public Patiente Patiente { get; set; }
}