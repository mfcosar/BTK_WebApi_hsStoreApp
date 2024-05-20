using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Services.Contracts;
using System.ComponentModel.Design;

namespace Services
{
    public class HouseLinks : IHouseLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<HouseDto> _dataShaper;

        public HouseLinks(LinkGenerator linkGenerator,
            IDataShaper<HouseDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }

        public LinkResponse TryGenerateLinks(IEnumerable<HouseDto> housesDto,
            string fields,
            HttpContext httpContext)
        {
            var shapedHouses = ShapeData(housesDto, fields);
            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkedHouses(housesDto, fields, httpContext, shapedHouses);
            return ReturnShapedHouses(shapedHouses);
        }

        private LinkResponse ReturnLinkedHouses(IEnumerable<HouseDto> housesDto,
            string fields,
            HttpContext httpContext,
            List<Entity> shapedHouses)
        {
            var houseDtoList = housesDto.ToList();

            for (int index = 0; index < houseDtoList.Count(); index++)
            {
                var houseLinks = CreateForHouse(httpContext, houseDtoList[index], fields);
                shapedHouses[index].Add("Links", houseLinks);
            }

            var houseCollection = new LinkCollectionWrapper<Entity>(shapedHouses);
            CreateForHouses(httpContext, houseCollection);
            return new LinkResponse { HasLinks = true, LinkedEntities = houseCollection };
        }

        private LinkCollectionWrapper<Entity> CreateForHouses(HttpContext httpContext,
            LinkCollectionWrapper<Entity> houseCollectionWrapper)
        {
            houseCollectionWrapper.Links.Add(new Link()
            {
                Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                Rel = "self",
                Method = "GET"
            });
            return houseCollectionWrapper;
        }

        private List<Link> CreateForHouse(HttpContext httpContext,
            HouseDto houseDto,
            string fields)
        {
            var links = new List<Link>()
            {
               new Link()
               {
                   Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}" +
                   $"/{houseDto.Id}",
                   Rel = "self",
                   Method = "GET"
               },
               new Link()
               {
                   Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                   Rel="create",
                   Method = "POST"
               },
            };
            return links;
        }

        private LinkResponse ReturnShapedHouses(List<Entity> shapedHouses)
        {
            return new LinkResponse() { ShapedEntities = shapedHouses };
        }

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
            return mediaType
                .SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        private List<Entity> ShapeData(IEnumerable<HouseDto> housesDto, string fields)
        {
            return _dataShaper
                .ShapeData(housesDto, fields)
                .Select(b => b.Entity)
                .ToList();
        }


    }
}