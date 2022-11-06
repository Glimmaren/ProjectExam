using AutoMapper;
using Costumer.Models;
using Customer.Interfaces;
using Customer.ViewModels.CompanyCategoryViewModels;
using Customer.ViewModels.CompanyGroupViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyCategoryController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyGroup(PostCompanyCategoryViewModel model)
        {
            var companyCategory = _mapper.Map<CompanyCategory>(model);
            if (await _unitOfWork.CompanyCategoryRepository.AddCompanyCategory(companyCategory))
                if (await _unitOfWork.CompleteAsync())
                    return Ok(companyCategory);

            return StatusCode(500, "Could not add CompanyCategory");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyCategory(int id)
        {
            var result = await _unitOfWork.CompanyCategoryRepository.FindCompanyCategoryById(id);
            if (result == null) return NotFound($"Could not find any CompanyCategory with id : {id}");

            var response = _mapper.Map<CompanyCategoryViewModel>(result);

            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCompanyCategory(string name)
        {
            var result = await _unitOfWork.CompanyCategoryRepository.FindCompanyCategoriesByName(name);
            if (result.Count <= 0) return NotFound($"Could not find any CompanyGroups");

            var response = _mapper.Map<IList<CompanyCategoryViewModel>>(result);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyCategory()
        {
            var result = await _unitOfWork.CompanyCategoryRepository.ListAllCompanyCategory();
            if (result.Count <= 0) return NotFound($"Could not find any CompanyCategories");

            var response = _mapper.Map<IList<CompanyCategoryViewModel>>(result);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCompanyCategory(int id, PatchCompanyCategoryViewModel model)
        {
            var toUpdate = await _unitOfWork.CompanyCategoryRepository.FindCompanyCategoryById(id);
            if (toUpdate == null) return NotFound($"Could not find any CompanyCategory with id : {id}");

            toUpdate.Name = model.Name;

            if (_unitOfWork.CompanyCategoryRepository.UpdateCompanyCategory(toUpdate))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("CompanyCategory updated");

            return StatusCode(500, "Something went wrong updating");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyCategory(int id)
        {
            var result = await _unitOfWork.CompanyCategoryRepository.FindCompanyCategoryById(id);
            if (result == null) return NotFound($"Could not find any CompanyCategory with id : {id}");

            if (_unitOfWork.CompanyCategoryRepository.DeleteCompanyCategory(result))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("CompanyCategory removed");

            return StatusCode(500, "Something went wrong removing CompanyCategory");
        }
    }
}
