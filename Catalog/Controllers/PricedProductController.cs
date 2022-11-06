using System.Reflection;
using AutoMapper;
using Catalog.UnitOfWork;
using Catalog.ViewModels.PricedProductViewModels;
using Microsoft.AspNetCore.Mvc;
using PriceLists.Models;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricedProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PricedProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddPricedProduct(PostPricedProductViewMoedel model)
        {
            var pricedProduct = _mapper.Map<PricedProduct>(model);

            if(await _unitOfWork.PricedProductRepository.AddPricedProducedAsync(pricedProduct))
                if (await _unitOfWork.CompleteAsync())
                    return StatusCode(201, pricedProduct);

            return StatusCode(500, "Error, could not add PricedProduct");
        }

        [HttpGet("companyId")]
        public async Task<IActionResult> GetAllPricedProducts(int comnpanyId)
        {
            var result = await _unitOfWork.PricedProductRepository.ListAllPricedProductsAsync(comnpanyId);
            if (result.Count < 0) return NotFound("Could not find any pricedProducts");

            var response = _mapper.Map<IList<PricedProductViewModel>>(result);

            return Ok(response);

        }

        [HttpGet("companyID/artNumber")]
        public async Task<ActionResult> GetPricedProductByArtNumber(int artNumber, int companyId)
        {
            var result =
                await _unitOfWork.PricedProductRepository.FindPricedProductByArtNumberAsync(artNumber, companyId);
            if (result == null) return NotFound($"Cant find any PricedProduct with artNumber:{artNumber}");

            var response = _mapper.Map<PricedProductViewModel>(result);

            return Ok(response);
        }

        [HttpGet("companyId/id")]
        public async Task<IActionResult> GetPricedProductById(int id, int companyId)
        {
            var result = await _unitOfWork.PricedProductRepository.FindPricedProductByIdAsync(id, companyId);
            if (result == null) return NotFound($"Cnt find any PricedProduct with id:{id}");

            var response = _mapper.Map<PricedProductViewModel>(result);

            return Ok(response);
        }

        [HttpGet("companyId/fromDate/toDate")]
        public async Task<IActionResult> GetPricedProductBetweenDates(DateTime fromDate, DateTime toDate, int companyId)
        {
            var result =
                await _unitOfWork.PricedProductRepository.FindPricedProductByValidBetweenDateAsync(fromDate, toDate, companyId);
            if (result == null) return NotFound($"Cant find any pricedProducts between {fromDate} and {toDate}");

            var response = _mapper.Map<IList<PricedProductViewModel>>(result);

            return Ok(response);
        }

        [HttpGet("companyId/fromDate")]
        public async Task<IActionResult> GetPricedProductFromDate(DateTime fromDate, int companyId)
        {
            var result =
                await _unitOfWork.PricedProductRepository.FindPricedProductByValidFromDateAsync(fromDate, companyId);
            if (result == null) return NotFound($"Cant find any pricedProducts from date: {fromDate}");

            var response = _mapper.Map<IList<PricedProductViewModel>>(result);

            return Ok(response);
        }

        [HttpDelete("companyId/id")]
        public async Task<IActionResult> DeletePricedProduct(int id, int companyId)
        {
            var result = await _unitOfWork.PricedProductRepository.FindPricedProductByIdAsync(id, companyId);
            if (result == null) return NotFound($"Cant find any pricedProduct with id {id}");

            if(_unitOfWork.PricedProductRepository.RemovePricedProductAsync(result))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("PricedProduct removed");

            return StatusCode(500, "Something went wrong with removal");
        }

        [HttpPatch("companyId/id")]
        public async Task<IActionResult> UpdatePricedProduct(int id, int companyId, PatchPricedProductViewModel model)
        {
            var toUpdate = await _unitOfWork.PricedProductRepository.FindPricedProductByIdAsync(id, companyId);
            if (toUpdate == null) return NotFound($"Could not find any pricedProduct with id: {id}");

            toUpdate.ArtNumber = model.ArtNumber;
            toUpdate.ProductId = model.ProductId;
            toUpdate.CompanyId = model.CompanyId;
            toUpdate.ValdidFrom = model.ValdidFrom;
            toUpdate.ValdidTo = model.ValdidTo;
            toUpdate.IsCampaign = model.IsCampaign;
            toUpdate.Price = model.Price;

            if(_unitOfWork.PricedProductRepository.UpdatePricedProductAsync(toUpdate))
                if (await _unitOfWork.CompleteAsync())
                    return Ok(toUpdate);

            return StatusCode(500, "Something went wrong on update");
        }


    }
}


