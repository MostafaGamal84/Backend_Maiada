using Orbits.GeneralProject.BLL.BaseReponse;
using Orbits.GeneralProject.DTO;
using Orbits.GeneralProject.DTO.BranchDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.GeneralProject.BLL.BranchService
{
    public interface IBranchBLL
    {
        Task<IResponse<List<BranchReDto>>> Get();
        Task<IResponse<BranchReDto>> Add(BranchAddDto branchDto);
        Task<IResponse<BranchReDto>> Update(BranchAddDto branchDto);
        Task<IResponse<bool>> SoftDelete(int id);
    }
}
