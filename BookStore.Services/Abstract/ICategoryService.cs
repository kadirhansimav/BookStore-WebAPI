using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task<Category> CreateOneCategoryAsync(Category category);
        Task UpdateOneCategoryAsync(int id, Category category, bool trackChanges);
        Task DeleteOneCategoryAsync(int id, bool trackChanges);
        Task<List<Category>> GetAllCategoriesAsync(bool trackChanges);
    }
}
