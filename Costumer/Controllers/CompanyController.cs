using AutoMapper;
using Costumer.Models;
using Customer.Interfaces;
using Customer.Models;
using Customer.ViewModels.CompanyCategoryViewModels;
using Customer.ViewModels.CompanyViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(PostCompanyViewModel model)
        {
            var company = _mapper.Map<Company>(model);
            if (await _unitOfWork.CompanyRepository.AddCompany(company))
                if (await _unitOfWork.CompleteAsync())
                    return Ok(model);

            return StatusCode(500, "Could not add Company");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var result = await _unitOfWork.CompanyRepository.FindCompanyById(id);
            if (result == null) return NotFound($"Could not find any Company with id : {id}");

            var response = _mapper.Map<CompanyViewModel>(result);

            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCompanyByName(string name)
        {
            var result = await _unitOfWork.CompanyRepository.FindCompaniesByName(name);
            if (result.Count <= 0) return NotFound($"Could not find any Company");

            var response = _mapper.Map<IList<CompanyViewModel>>(result);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompany()
        {
            var result = await _unitOfWork.CompanyRepository.ListAllCompanies();
            if (result.Count <= 0) return NotFound($"Could not find any Companies");

            var response = _mapper.Map<IList<CompanyViewModel>>(result);
            Console.WriteLine(result);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, PatchCompanyViewModel model)
        {
            var toUpdate = await _unitOfWork.CompanyRepository.FindCompanyById(id);
            if (toUpdate == null) return NotFound($"Could not find any Company with id : {id}");

            toUpdate.Name = model.Name;
            toUpdate.CompanyCategoryId = model.CompanyCategoryId;
            toUpdate.CompanyGroupId = model.CompanyGroupId;
            toUpdate.Wholesale = model.Wholesale;

            if (_unitOfWork.CompanyRepository.UpdateComapny(toUpdate))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("Company updated");

            return StatusCode(500, "Something went wrong updating");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await _unitOfWork.CompanyRepository.FindCompanyById(id);
            if (result == null) return NotFound($"Could not find any Company with id : {id}");

            if (_unitOfWork.CompanyRepository.DeleteCompany(result))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("Company removed");

            return StatusCode(500, "Something went wrong removing CompanyCategory");
        }
    }
}
