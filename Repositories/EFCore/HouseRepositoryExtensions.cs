using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public static class HouseRepositoryExtensions
    {

        public static IQueryable<House> FilterHouses(this IQueryable<House> houses,
            uint minPrice, uint maxPrice) =>
            houses.Where(house => (house.Price >= minPrice) && (house.Price <= maxPrice));

    
    }
}
