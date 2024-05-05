using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HouseManager : IHouseService
    {
        private readonly IRepositoryManager _manager;

        public HouseManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public House FormOneHouse(House house)
        {
            if (house is null)
                throw new ArgumentNullException(nameof(house));

            _manager.HouseRepo.FormOneHouse(house);
            _manager.Save();
            return house;
        }

        public void DeleteOneHouse(int id, bool trackChanges)
        {
            //check entity
            var entity = _manager.HouseRepo.GetOneHouseById(id, trackChanges);
            if (entity is null)
                throw new Exception($"House with id : {id} could not be found");

            _manager.HouseRepo.DeleteOneHouse(entity);
            _manager.Save();
        }

        public IEnumerable<House> GetAllHouses(bool trackChanges)
        {
            return _manager.HouseRepo.GetAllHouses(trackChanges);
        }

        public House GetOneHouseById(int id, bool trackChanges)
        {
            return _manager.HouseRepo.GetOneHouseById(id, trackChanges);
        }

        public void UpdateOneHouse(int id, House house, bool trackChanges)
        {
            //check entity
            var entity = _manager.HouseRepo.GetOneHouseById(id, trackChanges);
            if (entity is null)
                throw new Exception($"House with id : {id} could not be found");

            //check params
            if (house is null)
                throw new ArgumentNullException(nameof(house));

            entity.Type = house.Type;
            entity.Price = house.Price;
            entity.Location = house.Location;

            //_manager.HouseRepo.UpdateOneHouse(entity);
            _manager.HouseRepo.Update(entity); // hocanın impl.
            _manager.Save();
        }
    }
}
