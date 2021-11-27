using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelRequestManagementAPI.Models
{
    public partial class TravelRequestManagementDBContext : DbContext
    {
        public TravelRequestManagementDBContext()
        {
        }

        public TravelRequestManagementDBContext(DbContextOptions<TravelRequestManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmployeeRegistration> TblEmployeeRegistration { get; set; }
        public virtual DbSet<TblProject> TblProject { get; set; }
        public virtual DbSet<TblRequestTable> TblRequestTable { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer();
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmployeeRegistration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__TblEmplo__AF2DBB99D10FE494");

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblEmployeeRegistration)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__TblEmploy__UserI__2D27B809");
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__TblProje__761ABEF006B0C04F");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRequestTable>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__TblReque__33A8517A27B20FE6");

                entity.Property(e => e.CauseTravel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Mode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Priority)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TblRequestTable)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__TblReques__EmpId__37A5467C");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblRequestTable)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__TblReques__Proje__36B12243");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__TblRole__8AFACE1ABD761038");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TblUser__1788CC4C3029A841");

                entity.Property(e => e.RoleId).HasDefaultValueSql("((3))");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__TblUser__RoleId__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
