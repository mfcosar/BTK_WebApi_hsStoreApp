using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public sealed class HouseRepository : RepositoryBase<House>, IHouseRepository
    {
        public HouseRepository(RepositoryContext context): base(context)
        {
        }

        public void DeleteOneHouse(House house) => Delete(house);

        public void FormOneHouse(House house) => Form(house);

        public async Task<PagedList<House>> GetAllHousesAsync(HouseParameters houseParameters, bool trackChanges)
        {
            /*await FindAll(trackChanges)
            .OrderBy(h => h.Id)
            .Skip((houseParameters.PageNumber-1)*houseParameters.PageSize)
            .Take(houseParameters.PageSize)
            .ToListAsync();*/
            //var houses = await FindAll(trackChanges).OrderBy(h => h.Id).ToListAsync();

            var houses = await FindAll(trackChanges)
                .FilterHouses(houseParameters.MinPrice, houseParameters.MaxPrice)
                .Search(houseParameters.SearchTerm)
                .Sort(houseParameters.OrderBy)      //.OrderBy(h => h.Id)
                .ToListAsync();
                
                //FindByCondition(b => ((b.Price >= houseParameters.MinPrice) && (b.Price <= houseParameters.MaxPrice)), trackChanges).OrderBy(h => h.Id).ToListAsync(); ;

            return PagedList<House>
                .ToPagedList(houses, houseParameters.PageNumber, houseParameters.PageSize);
        }

        public async Task<List<House>> GetAllHousesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(h => h.Id).ToListAsync();
        }

        public async Task<House> GetOneHouseByIdAsync(int id, bool trackChanges) => 
            await FindByCondition(h => h.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneHouse(House house) => Update(house);
    }
}
