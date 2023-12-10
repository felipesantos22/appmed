using appmed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace appmed.Infrastructure.Context
{
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
            // options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
            
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Patiente> Patientes { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        
        public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasIndex(d => d.CRM)
                .IsUnique();
            modelBuilder.Entity<Patiente>()
                .HasIndex(d => d.Cpf)
                .IsUnique();
            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Consultations)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId)
                .IsRequired();

            modelBuilder.Entity<Patiente>()
                .HasMany(e => e.Consultations)
                .WithOne(e => e.Patiente)
                .HasForeignKey(e => e.PatienteId)
                .IsRequired();

            modelBuilder.Entity<DoctorSpeciality>()
                .HasKey(ds => new { ds.DoctorId, ds.SpecialityId });

            modelBuilder.Entity<Doctor>()
                .HasMany(doctor => doctor.DoctorSpecialities)  
                .WithOne(ds => ds.Doctor)
                .HasForeignKey(ds => ds.DoctorId);

            modelBuilder.Entity<Speciality>()
                .HasMany(speciality => speciality.DoctorSpecialities)
                .WithOne(ds => ds.Speciality)
                .HasForeignKey(ds => ds.SpecialityId);
           }
    }
}
