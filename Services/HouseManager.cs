using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HouseManager : IHouseService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;
        private readonly IDataShaper<HouseDto> _shaper;
        public HouseManager(IRepositoryManager manager, ILoggerService loggerService, IMapper mapper, IDataShaper<HouseDto> shaper)
        {
            _manager = manager;
            _loggerService = loggerService;
            _mapper = mapper;
            _shaper = shaper;
        }

        public async Task<HouseDto> FormOneHouseAsync(HouseDtoForInsertion houseDto)
        {
            /*if (house is null) //controller da kontrol ediliyor zaten
                throw new ArgumentNullException(nameof(house));*/
            var entity = _mapper.Map<House>(houseDto);
            _manager.HouseRepo.FormOneHouse(entity);
            await _manager.SaveAsync();
            return _mapper.Map<HouseDto>(entity);
        }

        public async Task DeleteOneHouseAsync(int id, bool trackChanges)
        {
            var entity = await GetOneHouseByIdAndCheckExists(id, trackChanges);
            _manager.HouseRepo.DeleteOneHouse(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ExpandoObject> houses, MetaData metaData)> GetAllHousesAsync(HouseParameters houseParameters, bool trackChanges)
        {

            if (!houseParameters.ValidPriceRange)
                throw new PriceOutofRangeBadRequestException();

            var housesWithMetaData = await _manager.HouseRepo.GetAllHousesAsync(houseParameters, trackChanges);

            var housesDtoMapped = _mapper.Map<IEnumerable<HouseDto>>(housesWithMetaData); // houses : source, HouseDto : destination, MappingProfile'a eklenir

            var shapedData = _shaper.ShapeData(housesDtoMapped, houseParameters.Fields);

            return (houses: shapedData, metaData: housesWithMetaData.MetaData);
        }

        public async Task<HouseDto> GetOneHouseByIdAsync(int id, bool trackChanges)
        {
            var house = await GetOneHouseByIdAndCheckExists(id, trackChanges);

            /*if (house is null)
                throw new HouseNotFoundException(id);*/
            return _mapper.Map<HouseDto>(house);
        }

        public async Task UpdateOneHouseAsync(int id, HouseDtoForUpdate houseDto, bool trackChanges)
        {
            //check entity
            var entity = await GetOneHouseByIdAndCheckExists(id, trackChanges);

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
            await _manager.SaveAsync();
        }

        public async Task<(HouseDtoForUpdate houseDtoForUpdate, House house)> GetOneHouseForPatchAsync(int id, bool trackChanges)
        {
            var house = await GetOneHouseByIdAndCheckExists(id, trackChanges);
            var houseDtoForUpdate = _mapper.Map<HouseDtoForUpdate>(house);
            return (houseDtoForUpdate, house);

        }

        public async Task SaveChangesForPatchAsync(HouseDtoForUpdate houseDtoForUpdate, House house)
        {
            _mapper.Map<HouseDtoForUpdate>(house);
            await _manager.SaveAsync();
        }

        private async Task<House> GetOneHouseByIdAndCheckExists(int id, bool trackChanges)
        {
            //check entity
            var entity = await _manager.HouseRepo.GetOneHouseByIdAsync(id, trackChanges);
            if (entity is null)
            {
                throw new HouseNotFoundException(id);
            }
            return entity;
        }
    }
}
