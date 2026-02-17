using AutoMapper;
using Orbits.GeneralProject.BLL.BaseReponse;
using Orbits.GeneralProject.Core.Entities;
using Orbits.GeneralProject.DTO;
using Orbits.GeneralProject.Core.Infrastructure;
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
        private readonly IUnitOfWork _unitOfWork;

        public BranchBLL(IRepository<Branch> branchRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<IResponse<BranchReDto>> Add(BranchAddDto branchDto)
        {
            var output = new Response<BranchReDto>();
            try
            {
                var branch = _mapper.Map<Branch>(branchDto);
                branch.CreatedAt = DateTime.UtcNow;
                branch.IsDeleted = false;

                await _branchRepository.AddAsync(branch);
                await _unitOfWork.CommitAsync();

                var mappedResult = _mapper.Map<BranchReDto>(branch);
                return output.CreateResponse(mappedResult);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
        }

        public async Task<IResponse<BranchReDto>> Update(BranchAddDto branchDto)
        {
            var output = new Response<BranchReDto>();
            try
            {
                var existingBranch = await _branchRepository.GetByIdAsync(branchDto.Id);

                if (existingBranch == null || existingBranch.IsDeleted)
                {
                    return output.CreateResponse(Orbits.GeneralProject.BLL.Constants.MessageCodes.NotFound, "Branch not found");
                }

                existingBranch.Name = branchDto.Name;
                existingBranch.Address = branchDto.Address;
                existingBranch.Phone = branchDto.Phone;

                _branchRepository.Update(existingBranch);
                await _unitOfWork.SaveChanges();

                var mappedResult = _mapper.Map<BranchReDto>(existingBranch);
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
                var existingBranch = await _branchRepository.GetByIdAsync(id);

                if (existingBranch == null || existingBranch.IsDeleted)
                {
                    return output.CreateResponse(Orbits.GeneralProject.BLL.Constants.MessageCodes.NotFound, "Branch not found");
                }

                existingBranch.IsDeleted = true;
                _branchRepository.Update(existingBranch);
                await _unitOfWork.SaveChanges();

                return output.CreateResponse(true);
            }
            catch (Exception ex)
            {
                return output.CreateResponse(ex);
            }
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
