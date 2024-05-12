using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
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
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;

        public HouseManager(IRepositoryManager manager, ILoggerService loggerService, IMapper mapper)
        {
            _manager = manager;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public HouseDto FormOneHouse(HouseDtoForInsertion houseDto)
        {
            /*if (house is null) //controller da kontrol ediliyor zaten
                throw new ArgumentNullException(nameof(house));*/
            var entity = _mapper.Map<House>(houseDto);
            _manager.HouseRepo.FormOneHouse(entity);
            _manager.Save();
            return _mapper.Map<HouseDto>(entity);
        }

        public void DeleteOneHouse(int id, bool trackChanges)
        {
            //check entity
            var entity = _manager.HouseRepo.GetOneHouseById(id, trackChanges);
            if (entity is null) {
                /*string message = $"House with id : {id} could not be found";
                _loggerService.LogInfo(message);
                throw new Exception(message);*/
                throw new HouseNotFoundException(id);
            }
            _manager.HouseRepo.DeleteOneHouse(entity);
            _manager.Save();
        }

        public IEnumerable<HouseDto> GetAllHouses(bool trackChanges)
        {
            var houses = _manager.HouseRepo.GetAllHouses(trackChanges);

            return _mapper.Map<IEnumerable<HouseDto>>(houses); // houses : source, HouseDto : destination, MappingProfile'a eklenir
        }

        public HouseDto GetOneHouseById(int id, bool trackChanges)
        {
            var house = _manager.HouseRepo.GetOneHouseById(id, trackChanges);

            if (house is null)
                throw new HouseNotFoundException(id);
            return _mapper.Map<HouseDto>(house);
        }

        public void UpdateOneHouse(int id, HouseDtoForUpdate houseDto, bool trackChanges)
        {
            //check entity
            var entity = _manager.HouseRepo.GetOneHouseById(id, trackChanges);
            if (entity is null) {
                /*string message = $"House with id : {id} could not be found";
                _loggerService.LogInfo(message);
                throw new Exception(message);*/
                throw new HouseNotFoundException(id);
            }

            //check params: controllerda yapıldı, no need
            /*if (houseDto is null)
                throw new ArgumentNullException(nameof(houseDto));*/

            //mapping
            entity = _mapper.Map<House>(houseDto);
            /*entity.Type = house.Type;
            entity.Price = house.Price;
            entity.Location = house.Location;*/

            //_manager.HouseRepo.UpdateOneHouse(entity);
            //if (trackChanges is false) 
            _manager.HouseRepo.Update(entity); // hocanın impl.
            _manager.Save();
        }

        public (HouseDtoForUpdate houseDtoForUpdate, House house) GetOneHouseForPatch(int id, bool trackChanges)
        {
            var house = _manager.HouseRepo.GetOneHouseById(id, trackChanges);

            if (house is null)
                throw new HouseNotFoundException(id);

            var houseDtoForUpdate = _mapper.Map<HouseDtoForUpdate>(house);
            return (houseDtoForUpdate, house);

        }

        public void SaveChangesForPatch(HouseDtoForUpdate houseDtoForUpdate, House house)
        {
            _mapper.Map<HouseDtoForUpdate>(house);
            _manager.Save();
        }
    }
}
