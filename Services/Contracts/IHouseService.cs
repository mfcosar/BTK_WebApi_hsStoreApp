using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IHouseService
    {
        IEnumerable<House> GetAllHouses(bool trackChanges);
        House GetOneHouseById(int id, bool trackChanges);
        House FormOneHouse(House house);
        void UpdateOneHouse(int id, HouseDtoForUpdate houseDto, bool trackChanges);
        void DeleteOneHouse(int id, bool trackChanges);



    }
}
