using Entities.Models;
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

        public IQueryable<House> GetAllHouses(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(h => h.Id);

        public House GetOneHouseById(int id, bool trackChanges) => 
            FindByCondition(h => h.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOneHouse(House house) => Update(house);
    }
}
