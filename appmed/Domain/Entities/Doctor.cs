using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace appmed.Domain.Entities;


public class Doctor
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    //https://learn.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/introduction/adding-validation
    [Required(ErrorMessage = "The CRM is required.")]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "The CRM must have exactly 6 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "The CRM must contain only numbers.")]
    public string CRM { get; set; }
    public List<Consultation> Consultations { get; set; } = new List<Consultation>();
    public List<DoctorSpeciality> DoctorSpecialities { get; set; } = new List<DoctorSpeciality>();

}