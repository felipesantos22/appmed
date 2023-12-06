using System.ComponentModel.DataAnnotations;

namespace appmed.Domain.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}