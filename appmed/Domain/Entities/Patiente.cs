using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace appmed.Domain.Entities;

public class Patiente
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }
    
    // https://learn.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/introduction/adding-validation
    [Required]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "The CPF must have 11 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "The CPF must only contain numbers.")]
    public string Cpf { get; set; }
    
    public List<Consultation> Consultations = new List<Consultation>();
}