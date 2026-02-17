using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orbits.GeneralProject.BLL.CourseInstanceService;
using Orbits.GeneralProject.DTO.CourseInstanceDto;
using Orbits.GeneralProject.DTO.Paging;

namespace OrbitsProject.API.Controllers
{
    [Route("api/course-instances")]
    [ApiController]
    public class CourseInstancesController : ControllerBase
    {
        private readonly ICourseInstanceBLL _courseInstanceBLL;

        public CourseInstancesController(ICourseInstanceBLL courseInstanceBLL)
        {
            _courseInstanceBLL = courseInstanceBLL;
        }

        [HttpGet("GetResultsByFilter")]
        [Authorize(Roles = "Admin,Reception")]
        public async Task<IActionResult> GetResultsByFilter([FromQuery] FilteredResultRequestDto request, [FromQuery] int? branchId, [FromQuery] int? teacherId, [FromQuery] string? status, [FromQuery] string? searchTerm)
        {
            var result = await _courseInstanceBLL.GetResultsByFilter(request, branchId, teacherId, status, searchTerm);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Reception")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _courseInstanceBLL.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateCourseInstanceDto dto)
        {
            var result = await _courseInstanceBLL.Create(dto);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCourseInstanceDto dto)
        {
            var result = await _courseInstanceBLL.Update(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SoftDelete([FromRoute] int id)
        {
            var result = await _courseInstanceBLL.SoftDelete(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/sessions")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> GetSessionsByCourseInstance([FromRoute] int id)
        {
            var result = await _courseInstanceBLL.GetSessionsByCourseInstance(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/students")]
        [Authorize(Roles = "Admin,Reception")]
        public async Task<IActionResult> GetEnrollmentsByCourseInstance([FromRoute] int id)
        {
            var result = await _courseInstanceBLL.GetEnrollmentsByCourseInstance(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/financial-summary")]
        [Authorize(Roles = "Admin,Accountant")]
        public async Task<IActionResult> GetFinancialSummary([FromRoute] int id)
        {
            var result = await _courseInstanceBLL.GetFinancialSummary(id);
            return Ok(result);
        }

        [HttpPut("{id:int}/change-status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromQuery] string status)
        {
            var result = await _courseInstanceBLL.ChangeStatus(id, status);
            return Ok(result);
        }
    }
}
