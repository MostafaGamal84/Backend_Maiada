namespace Orbits.GeneralProject.DTO.CourseInstanceDto
{
    public class CreateCourseInstanceDto
    {
        public int CourseTemplateId { get; set; }
        public int BranchId { get; set; }
        public int TeacherId { get; set; }
        public int TotalSessions { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = "Open";
    }

    public class UpdateCourseInstanceDto
    {
        public decimal Price { get; set; }
        public string Status { get; set; } = null!;
    }

    public class CourseInstanceDto
    {
        public int Id { get; set; }
        public int CourseTemplateId { get; set; }
        public string TemplateName { get; set; } = null!;
        public int BranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public int? TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public int TotalSessions { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class SessionDto
    {
        public int Id { get; set; }
        public int SessionNumber { get; set; }
        public DateTime SessionDate { get; set; }
        public string Type { get; set; } = null!;
        public string? Status { get; set; }
    }

    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public int AttendanceCount { get; set; }
        public int AbsenceCount { get; set; }
        public string? Status { get; set; }
    }

    public class CourseFinancialSummaryDto
    {
        public int TotalEnrolledStudents { get; set; }
        public decimal TotalCollectedAmount { get; set; }
        public decimal TotalRefundedAmount { get; set; }
        public decimal NetIncome { get; set; }
    }
}
