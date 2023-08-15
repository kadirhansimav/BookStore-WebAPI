using BookStore.DataAccess.Abstract;
using BookStore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCategory(Category category)
        {
            Create(category);
        }

        public void DeleteOneCategory(Category category)
        {
           Delete(category);
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await FindAll(trackChanges)
                .ToListAsync();

            return categories;
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await FindByCondition(c=>c.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

            return category;
        }

        public void UpdateOneCategory(Category category)
        {
            Update(category);
        }
    }
}
