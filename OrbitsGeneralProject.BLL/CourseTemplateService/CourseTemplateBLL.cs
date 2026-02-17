using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orbits.GeneralProject.BLL.BaseReponse;
using Orbits.GeneralProject.BLL.Constants;
using Orbits.GeneralProject.BLL.Validation.CourseTemplate;
using Orbits.GeneralProject.Core.Entities;
using Orbits.GeneralProject.Core.Infrastructure;
using Orbits.GeneralProject.DTO.CourseTemplateDto;
using Orbits.GeneralProject.Repositroy.Base;

namespace Orbits.GeneralProject.BLL.CourseTemplateService
{
    public class CourseTemplateBLL : ICourseTemplateBLL
    {
        private readonly IRepository<CourseTemplate> _courseTemplateRepository;
        private readonly IRepository<CourseInstance> _courseInstanceRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CourseTemplateCreateUpdateValidator _validator;

        public CourseTemplateBLL(
            IRepository<CourseTemplate> courseTemplateRepository,
            IRepository<CourseInstance> courseInstanceRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _courseTemplateRepository = courseTemplateRepository;
            _courseInstanceRepository = courseInstanceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = new CourseTemplateCreateUpdateValidator();
        }

        public async Task<IResponse<CourseTemplateDto>> Create(CourseTemplateCreateUpdateDto dto)
        {
            var output = new Response<CourseTemplateDto>();

            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return output.CreateResponse(validationResult.Errors);
                }

                var courseTemplate = _mapper.Map<CourseTemplate>(dto);
                courseTemplate.CreatedAt = DateTime.UtcNow;
                courseTemplate.IsDeleted = false;

                await _courseTemplateRepository.AddAsync(courseTemplate);
                await _unitOfWork.CommitAsync();

                var mappedResult = _mapper.Map<CourseTemplateDto>(courseTemplate);
                return output.CreateResponse(mappedResult);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<List<CourseTemplateDto>>> Get()
        {
            var output = new Response<List<CourseTemplateDto>>();

            try
            {
                var templates = await _courseTemplateRepository.GetAll().ToListAsync();
                var mappedResult = _mapper.Map<List<CourseTemplateDto>>(templates);
                return output.CreateResponse(mappedResult);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<CourseTemplateDto>> Update(int id, CourseTemplateCreateUpdateDto dto)
        {
            var output = new Response<CourseTemplateDto>();

            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return output.CreateResponse(validationResult.Errors);
                }

                var existingTemplate = await _courseTemplateRepository.GetByIdAsync(id);
                if (existingTemplate == null || existingTemplate.IsDeleted)
                {
                    return output.CreateResponse(MessageCodes.NotFound, "Course template not found");
                }

                existingTemplate.Name = dto.Name;
                existingTemplate.Level = dto.Level;
                existingTemplate.DurationWeeks = dto.DurationWeeks;
                existingTemplate.DefaultPrice = dto.DefaultPrice;

                _courseTemplateRepository.Update(existingTemplate);
                await _unitOfWork.CommitAsync();

                var mappedResult = _mapper.Map<CourseTemplateDto>(existingTemplate);
                return output.CreateResponse(mappedResult);
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
                var existingTemplate = await _courseTemplateRepository.GetByIdAsync(id);
                if (existingTemplate == null || existingTemplate.IsDeleted)
                {
                    return output.CreateResponse(MessageCodes.NotFound, "Course template not found");
                }

                var hasActiveCourseInstances = await _courseInstanceRepository.AnyAsync(x =>
                    x.CourseTemplateId == id &&
                    !x.IsDeleted &&
                    x.Status != null && x.Status.ToLower() == "active");

                if (hasActiveCourseInstances)
                {
                    return output.CreateResponse(MessageCodes.RelatedDataExist, "Cannot delete template linked to active course instances");
                }

                existingTemplate.IsDeleted = true;
                _courseTemplateRepository.Update(existingTemplate);
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
