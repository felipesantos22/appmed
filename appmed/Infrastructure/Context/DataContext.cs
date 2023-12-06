using appmed.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace appmed.Infrastructure.Context;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to pgsql with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<Patiente> Patientes { get; set; }
}