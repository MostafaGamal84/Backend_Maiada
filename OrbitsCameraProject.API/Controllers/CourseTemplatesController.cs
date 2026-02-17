using Microsoft.AspNetCore.Mvc;
using Orbits.GeneralProject.BLL.CourseTemplateService;
using Orbits.GeneralProject.DTO.CourseTemplateDto;

namespace OrbitsProject.API.Controllers
{
    [Route("api/course-templates")]
    [ApiController]
    public class CourseTemplatesController : ControllerBase
    {
        private readonly ICourseTemplateBLL _courseTemplateBLL;

        public CourseTemplatesController(ICourseTemplateBLL courseTemplateBLL)
        {
            _courseTemplateBLL = courseTemplateBLL;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _courseTemplateBLL.Get();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseTemplateCreateUpdateDto dto)
        {
            var result = await _courseTemplateBLL.Create(dto);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CourseTemplateCreateUpdateDto dto)
        {
            var result = await _courseTemplateBLL.Update(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _courseTemplateBLL.SoftDelete(id);
            return Ok(result);
        }
    }
}
