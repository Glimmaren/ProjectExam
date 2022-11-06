using System.Runtime.CompilerServices;
using Catalog.Interfaces;
using Microsoft.EntityFrameworkCore;
using PriceLists.Data;
using PriceLists.Models;

namespace Catalog.Repositorys
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogContext _context;
        public CategoryRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Category> FindCategoryByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> FindCategoryByName(string name)
        {
            var result = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name.Trim().ToLower() == name.Trim().ToLower());

            return result;
        }

        public async Task<IList<Category>> FindCategoryThatIncludesNameAsync(string name)
        {
            var result = await _context.Categories
                .Where(c => c.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();

            return result;
        }

        public async Task<IList<Category>> ListAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public bool RemoveCategory(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _context.Categories.Update(category);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
