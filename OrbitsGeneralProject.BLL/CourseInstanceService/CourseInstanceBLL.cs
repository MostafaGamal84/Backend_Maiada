using Microsoft.EntityFrameworkCore;
using Orbits.GeneralProject.BLL.BaseReponse;
using Orbits.GeneralProject.BLL.Constants;
using Orbits.GeneralProject.Core.Entities;
using Orbits.GeneralProject.Core.Infrastructure;
using Orbits.GeneralProject.DTO.CourseInstanceDto;
using Orbits.GeneralProject.DTO.Paging;
using Orbits.GeneralProject.Repositroy.Base;
using System.Transactions;

namespace Orbits.GeneralProject.BLL.CourseInstanceService
{
    public class CourseInstanceBLL : ICourseInstanceBLL
    {
        private readonly IRepository<CourseInstance> _courseInstanceRepository;
        private readonly IRepository<CourseTemplate> _courseTemplateRepository;
        private readonly IRepository<Branch> _branchRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<CourseSetting> _courseSettingRepository;
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<Enrollment> _enrollmentRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseInstanceBLL(
            IRepository<CourseInstance> courseInstanceRepository,
            IRepository<CourseTemplate> courseTemplateRepository,
            IRepository<Branch> branchRepository,
            IRepository<User> userRepository,
            IRepository<CourseSetting> courseSettingRepository,
            IRepository<Session> sessionRepository,
            IRepository<Enrollment> enrollmentRepository,
            IRepository<Payment> paymentRepository,
            IUnitOfWork unitOfWork)
        {
            _courseInstanceRepository = courseInstanceRepository;
            _courseTemplateRepository = courseTemplateRepository;
            _branchRepository = branchRepository;
            _userRepository = userRepository;
            _courseSettingRepository = courseSettingRepository;
            _sessionRepository = sessionRepository;
            _enrollmentRepository = enrollmentRepository;
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<PagedResultDto<CourseInstanceDto>>> GetResultsByFilter(FilteredResultRequestDto request, int? branchId, int? teacherId, string? status, string? searchTerm)
        {
            var output = new Response<PagedResultDto<CourseInstanceDto>>();
            try
            {
                var query = _courseInstanceRepository.GetAll()
                    .Include(ci => ci.CourseTemplate)
                    .Include(ci => ci.Branch)
                    .Include(ci => ci.Teacher)
                    .AsQueryable();

                if (branchId.HasValue)
                    query = query.Where(x => x.BranchId == branchId.Value);

                if (teacherId.HasValue)
                    query = query.Where(x => x.TeacherId == teacherId.Value);

                if (!string.IsNullOrWhiteSpace(status))
                    query = query.Where(x => x.Status.ToLower() == status.ToLower());

                var term = searchTerm ?? request.SearchTerm;
                if (!string.IsNullOrWhiteSpace(term))
                {
                    var normalizedTerm = term.Trim().ToLower();
                    query = query.Where(x =>
                        x.CourseTemplate.Name.ToLower().Contains(normalizedTerm) ||
                        x.Branch.Name.ToLower().Contains(normalizedTerm) ||
                        (x.Teacher != null && x.Teacher.FullName.ToLower().Contains(normalizedTerm)));
                }

                var totalCount = await query.CountAsync();
                var items = await query
                    .OrderByDescending(x => x.Id)
                    .Skip(request.SkipCount)
                    .Take(request.MaxResultCount)
                    .Select(x => new CourseInstanceDto
                    {
                        Id = x.Id,
                        CourseTemplateId = x.CourseTemplateId,
                        TemplateName = x.CourseTemplate.Name,
                        BranchId = x.BranchId,
                        BranchName = x.Branch.Name,
                        TeacherId = x.TeacherId,
                        TeacherName = x.Teacher != null ? x.Teacher.FullName : null,
                        TotalSessions = x.TotalSessions,
                        Price = x.Price,
                        Status = x.Status,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate
                    })
                    .ToListAsync();

                var paged = new PagedResultDto<CourseInstanceDto>(totalCount, items);
                return output.CreateResponse(paged);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<CourseInstanceDto>> GetById(int id)
        {
            var output = new Response<CourseInstanceDto>();
            try
            {
                var item = await _courseInstanceRepository
                    .GetAll()
                    .Include(ci => ci.CourseTemplate)
                    .Include(ci => ci.Branch)
                    .Include(ci => ci.Teacher)
                    .Where(ci => ci.Id == id)
                    .Select(ci => new CourseInstanceDto
                    {
                        Id = ci.Id,
                        CourseTemplateId = ci.CourseTemplateId,
                        TemplateName = ci.CourseTemplate.Name,
                        BranchId = ci.BranchId,
                        BranchName = ci.Branch.Name,
                        TeacherId = ci.TeacherId,
                        TeacherName = ci.Teacher != null ? ci.Teacher.FullName : null,
                        TotalSessions = ci.TotalSessions,
                        Price = ci.Price,
                        Status = ci.Status,
                        StartDate = ci.StartDate,
                        EndDate = ci.EndDate
                    })
                    .FirstOrDefaultAsync();

                if (item == null)
                {
                    return output.CreateResponse(MessageCodes.NotFound, "Course instance not found");
                }

                return output.CreateResponse(item);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<bool>> Create(CreateCourseInstanceDto dto)
        {
            var output = new Response<bool>();
            try
            {
                if (dto.Price <= 0)
                    return output.CreateResponse(MessageCodes.GreaterThanZero, "Price must be greater than zero");

                if (dto.TotalSessions <= 0)
                    return output.CreateResponse(MessageCodes.GreaterThanZero, "Total sessions must be greater than zero");

                var template = await _courseTemplateRepository.GetByIdAsync(dto.CourseTemplateId);
                if (template == null || template.IsDeleted)
                    return output.CreateResponse(MessageCodes.NotFound, "Course template not found");

                var branch = await _branchRepository.GetByIdAsync(dto.BranchId);
                if (branch == null)
                    return output.CreateResponse(MessageCodes.NotFound, "Branch not found");

                var teacher = await _userRepository.GetByIdAsync(dto.TeacherId);
                if (teacher == null || teacher.IsDeleted || !string.Equals(teacher.Role, "Teacher", StringComparison.OrdinalIgnoreCase))
                    return output.CreateResponse(MessageCodes.NotFound, "Teacher not found or invalid role");

                using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

                var endDate = dto.StartDate.AddDays(Math.Max(dto.TotalSessions - 1, 0));
                var courseInstance = new CourseInstance
                {
                    CourseTemplateId = dto.CourseTemplateId,
                    BranchId = dto.BranchId,
                    TeacherId = dto.TeacherId,
                    TotalSessions = dto.TotalSessions,
                    StartDate = dto.StartDate.Date,
                    EndDate = endDate.Date,
                    Price = dto.Price,
                    Status = string.IsNullOrWhiteSpace(dto.Status) ? "Open" : dto.Status,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                await _courseInstanceRepository.AddAsync(courseInstance);
                await _unitOfWork.CommitAsync();

                var settings = new CourseSetting
                {
                    CourseInstanceId = courseInstance.Id,
                    AbsenceLimit = 3,
                    AbsenceType = "Sessions",
                    ReminderBeforeHours = 24,
                    AllowReschedule = true,
                    AllowReplaceWithQuiz = false,
                    AutoDismissEnabled = false,
                    RefundPolicy = "No refund after start",
                    IsDeleted = false
                };
                await _courseSettingRepository.AddAsync(settings);

                var sessions = new List<Session>();
                for (var i = 1; i <= dto.TotalSessions; i++)
                {
                    sessions.Add(new Session
                    {
                        CourseInstanceId = courseInstance.Id,
                        SessionNumber = i,
                        SessionDate = dto.StartDate.Date.AddDays(i - 1),
                        StartTime = TimeSpan.Zero,
                        EndTime = TimeSpan.Zero,
                        Type = "Class",
                        Status = "Scheduled",
                        IsDeleted = false
                    });
                }

                _sessionRepository.Add(sessions);
                await _unitOfWork.CommitAsync();

                transaction.Complete();

                return output.CreateResponse(true);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<bool>> Update(int id, UpdateCourseInstanceDto dto)
        {
            var output = new Response<bool>();
            try
            {
                var item = await _courseInstanceRepository.GetByIdAsync(id);
                if (item == null || item.IsDeleted)
                    return output.CreateResponse(MessageCodes.NotFound, "Course instance not found");

                if (dto.Price <= 0)
                    return output.CreateResponse(MessageCodes.GreaterThanZero, "Price must be greater than zero");

                item.Price = dto.Price;
                item.Status = dto.Status;

                _courseInstanceRepository.Update(item);
                await _unitOfWork.CommitAsync();

                return output.CreateResponse(true);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<bool>> SoftDelete(int id)
        {
            var output = new Response<bool>();
            try
            {
                var item = await _courseInstanceRepository.GetByIdAsync(id);
                if (item == null || item.IsDeleted)
                    return output.CreateResponse(MessageCodes.NotFound, "Course instance not found");

                var hasActiveEnrollment = await _enrollmentRepository.AnyAsync(e => e.CourseInstanceId == id && (e.Status ?? "").ToLower() == "active");
                if (hasActiveEnrollment)
                    return output.CreateResponse(MessageCodes.RelatedDataExist, "Cannot delete course with active students");

                item.IsDeleted = true;
                item.Status = "Cancelled";

                _courseInstanceRepository.Update(item);
                await _unitOfWork.CommitAsync();

                return output.CreateResponse(true);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<List<SessionDto>>> GetSessionsByCourseInstance(int id)
        {
            var output = new Response<List<SessionDto>>();
            try
            {
                var exists = await _courseInstanceRepository.AnyAsync(ci => ci.Id == id);
                if (!exists)
                    return output.CreateResponse(MessageCodes.NotFound, "Course instance not found");

                var sessions = await _sessionRepository.GetAll()
                    .Where(s => s.CourseInstanceId == id)
                    .OrderBy(s => s.SessionNumber)
                    .Select(s => new SessionDto
                    {
                        Id = s.Id,
                        SessionNumber = s.SessionNumber,
                        SessionDate = s.SessionDate,
                        Type = s.Type,
                        Status = s.Status
                    })
                    .ToListAsync();

                return output.CreateResponse(sessions);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<List<EnrollmentDto>>> GetEnrollmentsByCourseInstance(int id)
        {
            var output = new Response<List<EnrollmentDto>>();
            try
            {
                var exists = await _courseInstanceRepository.AnyAsync(ci => ci.Id == id);
                if (!exists)
                    return output.CreateResponse(MessageCodes.NotFound, "Course instance not found");

                var enrollments = await _enrollmentRepository.GetAll()
                    .Where(e => e.CourseInstanceId == id)
                    .Include(e => e.Student)
                    .Select(e => new EnrollmentDto
                    {
                        EnrollmentId = e.Id,
                        StudentId = e.StudentId,
                        StudentName = e.Student.FullName,
                        AttendanceCount = e.AttendanceCount ?? 0,
                        AbsenceCount = e.AbsenceCount ?? 0,
                        Status = e.Status
                    })
                    .ToListAsync();

                return output.CreateResponse(enrollments);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<CourseFinancialSummaryDto>> GetFinancialSummary(int id)
        {
            var output = new Response<CourseFinancialSummaryDto>();
            try
            {
                var exists = await _courseInstanceRepository.AnyAsync(ci => ci.Id == id);
                if (!exists)
                    return output.CreateResponse(MessageCodes.NotFound, "Course instance not found");

                var enrollmentIds = await _enrollmentRepository.GetAll()
                    .Where(e => e.CourseInstanceId == id)
                    .Select(e => e.Id)
                    .ToListAsync();

                var payments = await _paymentRepository.GetAll()
                    .Where(p => enrollmentIds.Contains(p.EnrollmentId))
                    .ToListAsync();

                var totalCollected = payments.Where(p => p.Amount > 0).Sum(p => p.Amount);
                var refundedFromNegative = payments.Where(p => p.Amount < 0).Sum(p => Math.Abs(p.Amount));
                var refundedByMethod = payments.Where(p => p.Amount > 0 && (p.Method ?? string.Empty).ToLower().Contains("refund")).Sum(p => p.Amount);
                var totalRefunded = refundedFromNegative + refundedByMethod;

                var response = new CourseFinancialSummaryDto
                {
                    TotalEnrolledStudents = enrollmentIds.Count,
                    TotalCollectedAmount = totalCollected,
                    TotalRefundedAmount = totalRefunded,
                    NetIncome = totalCollected - totalRefunded
                };

                return output.CreateResponse(response);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<bool>> ChangeStatus(int id, string status)
        {
            var output = new Response<bool>();
            try
            {
                var allowedStatuses = new[] { "Open", "Running", "Finished", "Cancelled" };
                if (!allowedStatuses.Contains(status, StringComparer.OrdinalIgnoreCase))
                    return output.CreateResponse(MessageCodes.BusinessValidationError, "Invalid status");

                var item = await _courseInstanceRepository.GetByIdAsync(id);
                if (item == null || item.IsDeleted)
                    return output.CreateResponse(MessageCodes.NotFound, "Course instance not found");

                if (string.Equals(item.Status, "Cancelled", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(status, "Cancelled", StringComparison.OrdinalIgnoreCase))
                {
                    return output.CreateResponse(MessageCodes.BusinessValidationError, "Cannot reopen cancelled course");
                }

                if (string.Equals(status, "Finished", StringComparison.OrdinalIgnoreCase))
                {
                    var hasIncompleteSessions = await _sessionRepository.AnyAsync(s =>
                        s.CourseInstanceId == id &&
                        (s.Status == null || !s.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)));

                    if (hasIncompleteSessions)
                        return output.CreateResponse(MessageCodes.BusinessValidationError, "Cannot finish course before all sessions are completed");
                }

                item.Status = allowedStatuses.First(s => s.Equals(status, StringComparison.OrdinalIgnoreCase));
                _courseInstanceRepository.Update(item);
                await _unitOfWork.CommitAsync();

                return output.CreateResponse(true);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }
    }
}
