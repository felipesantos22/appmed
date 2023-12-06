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
            // conectar ao pgsql com a string de conexão das configurações do aplicativo
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
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
                .HasMany(e => e.Consultations)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId)
                .IsRequired();

            modelBuilder.Entity<Patiente>()
                .HasMany(e => e.Consultations)
                .WithOne(e => e.Patiente)
                .HasForeignKey(e => e.PatienteId)
                .IsRequired();

            // Configurar o relacionamento muitos-para-muitos entre Doctor e Speciality
            modelBuilder.Entity<DoctorSpeciality>()
                .HasKey(ds => new { ds.DoctorId, ds.SpecialityId });

            modelBuilder.Entity<DoctorSpeciality>()
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpecialities)
                .HasForeignKey(ds => ds.DoctorId);

            modelBuilder.Entity<DoctorSpeciality>()
                .HasOne(ds => ds.Speciality)
                .WithMany(s => s.DoctorSpecialities)
                .HasForeignKey(ds => ds.SpecialityId);
        }
    }
}
