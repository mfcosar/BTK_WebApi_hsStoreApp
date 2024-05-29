using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IHouseRepository> _houseRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _houseRepository    = new Lazy<IHouseRepository>(()=> new HouseRepository(_context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
        }
        public IHouseRepository HouseRepo => _houseRepository.Value;

        public ICategoryRepository CategoryRepo => _categoryRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
