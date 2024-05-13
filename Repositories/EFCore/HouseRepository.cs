using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class HouseRepository : RepositoryBase<House>, IHouseRepository
    {
        public HouseRepository(RepositoryContext context): base(context)
        {
        }

        public void DeleteOneHouse(House house) => Delete(house);

        public void FormOneHouse(House house) => Form(house);

        public async Task<IEnumerable<House>> GetAllHousesAsync(bool trackChanges) => 
            await FindAll(trackChanges).OrderBy(h => h.Id).ToListAsync();

        public async Task<House> GetOneHouseByIdAsync(int id, bool trackChanges) => 
            await FindByCondition(h => h.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneHouse(House house) => Update(house);
    }
}
