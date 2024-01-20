using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dotnet.Data
{
    public partial class DotnetContext : DbContext
    {
        public DotnetContext()
        {
        }

        public DotnetContext(DbContextOptions<DotnetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DesignationMaster> DesignationMasters { get; set; } = null!;
        public virtual DbSet<LocationMaster> LocationMasters { get; set; } = null!;
        public virtual DbSet<ShiftMaster> ShiftMasters { get; set; } = null!;
        public virtual DbSet<UserMaster> UserMasters { get; set; } = null!;
        public virtual DbSet<WageMaster> WageMasters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("user=root;password=1234;server=localhost;port=3306;database=dotnet_webapi;treattinyasboolean=false", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<DesignationMaster>(entity =>
            {
                entity.HasKey(e => e.DesignationId)
                    .HasName("PRIMARY");

                entity.ToTable("designation_master");

                entity.Property(e => e.DesignationId).HasColumnName("designation_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DesignationCd)
                    .HasMaxLength(5)
                    .HasColumnName("designation_cd");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(45)
                    .HasColumnName("designation_name");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<LocationMaster>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PRIMARY");

                entity.ToTable("location_master");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LocationCd)
                    .HasMaxLength(5)
                    .HasColumnName("location_cd");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(45)
                    .HasColumnName("location_name");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<ShiftMaster>(entity =>
            {
                entity.HasKey(e => e.ShiftId)
                    .HasName("PRIMARY");

                entity.ToTable("shift_master");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.ShiftCd)
                    .HasMaxLength(5)
                    .HasColumnName("shift_cd");

                entity.Property(e => e.ShiftName)
                    .HasMaxLength(45)
                    .HasColumnName("shift_name");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("user_master");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(45)
                    .HasColumnName("employee_id");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(45)
                    .HasColumnName("employee_name");

                entity.Property(e => e.FailedAttemptDttm)
                    .HasColumnType("datetime")
                    .HasColumnName("failed_attempt_dttm");

                entity.Property(e => e.FailedAttempts).HasColumnName("failed_attempts");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastLoginDttm)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_dttm");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .HasColumnName("mobile");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.PasswordChangeDttm)
                    .HasColumnType("datetime")
                    .HasColumnName("password_change_dttm");

                entity.Property(e => e.Suspended)
                    .IsRequired()
                    .HasColumnName("suspended")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.UserName)
                    .HasMaxLength(45)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(1)
                    .HasColumnName("user_role")
                    .HasDefaultValueSql("'E'");

                entity.Property(e => e.UserStatus)
                    .IsRequired()
                    .HasColumnName("user_status")
                    .HasDefaultValueSql("b'1'");
            });

            modelBuilder.Entity<WageMaster>(entity =>
            {
                entity.HasKey(e => e.WageId)
                    .HasName("PRIMARY");

                entity.ToTable("wage_master");

                entity.Property(e => e.WageId).HasColumnName("wage_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.WageCd)
                    .HasMaxLength(5)
                    .HasColumnName("wage_cd");

                entity.Property(e => e.WageName)
                    .HasMaxLength(45)
                    .HasColumnName("wage_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
