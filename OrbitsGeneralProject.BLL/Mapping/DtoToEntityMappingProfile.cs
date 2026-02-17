using AutoMapper;
using Orbits.GeneralProject.Core.Entities;
using Orbits.GeneralProject.DTO.BranchDto;
using Orbits.GeneralProject.DTO.CourseTemplateDto;
using Orbits.GeneralProject.DTO.Paging;

namespace Orbits.GeneralProject.BLL.Mapping
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile( )
        {

            CreateMap<BranchAddDto, Branch>();
            CreateMap<CourseTemplateCreateUpdateDto, CourseTemplate>();

        }
    }
}