using Orbits.GeneralProject.BLL.BaseReponse;
using Orbits.GeneralProject.DTO.CourseInstanceDto;
using Orbits.GeneralProject.DTO.Paging;

namespace Orbits.GeneralProject.BLL.CourseInstanceService
{
    public interface ICourseInstanceBLL
    {
        Task<IResponse<PagedResultDto<CourseInstanceDto>>> GetResultsByFilter(FilteredResultRequestDto request, int? branchId, int? teacherId, string? status, string? searchTerm);
        Task<IResponse<CourseInstanceDto>> GetById(int id);
        Task<IResponse<bool>> Create(CreateCourseInstanceDto dto);
        Task<IResponse<bool>> Update(int id, UpdateCourseInstanceDto dto);
        Task<IResponse<bool>> SoftDelete(int id);
        Task<IResponse<List<SessionDto>>> GetSessionsByCourseInstance(int id);
        Task<IResponse<List<EnrollmentDto>>> GetEnrollmentsByCourseInstance(int id);
        Task<IResponse<CourseFinancialSummaryDto>> GetFinancialSummary(int id);
        Task<IResponse<bool>> ChangeStatus(int id, string status);
    }
}
