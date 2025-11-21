using Doctor_Appointment.Models;
using Microsoft.EntityFrameworkCore;

namespace Doctor_Appointment.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Slot> Slots {  get; set; }
    public DbSet<Appointment> Appointments {  get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasIndex(d => d.Email).IsUnique();    //Unique doctors -> already exists

        modelBuilder.Entity<Patient>()
            .HasIndex(p => p.Email).IsUnique();     //Unique Patient 

        //modelBuilder.Entity<Slot>()
        //    .HasOne(s => s.Doctor)
        //    .WithMany(d => d.Slots)
        //    .HasForeignKey(s => s.DoctorId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Appointment>()
        //    .HasOne(a => a.Slot)
        //    .WithOne(s => s.Appointments)
        //    .HasForeignKey<Appointment>(a => a.SlotId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Appointment>()
        //    .HasOne(a => a.Patient)
        //    .WithMany(p => p.Appointments)
        //    .HasForeignKey(a => a.PatientId)
        //    .OnDelete(DeleteBehavior.Cascade);
    }
}
