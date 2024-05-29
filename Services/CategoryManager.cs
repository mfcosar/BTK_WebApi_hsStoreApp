using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CategoryManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _repositoryManager.CategoryRepo.GetAllCategoriesAsync(trackChanges);
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            return await _repositoryManager.CategoryRepo.GetOneCategoryByIdAsync(id, trackChanges);
        }


        public async Task<CategoryDto> FormOneCategoryAsync(CategoryDtoForInsertion categoryDto)
        {
            var newCategory = _mapper.Map<Category>(categoryDto); // convert to sorce to destination

            _repositoryManager.CategoryRepo.FormOneCategory(newCategory);

            await _repositoryManager.SaveAsync();
            return _mapper.Map<CategoryDto>(newCategory);
        }


        public async Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDto, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAndCheckExists(id, trackChanges);
                
                entity = _mapper.Map<Category>(categoryDto);

             _repositoryManager.CategoryRepo.UpdateOneCategory(entity);
            await _repositoryManager.SaveAsync();
        }


        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAndCheckExists(id, trackChanges);

            _repositoryManager.CategoryRepo.DeleteOneCategory(entity);
            await _repositoryManager.SaveAsync();

        }

        private async Task<Category> GetOneCategoryByIdAndCheckExists(int id, bool trackChanges)
        {
            //check entity
            var entity = await _repositoryManager.CategoryRepo.GetOneCategoryByIdAsync(id, trackChanges);

            if (entity is null)
            {
                throw new CategoryNotFoundException(id);
            }
            return entity;
        }
    }
}
