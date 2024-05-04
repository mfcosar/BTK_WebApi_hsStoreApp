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
        private readonly Lazy<IHouseRepository> houseRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            houseRepository = new Lazy<IHouseRepository>(()=> new HouseRepository(_context));
        }
        public IHouseRepository HouseRepo => houseRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
