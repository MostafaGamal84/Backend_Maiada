using AutoMapper;
using Orbits.GeneralProject.BLL.BaseReponse;
using Orbits.GeneralProject.Core.Entities;
using Orbits.GeneralProject.DTO;
using Orbits.GeneralProject.DTO.BranchDto;
using Orbits.GeneralProject.Repositroy.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.GeneralProject.BLL.BranchService
{
    public class BranchBLL : IBranchBLL
    {
        private readonly IRepository<Branch> _branchRepository;
        private readonly IMapper _mapper;
        public BranchBLL(IRepository<Branch> branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<IResponse<List<BranchReDto>>> Get()
        {
            var output = new Response<List<BranchReDto>> ();
            try
            {

                var AllList = _branchRepository.GetAll();
                var mappedResult = _mapper.Map<List<BranchReDto>>(AllList);
                return output.CreateResponse(mappedResult);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }

        }
    }
}
