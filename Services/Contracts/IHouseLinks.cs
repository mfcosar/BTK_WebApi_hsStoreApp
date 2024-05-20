using Entities.DataTransferObjects;
using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Services.Contracts
{
    public interface IHouseLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<HouseDto> housesDto,
            string fields, HttpContext httpContext);
    }
}