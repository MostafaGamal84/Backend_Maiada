using Orbits.GeneralProject.BLL.BaseReponse;
using Orbits.GeneralProject.DTO.CourseTemplateDto;

namespace Orbits.GeneralProject.BLL.CourseTemplateService
{
    public interface ICourseTemplateBLL
    {
        Task<IResponse<List<CourseTemplateDto>>> Get();
        Task<IResponse<CourseTemplateDto>> Create(CourseTemplateCreateUpdateDto dto);
        Task<IResponse<CourseTemplateDto>> Update(int id, CourseTemplateCreateUpdateDto dto);
        Task<IResponse<bool>> SoftDelete(int id);
    }
}
