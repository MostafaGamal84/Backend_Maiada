using HandlebarsDotNet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Orbits.GeneralProject.BLL.ProgramService;
using Orbits.GeneralProject.Core.Entities;

namespace OrbitsProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //To do Injection for Services BLL
        private readonly IStudentBLL _programBLL;
        public HomeController(IStudentBLL programBLL)
        {
            _programBLL = programBLL;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {

            return Ok();
        }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>  Gets all cameras with contain any region Id in string called regionsIds  </summary>
        /// 
        /// <input> list of numbers   </input>
        /// 
        /// <value> List Of CameraReturnDto </value>
        ///-------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _programBLL.GetStudents();

            return Ok(result);
        }
    }
}
