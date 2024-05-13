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
        Task<IEnumerable<HouseDto>> GetAllHousesAsync(bool trackChanges);
        Task<HouseDto> GetOneHouseByIdAsync(int id, bool trackChanges);
        Task<HouseDto> FormOneHouseAsync(HouseDtoForInsertion house);
        Task UpdateOneHouseAsync(int id, HouseDtoForUpdate houseDto, bool trackChanges);
        Task DeleteOneHouseAsync(int id, bool trackChanges);
        Task<(HouseDtoForUpdate houseDtoForUpdate, House house)> GetOneHouseForPatchAsync(int id, bool trackChanges);

        Task SaveChangesForPatchAsync(HouseDtoForUpdate houseDtoForUpdate, House house);



    }
}
