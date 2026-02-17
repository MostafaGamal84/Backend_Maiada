using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class OrbitsContext : DbContext
    {
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<AppUserType> AppUserTypes { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<AttendStatue> AttendStatues { get; set; } = null!;
        public virtual DbSet<Circle> Circles { get; set; } = null!;
        public virtual DbSet<CircleManager> CircleManagers { get; set; } = null!;
        public virtual DbSet<CircleStudent> CircleStudents { get; set; } = null!;
        public virtual DbSet<CircleTime> CircleTimes { get; set; } = null!;
        public virtual DbSet<Family> Families { get; set; } = null!;
        public virtual DbSet<Governorate> Governorates { get; set; } = null!;
        public virtual DbSet<HoursRecord> HoursRecords { get; set; } = null!;
        public virtual DbSet<How> Hows { get; set; } = null!;
        public virtual DbSet<IncomingAndOutgoing> IncomingAndOutgoings { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<ManagerStudent> ManagerStudents { get; set; } = null!;
        public virtual DbSet<ManagerTeacher> ManagerTeachers { get; set; } = null!;
        public virtual DbSet<ManagerTime> ManagerTimes { get; set; } = null!;
        public virtual DbSet<Month> Months { get; set; } = null!;
        public virtual DbSet<Nationality> Nationalities { get; set; } = null!;
        public virtual DbSet<PayScreenShot> PayScreenShots { get; set; } = null!;
        public virtual DbSet<PayStatue> PayStatues { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Quran> Qurans { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentReport> StudentReports { get; set; } = null!;
        public virtual DbSet<StudentTime> StudentTimes { get; set; } = null!;
        public virtual DbSet<Subscribe> Subscribes { get; set; } = null!;
        public virtual DbSet<SubscribeType> SubscribeTypes { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TeacherCircle> TeacherCircles { get; set; } = null!;
        public virtual DbSet<TeacherHour> TeacherHours { get; set; } = null!;
        public virtual DbSet<TeacherStudent> TeacherStudents { get; set; } = null!;
        public virtual DbSet<TeacherTime> TeacherTimes { get; set; } = null!;
        public virtual DbSet<Time> Times { get; set; } = null!;
        public virtual DbSet<UserPermission> UserPermissions { get; set; } = null!;

 public OrbitsContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=N1NWPLSK12SQL-v02.shr.prod.ams1.secureserver.net;initial catalog=agialDB;Integrated security=False;User ID=ph20706648051;Password=Mostafa5020#;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ph20706648051");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AppUserType>(entity =>
            {
                entity.ToTable("AppUserTypes", "dbo");

                entity.Property(e => e.NameAr).HasColumnName("Name_ar");

                entity.Property(e => e.NameEn).HasColumnName("Name_en");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.ToTable("AspNetRoles", "dbo");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.ToTable("AspNetRoleClaims", "dbo");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.ToTable("AspNetUsers", "dbo");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.AppUserType)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.AppUserTypeId);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles", "dbo");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.ToTable("AspNetUserClaims", "dbo");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("AspNetUserLogins", "dbo");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("AspNetUserTokens", "dbo");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AttendStatue>(entity =>
            {
                entity.ToTable("AttendStatues", "dbo");
            });

            modelBuilder.Entity<Circle>(entity =>
            {
                entity.ToTable("Circles", "dbo");
            });

            modelBuilder.Entity<CircleManager>(entity =>
            {
                entity.ToTable("CircleManagers", "dbo");

                entity.HasOne(d => d.Circle)
                    .WithMany(p => p.CircleManagers)
                    .HasForeignKey(d => d.CircleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.CircleManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CircleStudent>(entity =>
            {
                entity.ToTable("CircleStudents", "dbo");

                entity.HasOne(d => d.Circle)
                    .WithMany(p => p.CircleStudents)
                    .HasForeignKey(d => d.CircleId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CircleStudents)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<CircleTime>(entity =>
            {
                entity.ToTable("CircleTime", "dbo");

                entity.HasOne(d => d.Circle)
                    .WithMany(p => p.CircleTimes)
                    .HasForeignKey(d => d.CircleId);

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.CircleTimes)
                    .HasForeignKey(d => d.TimeId);
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("Families", "dbo");
            });

            modelBuilder.Entity<Governorate>(entity =>
            {
                entity.ToTable("Governorates", "dbo");

                entity.Property(e => e.NameAr).HasColumnName("Name_ar");

                entity.Property(e => e.NameEn).HasColumnName("Name_en");
            });

            modelBuilder.Entity<HoursRecord>(entity =>
            {
                entity.ToTable("HoursRecords", "dbo");

                entity.Property(e => e.PriceLe).HasColumnName("PriceLE");

                entity.HasOne(d => d.SubscribeType)
                    .WithMany(p => p.HoursRecords)
                    .HasForeignKey(d => d.SubscribeTypeId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.HoursRecords)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<How>(entity =>
            {
                entity.ToTable("hows", "dbo");

                entity.HasIndex(e => new { e.NameAr, e.NameEn }, "uniqeRows")
                    .IsUnique();

                entity.Property(e => e.NameAr).HasColumnName("Name_ar");

                entity.Property(e => e.NameEn).HasColumnName("Name_en");
            });

            modelBuilder.Entity<IncomingAndOutgoing>(entity =>
            {
                entity.ToTable("IncomingAndOutgoings", "dbo");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.GovernorateId);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Manager)
                    .HasForeignKey<Manager>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ManagerStudent>(entity =>
            {
                entity.ToTable("ManagerStudents", "dbo");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ManagerStudents)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ManagerStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ManagerTeacher>(entity =>
            {
                entity.ToTable("ManagerTeachers", "dbo");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ManagerTeachers)
                    .HasForeignKey(d => d.ManagerId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.ManagerTeachers)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<ManagerTime>(entity =>
            {
                entity.ToTable("ManagerTimes", "dbo");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ManagerTimes)
                    .HasForeignKey(d => d.ManagerId);

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.ManagerTimes)
                    .HasForeignKey(d => d.TimeId);
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.ToTable("Months", "dbo");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationalities", "dbo");
            });

            modelBuilder.Entity<PayScreenShot>(entity =>
            {
                entity.ToTable("PayScreenShots", "dbo");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.PayScreenShots)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<PayStatue>(entity =>
            {
                entity.ToTable("PayStatues", "dbo");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permissions", "dbo");
            });

            modelBuilder.Entity<Quran>(entity =>
            {
                entity.ToTable("Qurans", "dbo");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FamilyId);

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GovernorateId);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.NationalityId);

                entity.HasOne(d => d.PayStatue)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.PayStatueId);

                entity.HasOne(d => d.Subscribe)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SubscribeId);
            });

            modelBuilder.Entity<StudentReport>(entity =>
            {
                entity.ToTable("StudentReports", "dbo");

                entity.HasOne(d => d.AttendStatue)
                    .WithMany(p => p.StudentReports)
                    .HasForeignKey(d => d.AttendStatueId);

                entity.HasOne(d => d.Circle)
                    .WithMany(p => p.StudentReports)
                    .HasForeignKey(d => d.CircleId);

                entity.HasOne(d => d.DistantPast)
                    .WithMany(p => p.StudentReportDistantPasts)
                    .HasForeignKey(d => d.DistantPastId);

                entity.HasOne(d => d.FarthestPast)
                    .WithMany(p => p.StudentReportFarthestPasts)
                    .HasForeignKey(d => d.FarthestPastId);

                entity.HasOne(d => d.New)
                    .WithMany(p => p.StudentReportNews)
                    .HasForeignKey(d => d.NewId);

                entity.HasOne(d => d.RecentPast)
                    .WithMany(p => p.StudentReportRecentPasts)
                    .HasForeignKey(d => d.RecentPastId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentReports)
                    .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.StudentReports)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<StudentTime>(entity =>
            {
                entity.ToTable("StudentTimes", "dbo");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTimes)
                    .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.StudentTimes)
                    .HasForeignKey(d => d.TimeId);
            });

            modelBuilder.Entity<Subscribe>(entity =>
            {
                entity.ToTable("Subscribes", "dbo");

                entity.Property(e => e.PriceLe).HasColumnName("PriceLE");

                entity.HasOne(d => d.SubscribeType)
                    .WithMany(p => p.Subscribes)
                    .HasForeignKey(d => d.SubscribeTypeId);
            });

            modelBuilder.Entity<SubscribeType>(entity =>
            {
                entity.ToTable("SubscribeTypes", "dbo");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ForignTeacher)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Governorate)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.GovernorateId);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TeacherCircle>(entity =>
            {
                entity.ToTable("TeacherCircles", "dbo");

                entity.HasOne(d => d.Circle)
                    .WithMany(p => p.TeacherCircles)
                    .HasForeignKey(d => d.CircleId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherCircles)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<TeacherHour>(entity =>
            {
                entity.ToTable("TeacherHours", "dbo");

                entity.HasOne(d => d.AttendStatue)
                    .WithMany(p => p.TeacherHours)
                    .HasForeignKey(d => d.AttendStatueId);

                entity.HasOne(d => d.SubscribeType)
                    .WithMany(p => p.TeacherHours)
                    .HasForeignKey(d => d.SubscribeTypeId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherHours)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<TeacherStudent>(entity =>
            {
                entity.ToTable("TeacherStudents", "dbo");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TeacherStudents)
                    .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherStudents)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<TeacherTime>(entity =>
            {
                entity.ToTable("TeacherTimes", "dbo");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherTimes)
                    .HasForeignKey(d => d.TeacherId);

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.TeacherTimes)
                    .HasForeignKey(d => d.TimeId);
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.ToTable("Times", "dbo");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.ToTable("userPermissions", "dbo");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.PermissionId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
