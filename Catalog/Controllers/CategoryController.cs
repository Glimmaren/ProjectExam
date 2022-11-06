using System.Collections;
using AutoMapper;
using Catalog.Repositorys;
using Catalog.UnitOfWork;
using Catalog.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PriceLists.Models;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost()]
        public async Task<IActionResult> AddCategory(PostCategoryViewModel category)
        {
            var categoryModel = _mapper.Map<Category>(category);

            if (await _unitOfWork.CategoryRepository.AddCategoryAsync(categoryModel))
                if (await _unitOfWork.CompleteAsync())
                    return StatusCode(201, category);

            return StatusCode(500, "Error when saving category");
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCategorys()
        {
            var result = await _unitOfWork.CategoryRepository.ListAllCategoriesAsync();

            var response = _mapper.Map<IList<CategoryViewModel>>(result);

            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> FindCategoryById(int id)
        {
            var result = await _unitOfWork.CategoryRepository.FindCategoryByIdAsync(id);
            if (result == null) return NotFound($"Could not find a category with id:{id}");

            var response = _mapper.Map<CategoryViewModel>(result);

            return Ok(response);
        }

        [HttpGet("name")]
        public async Task<IActionResult> FindCategoryByName(string name)
        {
            var result = await _unitOfWork.CategoryRepository.FindCategoryThatIncludesNameAsync(name);
            if (result == null) return NotFound($"Could not find a category with named:{name}");

            var response = _mapper.Map<IList<CategoryViewModel>>(result);

            return Ok(response);
        }

        [HttpPatch("id")]
        public async Task<IActionResult> UpdateCategory(int id, PatchCatergoryViewModel category)
        {
            var toUpdate = await _unitOfWork.CategoryRepository.FindCategoryByIdAsync(id);
            if (toUpdate == null) return NotFound($"Error, could not find a category with id{id}"); //??

            toUpdate.Name = category?.Name;
            if (_unitOfWork.CategoryRepository.UpdateCategory(toUpdate))
                if (await _unitOfWork.CompleteAsync())
                {
                    var response = _mapper.Map<CategoryViewModel>(toUpdate);

                    return StatusCode(201, category);
                }

            return StatusCode(500, "Could not save update");

        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            
            var result = await _unitOfWork.CategoryRepository.FindCategoryByIdAsync(id);
            if (result == null) return NotFound($"Error, could not find a category with id:{id}");

            if (_unitOfWork.CategoryRepository.RemoveCategory(result))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("Category removed");

            return StatusCode(500, "Something went wrong with the removal");
        }

        [HttpDelete("name")]
        public async Task<IActionResult> DeleteCategoryByName(string name)
        {
            var result = await _unitOfWork.CategoryRepository.FindCategoryByName(name);
            if(result == null) return NotFound($"Could not find a category named:{name}");

            if(_unitOfWork.CategoryRepository.RemoveCategory(result))
                if (await _unitOfWork.CompleteAsync())
                    return Ok("Category removed");

            return StatusCode(500, "Something went wrong with the removal");
        }


    }
}
