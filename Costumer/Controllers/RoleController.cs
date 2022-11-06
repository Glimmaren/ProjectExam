using AutoMapper;
using Catalog.ViewModels;
using Costumer.Models;
using Customer.Interfaces;
using Customer.ViewModels;
using Customer.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost()]
        public async Task<IActionResult> AddRole(PostRoleViewModel model)
        {
            var role = _mapper.Map<Role>(model);
            if (await _unitOfWork.RoleRepository.AddRole(role))
                if (await _unitOfWork.CompleteAsync())
                    return Ok(role);

            return StatusCode(500, $"Error, Could not add role");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var role = await _unitOfWork.RoleRepository.FindRoleById(id);
            if (role == null) return NotFound($"Could not find any Role with id {id}");

            var response = _mapper.Map<RoleViewModel>(role);

            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetRoles(string name)
        {
            var role = await _unitOfWork.RoleRepository.FindRolesByName(name);
            if (role == null) return NotFound($"Could not find any roles containing: {name}");

            var response = _mapper.Map<IList<RoleViewModel>>(role);

            return Ok(response);
        }

        [HttpGet()]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _unitOfWork.RoleRepository.ListAllRoles();
            if (result.Count < 1) return NotFound($"could not find any roles");

            var response = _mapper.Map<IList<RoleViewModel>>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _unitOfWork.RoleRepository.FindRoleById(id);
            if (role == null) return NotFound($"Could not find any Role with id: {id}");

            if( _unitOfWork.RoleRepository.DeleteRole(role))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("Role deleted");

            return StatusCode(500, "Something went wrong");

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRole(int id, PatchRoleViewModel model)
        {
            var toUpdate = await _unitOfWork.RoleRepository.FindRoleById(id);
            if (toUpdate == null) return NotFound($"Could not find any Role with id: {id}");

            toUpdate.Name = model?.Name;

            if(_unitOfWork.RoleRepository.UpdateRole(toUpdate))
                if (await _unitOfWork.CompleteAsync())
                {
                    var respone = _mapper.Map<RoleViewModel>(toUpdate);

                    return Ok($"Update successful. {respone}");
                }
                    

            return StatusCode(500, "Something went wrong updating");
        }
    }
}
