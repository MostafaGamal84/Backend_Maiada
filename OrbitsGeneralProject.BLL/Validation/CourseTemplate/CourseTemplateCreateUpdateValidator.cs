using FluentValidation;
using Orbits.GeneralProject.DTO.CourseTemplateDto;

namespace Orbits.GeneralProject.BLL.Validation.CourseTemplate
{
    public class CourseTemplateCreateUpdateValidator : DtoValidationAbstractBase<CourseTemplateCreateUpdateDto>
    {
        public CourseTemplateCreateUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.DurationWeeks)
                .GreaterThan(0);
        }
    }
}
