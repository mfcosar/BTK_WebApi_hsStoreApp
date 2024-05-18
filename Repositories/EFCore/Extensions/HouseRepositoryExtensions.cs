using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Repositories.EFCore;

namespace Repositories.EFCore.Extensions
{
    public static class HouseRepositoryExtensions
    {

        public static IQueryable<House> FilterHouses(this IQueryable<House> houses,
            uint minPrice, uint maxPrice) =>
            houses.Where(house => house.Price >= minPrice && house.Price <= maxPrice);

        public static IQueryable<House> Search(this IQueryable<House> houses, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return houses;
            var lowerCaseTerm = searchTerm.Trim().ToLower();

            //bulunduğu yeri içeriyor mu
            return houses.Where(h => h.Location.ToLower().Contains(lowerCaseTerm));
        }
    }
 }
