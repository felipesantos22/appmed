using System.ComponentModel.DataAnnotations;

namespace appmed.Domain.Entities;

public class Patiente
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Consultation> Consultations = new List<Consultation>();
}