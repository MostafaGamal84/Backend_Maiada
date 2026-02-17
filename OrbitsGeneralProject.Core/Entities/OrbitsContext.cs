using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Orbits.GeneralProject.Core.Entities
{
    public partial class OrbitsContext : DbContext
    {
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<CourseInstance> CourseInstances { get; set; } = null!;
        public virtual DbSet<CourseSetting> CourseSettings { get; set; } = null!;
        public virtual DbSet<CourseTemplate> CourseTemplates { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<QuestionChoice> QuestionChoices { get; set; } = null!;
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
        public virtual DbSet<Quizze> Quizzes { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<SessionHistory> SessionHistories { get; set; } = null!;
        public virtual DbSet<SessionPurchas> SessionPurchases { get; set; } = null!;
        public virtual DbSet<SmsLog> SmsLogs { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentAnswer> StudentAnswers { get; set; } = null!;
        public virtual DbSet<StudentQuizAttempt> StudentQuizAttempts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wallet> Wallets { get; set; } = null!;
        public virtual DbSet<WalletTransaction> WalletTransactions { get; set; } = null!;

 public OrbitsContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=LanguageCenterDB;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.HasIndex(e => e.SessionId, "IX_Attendance_Session");

                entity.Property(e => e.ExcuseReason).HasMaxLength(300);

                entity.Property(e => e.MarkedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EnrollmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Att_Enroll");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Att_Session");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<CourseInstance>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Open')");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.CourseInstances)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CI_Branch");

                entity.HasOne(d => d.CourseTemplate)
                    .WithMany(p => p.CourseInstances)
                    .HasForeignKey(d => d.CourseTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CI_Template");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.CourseInstances)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_CI_Teacher");
            });

            modelBuilder.Entity<CourseSetting>(entity =>
            {
                entity.HasIndex(e => e.CourseInstanceId, "UQ__CourseSe__31B5AC09BDBBD691")
                    .IsUnique();

                entity.Property(e => e.AbsenceLimit).HasDefaultValueSql("((3))");

                entity.Property(e => e.AbsenceType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Total')");

                entity.Property(e => e.AllowReplaceWithQuiz).HasDefaultValueSql("((1))");

                entity.Property(e => e.AllowReschedule).HasDefaultValueSql("((1))");

                entity.Property(e => e.AutoDismissEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.RefundPolicy)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('FullCourseOnly')");

                entity.Property(e => e.ReminderBeforeHours).HasDefaultValueSql("((24))");

                entity.HasOne(d => d.CourseInstance)
                    .WithOne(p => p.CourseSetting)
                    .HasForeignKey<CourseSetting>(d => d.CourseInstanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CS_Course");
            });

            modelBuilder.Entity<CourseTemplate>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaultPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Level).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_Enrollments_Student");

                entity.Property(e => e.AbsenceCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.AttendanceCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ConsecutiveAbsenceCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PurchaseType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('FullCourse')");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Active')");

                entity.HasOne(d => d.CourseInstance)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseInstanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enroll_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enroll_Student");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Method).HasMaxLength(50);

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.EnrollmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Enroll");
            });

            modelBuilder.Entity<QuestionChoice>(entity =>
            {
                entity.Property(e => e.ChoiceText).HasMaxLength(500);

                entity.Property(e => e.IsCorrect).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionChoices)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QC_Question");
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QQ_Quiz");
            });

            modelBuilder.Entity<Quizze>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasIndex(e => e.CourseInstanceId, "IX_Sessions_Course");

                entity.Property(e => e.OriginalSessionDate).HasColumnType("date");

                entity.Property(e => e.SessionDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Scheduled')");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Class')");

                entity.HasOne(d => d.CourseInstance)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.CourseInstanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Course");
            });

            modelBuilder.Entity<SessionHistory>(entity =>
            {
                entity.ToTable("SessionHistory");

                entity.Property(e => e.ChangedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewDate).HasColumnType("date");

                entity.Property(e => e.OldDate).HasColumnType("date");

                entity.Property(e => e.Reason).HasMaxLength(300);

                entity.HasOne(d => d.ChangedByNavigation)
                    .WithMany(p => p.SessionHistories)
                    .HasForeignKey(d => d.ChangedBy)
                    .HasConstraintName("FK_SH_User");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionHistories)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SH_Session");
            });

            modelBuilder.Entity<SessionPurchas>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Active')");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionPurchas)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SP_Session");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.SessionPurchas)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SP_Student");
            });

            modelBuilder.Entity<SmsLog>(entity =>
            {
                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.SentAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.SmsLogs)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMS_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.UniqueCode, "IX_Students_UniqueCode");

                entity.HasIndex(e => e.UniqueCode, "UQ__Students__BB96DE6F251726B7")
                    .IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.NationalId).HasMaxLength(50);

                entity.Property(e => e.ParentMobile).HasMaxLength(50);

                entity.Property(e => e.UniqueCode).HasMaxLength(50);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Branch");
            });

            modelBuilder.Entity<StudentAnswer>(entity =>
            {
                entity.HasOne(d => d.Attempt)
                    .WithMany(p => p.StudentAnswers)
                    .HasForeignKey(d => d.AttemptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SA_Attempt");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.StudentAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SA_Question");

                entity.HasOne(d => d.SelectedChoice)
                    .WithMany(p => p.StudentAnswers)
                    .HasForeignKey(d => d.SelectedChoiceId)
                    .HasConstraintName("FK_SA_Choice");
            });

            modelBuilder.Entity<StudentQuizAttempt>(entity =>
            {
                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.StudentQuizAttempts)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SQA_Quiz");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentQuizAttempts)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SQA_Student");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(500);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_Users_Branch");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "UQ__Wallets__32C52B98047FF1CE")
                    .IsUnique();

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.Wallet)
                    .HasForeignKey<Wallet>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wallet_Student");
            });

            modelBuilder.Entity<WalletTransaction>(entity =>
            {
                entity.HasIndex(e => e.WalletId, "IX_WalletTransactions_Wallet");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes).HasMaxLength(300);

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.WalletTransactions)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WT_Wallet");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
