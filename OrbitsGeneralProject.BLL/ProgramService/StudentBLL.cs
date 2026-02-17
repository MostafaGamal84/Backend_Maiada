using AutoMapper;
using Orbits.GeneralProject.BLL.BaseReponse;
using Orbits.GeneralProject.Core.Entities;
using Orbits.GeneralProject.DTO;
using Orbits.GeneralProject.DTO.StudentDto;
using Orbits.GeneralProject.Repositroy.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.GeneralProject.BLL.ProgramService
{
    public class StudentBLL : IStudentBLL
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;
        public StudentBLL(IRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IResponse<List<StudentLookupDto>>> GetStudents()
        {
            var output = new Response<List<StudentLookupDto>> ();
            try
            {

                var AllList = _studentRepository.GetAll();
                var mappedResult = _mapper.Map<List<StudentLookupDto>>(AllList);
                return output.CreateResponse(mappedResult);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }

        }
    }
}
