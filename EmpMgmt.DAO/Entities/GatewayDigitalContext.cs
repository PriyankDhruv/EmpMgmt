using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EmpMgmt.DAO.Entites
{
    public partial class GatewayDigitalContext : DbContext
    {
        public GatewayDigitalContext(): base()
        {
        }

        public GatewayDigitalContext(DbContextOptions<GatewayDigitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employeemaster> Employeemaster { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "Server=DSK-779\\SQL2019;Database=Gateway-Digital;UID=sa;PWD=Password12$;";
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employeemaster>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Doj)
                    .HasColumnName("DOJ")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.MailId)
                    .HasColumnName("MailID")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });
        }
    }
}