using BookStore.DataAccess.Abstract;
using BookStore.Entities.Models;
using BookStore.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Concrete
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepositoryManager _manager;

        public CategoryService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<Category> CreateOneCategoryAsync(Category category)
        {
           if(category is null) throw new ArgumentNullException(nameof(category));
           _manager.Category.Create(category);
            await _manager.SaveAsync();
            return category;
        }

        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var entity = await GetByIdAndCheck(id, trackChanges);
            _manager.Category.Delete(entity);
            await _manager.SaveAsync();
           
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _manager.Category.GetAllCategoriesAsync(trackChanges); 
            return categories;
        }

        public Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var entity = GetByIdAndCheck(id, trackChanges);
            return entity;
        }

        public async Task UpdateOneCategoryAsync(int id, Category category, bool trackChanges)
        {
            var entity = GetByIdAndCheck(id, trackChanges);
            if (!id.Equals(category.Id))
            {
                throw new ArgumentException("category ıd ve girilen id aynı değil.");
            }
            _manager.Category.Update(category);
            await _manager.SaveAsync();
        }
        public async Task<Category> GetByIdAndCheck(int id, bool trackChanges)
        {
            var entity = await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);

            if (entity is null)
                throw new ArgumentNullException(nameof(id));

            return entity;
        }
    }
}
