using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Cw8.Models
{
    public class MainDbContext : DbContext
    {

        //Komendy 
        //Add-Migration nazwa - commit
        //Update-Database - push
 
        protected MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

     

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

     


        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
              optionsBuilder.UseSqlServer("");
          }*/

        //zamiast OnModelCreating mozna dodawac adnotacje to zmiennych w klasach Doctor, Patient... 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });
            
            });
       

            SeedData(modelBuilder);
       

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription_Medicament>()
               .HasData(
                   new Prescription_Medicament
                   {
                       IdPrescription = 1,
                       IdMedicament = 1,
                       Details = "Don't overdose",
                       Dose = 4,
                   }
               );
            modelBuilder.Entity<Prescription>()
             .HasData(
                 new Prescription
                 {
                     IdPrescription = 1,
                     IdDoctor = 1,
                     IdPatient = 2,
                     Date = DateTime.Now,
                     DueDate = DateTime.Now.AddDays(1)
                 }
             );
            modelBuilder.Entity<Medicament>()
               .HasData(
                   new Medicament
                   {
                       IdMedicament = 1,
                       Name = "Medicament 1",
                       Description = "head ache",
                       Type = "Type 1"
                   },
                   new Medicament
                   {
                       IdMedicament = 2,
                       Name = "Medicament 2",
                       Description = "stomach ache",
                       Type = "Type 2"
                   });

            modelBuilder.Entity<Patient>()
               .HasData(
                   new Patient
                   {
                       IdPatient = 1,
                       FirstName = "Paweł",
                       LastName = "Nowak",
                      BirthDate = Convert.ToDateTime("1973-02-13T00:00:00")
                   },
                   new Patient
                   {
                       IdPatient = 2,
                       FirstName = "Marek",
                       LastName = "Markowski",
                       BirthDate = Convert.ToDateTime("1973-02-13T00:00:00")
                   });

            modelBuilder.Entity<Doctor>()
               .HasData(
                   new Doctor
                   {
                       IdDoctor = 1,
                       FirstName = "Jan",
                       LastName = "Kowalski",
                       Email = "jan@o2.pl"
                   },
                   new Doctor
                   {
                       IdDoctor = 2,
                       FirstName = "Jakub",
                       LastName = "Nowak",
                       Email = "nowak@o2.pl"
                   });

        }

    }
}
