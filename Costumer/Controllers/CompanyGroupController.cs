using AutoMapper;
using Costumer.Models;
using Customer.Interfaces;
using Customer.ViewModels.CompanyCategoryViewModels;
using Customer.ViewModels.CompanyGroupViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyGroupController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyGroupController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyGroup(PostCompanyGroupViewModel companyGroupViewModel)
        {
            var companyCategory = _mapper.Map<CompanyGroup>(companyGroupViewModel);
            if (await _unitOfWork.CompanyGroupRepository.AddCompanyGroupAsync(companyCategory))
                if (await _unitOfWork.CompleteAsync())
                    return Ok(companyCategory);

            return StatusCode(500, "Could not add CompanyGroup");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyGroup(int id)
        {
            var result = await _unitOfWork.CompanyGroupRepository.FindCompanyGroupById(id);
            if (result == null) return NotFound($"Could not find any CompanyGroup with id : {id}");

            var response = _mapper.Map<CompanyGroupViewModel>(result);
            
            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCompanyGroup(string name)
        {
            var result = await _unitOfWork.CompanyGroupRepository.FindCompanyGroupsByName(name);
            if (result.Count <= 0) return NotFound($"Could not find any CompanyGroups");

            var response = _mapper.Map<IList<CompanyGroupViewModel>>(result);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyGroup()
        {
            var result = await _unitOfWork.CompanyGroupRepository.ListAllCompanyGroups();
            if (result.Count <= 0) return NotFound($"Could not find any CompanyGroups");

            var response = _mapper.Map<IList<CompanyGroupViewModel>>(result);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCompanyGroup(int id, PatchCompanyGroupViewModel model)
        {
            var toUpdate = await _unitOfWork.CompanyGroupRepository.FindCompanyGroupById(id);
            if (toUpdate == null) return NotFound($"Could not find any CompanyGroup with id : {id}");

            toUpdate.Name = model.Name;

            if (_unitOfWork.CompanyGroupRepository.UpdateCompanyGroup(toUpdate))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("CompanyGroup updated");

            return StatusCode(500, "Something went wrong updating");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyGroup(int id)
        {
            var result = await _unitOfWork.CompanyGroupRepository.FindCompanyGroupById(id);
            if (result == null) return NotFound($"Could not find any CompanyGroup with id : {id}");

            if (_unitOfWork.CompanyGroupRepository.DeleteCompanyGroup(result))
                if(await _unitOfWork.CompleteAsync())
                    return Ok("CompanyGroup removed");

            return StatusCode(500, "Something went wrong removing CompanyGroup");
        }
    }
}
