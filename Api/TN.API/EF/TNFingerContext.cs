using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TN.API.EF
{
    public partial class TNFingerContext : DbContext
    {
        public virtual DbSet<ClassOfSchool> ClassOfSchool { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCheckOut> StudentCheckOut { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public TNFingerContext(DbContextOptions<TNFingerContext> options)
        : base(options)
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Data Source=14.225.3.30;Initial Catalog=TN.Finger;Persist Security Info=True;User ID=sa;Password=trinam@123");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imei)
                    .HasColumnName("IMEI")
                    .HasMaxLength(200);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdRouteNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.IdRoute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_Route");

                entity.HasOne(d => d.IdVehicleNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.IdVehicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_Vehicle");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Finger1UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Finger2UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(30);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdClassOfSchoolNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdClassOfSchool)
                    .HasConstraintName("FK_Student_ClassOfSchool");

                entity.HasOne(d => d.IdRouterNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdRouter)
                    .HasConstraintName("FK_Student_Route");

                entity.HasOne(d => d.IdSchoolNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdSchool)
                    .HasConstraintName("FK_Student_Schools");
            });

            modelBuilder.Entity<StudentCheckOut>(entity =>
            {
                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdDeviceNavigation)
                    .WithMany(p => p.StudentCheckOut)
                    .HasForeignKey(d => d.IdDevice)
                    .HasConstraintName("FK_StudentCheckOut_Device");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentCheckOut)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCheckOut_Student");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DisplayName).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Brand).HasMaxLength(100);

                entity.Property(e => e.Lpn).HasMaxLength(10);
            });
        }
    }
}
