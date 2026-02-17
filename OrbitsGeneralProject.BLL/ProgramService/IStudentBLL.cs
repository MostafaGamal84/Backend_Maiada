using Orbits.GeneralProject.BLL.BaseReponse;
using Orbits.GeneralProject.DTO;
using Orbits.GeneralProject.DTO.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.GeneralProject.BLL.ProgramService
{
    public interface IStudentBLL
    {
        Task<IResponse<List<StudentLookupDto>>> GetStudents();
    }
}
