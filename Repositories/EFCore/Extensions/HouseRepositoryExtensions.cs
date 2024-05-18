using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Repositories.EFCore;
using System.Reflection;
using System.Linq;

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

        public static IQueryable<House> Sort(this IQueryable<House> houses, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return houses.OrderBy(h => h.Id);

            var orderQuery = OrderQueryBuilder.FormQueryString<House>(orderByQueryString);

           if(orderQuery is null)
                return houses.OrderBy(h => h.Id);

           return houses.OrderBy(orderQuery);
        }
    }
 }
