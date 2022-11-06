using PriceLists.Models;

namespace Catalog.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> AddCategoryAsync(Category category);
        bool UpdateCategory(Category category);
        bool RemoveCategory(Category category);
        Task<IList<Category>> ListAllCategoriesAsync();
        Task<Category> FindCategoryByIdAsync(int id);
        Task<IList<Category>> FindCategoryThatIncludesNameAsync(string name);
        Task<Category> FindCategoryByName(string name);

    }
}
