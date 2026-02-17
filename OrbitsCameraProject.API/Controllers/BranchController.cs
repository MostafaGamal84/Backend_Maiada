using HandlebarsDotNet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Orbits.GeneralProject.BLL.BranchService;
using Orbits.GeneralProject.Core.Entities;

namespace OrbitsProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        //To do Injection for Services BLL
        private readonly IBranchBLL _branchBLL;
        public BranchController(IBranchBLL branchBLL)
        {
            _branchBLL = branchBLL;
        }
     
        ///-------------------------------------------------------------------------------------------------
        /// <summary>  Gets all cameras with contain any region Id in string called regionsIds  </summary>
        /// 
        /// <input> list of numbers   </input>
        /// 
        /// <value> List Of CameraReturnDto </value>
        ///-------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _branchBLL.Get();

            return Ok(result);
        }
    }
}
