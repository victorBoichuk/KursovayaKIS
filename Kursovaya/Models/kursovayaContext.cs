using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kursovaya
{
    public partial class kursovayaContext : DbContext
    {
        public kursovayaContext()
        {
        }

        public kursovayaContext(DbContextOptions<kursovayaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabinets> Cabinets { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Specialties> Specialties { get; set; }
        public virtual DbSet<Timetable> Timetable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-J6DUQ3VF\\SQLEXPRESS;Database=kursovaya;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabinets>(entity =>
            {
                entity.HasKey(e => e.CabinetNumber)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CabinetNumber)
                    .HasColumnName("cabinet_number")
                    .ValueGeneratedNever();

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.SeatsCount).HasColumnName("seats_count");
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("text");

                entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("R_6");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("text");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.InsuranceNumber)
                    .IsRequired()
                    .HasColumnName("insurance_number")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasColumnName("passport_number")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Specialties>(entity =>
            {
                entity.HasKey(e => e.SpecialtyId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SpecialtyId).HasColumnName("specialtyId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Timetable>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CabinetNumber).HasColumnName("cabinet_number");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CabinetNumberNavigation)
                    .WithMany(p => p.Timetable)
                    .HasForeignKey(d => d.CabinetNumber)
                    .HasConstraintName("R_8");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Timetable)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("R_10");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Timetable)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("R_9");
            });
        }
    }
}
