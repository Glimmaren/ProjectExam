using AutoMapper;
using Catalog.UnitOfWork;
using Catalog.ViewModels.CategoryViewModels;
using Catalog.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using PriceLists.Models;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost()]
        public async Task<IActionResult> AddProduct(PostProductViewModel model)
        {
            var product = _mapper.Map<Product>(model);

            if (!await _unitOfWork.ProductRepository.AddProductAsync(product))
                return StatusCode(500, "Error, could not save product");

            if (!await _unitOfWork.CompleteAsync())
                return StatusCode(500, "Error, could not save product");

            var result = _mapper.Map<PostProductViewModel>(product);

            return StatusCode(201, result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _unitOfWork.ProductRepository.FindProductByIdAsync(id);
            if (product == null) return NotFound($"Error, could not find any product with id:{id}");

            var response = _mapper.Map<ProductViewModel>(product);

            return StatusCode(201, response);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var products = await _unitOfWork.ProductRepository.FindProductIncludingNameAsync(name);
            if (products == null) return NotFound($"Error could not find any product with the name:{name}");

            var response = _mapper.Map<IList<ProductViewModel>>(products, opt => opt.Items["repo"] = _unitOfWork.Context);

            return StatusCode(201, response);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _unitOfWork.ProductRepository.ListAllProductsAsync();
            if (products.Count < 1) return NotFound($"Error, could not find any products");

            var response = _mapper.Map<IList<ProductViewModel>>(products);

            return StatusCode(201, response);
        }

        [HttpPatch("id")]
        public async Task<IActionResult> UpdateProductById(int id, PatchProductViewModel model)
        {
           // var product = _mapper.Map<Product>(model, opt => opt.Items["repo"] = _unitOfWork.Context);

            var toUpdate = await _unitOfWork.ProductRepository.FindProductByIdAsync(id);
            if (toUpdate == null) return NotFound($"Error, could not find any product with id:{id}");

            toUpdate.Name = model.Name;
            toUpdate.CategoryId = model.CategoryId;

            if (_unitOfWork.ProductRepository.UpdateProductAsync(toUpdate))
                if (await _unitOfWork.CompleteAsync())
                {
                    var response = _mapper.Map<PatchProductViewModel>(toUpdate);
                    return StatusCode(201, response);
                }

            return StatusCode(500, "Error, could not update");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var result = await _unitOfWork.ProductRepository.FindProductByIdAsync(id);
            if (result == null) return NotFound($"Error, could not find a category with id:{id}");

            if (_unitOfWork.ProductRepository.RemoveProductAsync(result))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("Category removed");

            return StatusCode(500, "Something went wrong with the removal");
        }

    }
}
