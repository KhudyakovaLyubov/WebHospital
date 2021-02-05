using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebHospital.Models
{
    public partial class HospitalDbContext : DbContext
    {
        public HospitalDbContext()
            : base("name=HospitalDbContext")
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Reception> Reception { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Timetable> Timetable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Specialty)
                .WithRequired(e => e.Department1)
                .HasForeignKey(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Reception)
                .WithRequired(e => e.Employee1)
                .HasForeignKey(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Part>()
                .HasMany(e => e.Address)
                .WithRequired(e => e.Part1)
                .HasForeignKey(e => e.Part)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Reception)
                .WithRequired(e => e.Patient1)
                .HasForeignKey(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialty>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Specialty1)
                .HasForeignKey(e => e.Specialty)
                .WillCascadeOnDelete(false);
        }
    }
}
