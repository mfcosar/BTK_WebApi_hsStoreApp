using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IHouseRepository: IRepositoryBase<House>
    {
        IQueryable<House> GetAllHouses(bool trackChanges);
        IQueryable<House> GetOneHouseById(int id, bool trackChanges);
        void FormOneHouse(House house);
        void UpdateOneHouse(House house);
        void DeleteOneHouse(House house);


    }
}
