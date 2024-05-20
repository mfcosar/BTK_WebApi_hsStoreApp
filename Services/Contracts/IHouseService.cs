using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IHouseService
    {
        //IEnumerable<House> GetAllHouses(bool trackChanges);
        Task<(LinkResponse linkResponse, MetaData metaData)> GetAllHousesAsync(LinkParameters linkParameters, bool trackChanges);
        Task<HouseDto> GetOneHouseByIdAsync(int id, bool trackChanges);
        Task<HouseDto> FormOneHouseAsync(HouseDtoForInsertion house);
        Task UpdateOneHouseAsync(int id, HouseDtoForUpdate houseDto, bool trackChanges);
        Task DeleteOneHouseAsync(int id, bool trackChanges);
        Task<(HouseDtoForUpdate houseDtoForUpdate, House house)> GetOneHouseForPatchAsync(int id, bool trackChanges);

        Task SaveChangesForPatchAsync(HouseDtoForUpdate houseDtoForUpdate, House house);



    }
}
