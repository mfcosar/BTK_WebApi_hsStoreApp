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
        //IEnumerable<House> GetAllHouses(bool trackChanges);
        IEnumerable<HouseDto> GetAllHouses(bool trackChanges);
        HouseDto GetOneHouseById(int id, bool trackChanges);
        HouseDto FormOneHouse(HouseDtoForInsertion house);
        void UpdateOneHouse(int id, HouseDtoForUpdate houseDto, bool trackChanges);
        void DeleteOneHouse(int id, bool trackChanges);
        (HouseDtoForUpdate houseDtoForUpdate, House house) GetOneHouseForPatch(int id, bool trackChanges);

        void SaveChangesForPatch(HouseDtoForUpdate houseDtoForUpdate, House house);



    }
}
