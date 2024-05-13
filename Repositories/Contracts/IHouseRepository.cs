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
        Task<IEnumerable<House>> GetAllHousesAsync(bool trackChanges);
        Task<House> GetOneHouseByIdAsync(int id, bool trackChanges);
        void FormOneHouse(House house);
        void UpdateOneHouse(House house);
        void DeleteOneHouse(House house);


    }
}
