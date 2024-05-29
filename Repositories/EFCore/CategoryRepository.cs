using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(c=> c.CategoryId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void FormOneCategory(Category category) => Form(category);
        public void UpdateOneCategory(Category category) => Update(category);
        public void DeleteOneCategory(Category category) => Delete(category);
    }
}
