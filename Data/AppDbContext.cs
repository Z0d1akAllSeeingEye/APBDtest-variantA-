using Microsoft.EntityFrameworkCore;
using WebApplication3.DoctorAppointmentsAPI.Models;

namespace WebApplication3.DoctorAppointmentsAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<AppointmentService> AppointmentServices => Set<AppointmentService>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentService>()
            .HasKey(asv => new { asv.AppointmentId, asv.ServiceId });
    }
}