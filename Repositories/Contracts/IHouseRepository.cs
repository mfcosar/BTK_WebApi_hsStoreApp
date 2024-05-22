using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IHouseRepository: IRepositoryBase<House>
    {
        Task<PagedList<House>> GetAllHousesAsync(HouseParameters houseParameters, bool trackChanges);
        
        Task<List<House>> GetAllHousesAsync(bool trackChanges);
        Task<House> GetOneHouseByIdAsync(int id, bool trackChanges);
        void FormOneHouse(House house);
        void UpdateOneHouse(House house);
        void DeleteOneHouse(House house);
       
    }
}
