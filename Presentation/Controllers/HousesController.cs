using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //[ApiVersion("1.0")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/houses")]
    [ApiExplorerSettings(GroupName = "v1")]
    //[Route("api/{v:apiversion}/houses")]
    //[ResponseCache(CacheProfileName = "5mins")]
    //[HttpCacheExpiration(CacheLocation= CacheLocation.Public, MaxAge =80)]
    public class HousesController : ControllerBase
    {
        //private readonly RepositoryContext _context;

        /*public HousesController(RepositoryContext context)
        {
            _context = context;
        }*/
        /*private readonly IRepositoryManager _manager;
        public HousesController(IRepositoryManager manager)
        {
            _manager = manager;
        }*/

        private readonly IServiceManager _serviceManager;
        public HousesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Authorize]
        [HttpHead]
        [HttpGet(Name = "GetAllHousesAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        //[ResponseCache(Duration = 60)]  //Expiration test için yazılmıştı
        public async Task<IActionResult> GetAllHousesAsync([FromQuery]HouseParameters houseParameters)
        {
            var linkParameters = new LinkParameters()
            {
                HouseParameters = houseParameters,
                HttpContext = HttpContext
            };
                //var students = _context.Houses.ToList();
                //var students = _manager.HouseRepo.GetAllHouses(false);
                var result = await _serviceManager.HouseService.GetAllHousesAsync(linkParameters, false);

            // sonuçlar paged old. için Response header'a MetaData bilgisi verilebilir, Front-end'de kullanılması için
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));

            return  result.linkResponse.HasLinks ? 
                    Ok(result.linkResponse.LinkedEntities) : 
                    Ok(result.linkResponse.ShapedEntities);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneHouseAsync([FromRoute(Name = "id")] int id)
        {
                //var house = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
                //var house = _manager.HouseRepo.GetOneHouseById(id, false);

                //throw new Exception("!!!!");
                var house = await _serviceManager.HouseService.GetOneHouseByIdAsync(id, false);

            /*if (house is null)
                throw new HouseNotFoundException(id);    */  
            return Ok(house);
        }

        [Authorize(Roles = "Editor, Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name = "FormOneHouseAsync")]
        public async Task<IActionResult> FormOneHouseAsync([FromBody] HouseDtoForInsertion houseDto)
        {
                /*Validation filter ile impl.edildi
                 * if (houseDto is null)
                    return BadRequest();
                if(!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);*/


                //_context.Houses.Add(house);
                //_context.SaveChanges();
                //_manager.HouseRepo.Form(house);
                //_manager.Save();
                var house = await  _serviceManager.HouseService.FormOneHouseAsync(houseDto);

                return StatusCode(201, house);
        }

        //[ServiceFilter(typeof(LogFilterAttribute), Order =2)]
        [Authorize(Roles = "Editor, Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneHouseAsync([FromRoute(Name = "id")] int id, [FromBody] HouseDtoForUpdate houseDto)
        {
                /*if (houseDto is null)
                    return BadRequest(); //400
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);*///422

                //check new home
                //var entity = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
                //var entity = _manager.HouseRepo.GetOneHouseById(id, true);
                await _serviceManager.HouseService.UpdateOneHouseAsync(id, houseDto, false);


                //house.Id = entity.Id; - takip ediliyor EFCore'da
                //_context.SaveChanges();
                //_manager.Save();
                return NoContent(); //204
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneHouseAsync([FromRoute(Name = "id")] int id)
        {
                //var entity = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
                //var entity = _manager.HouseRepo.GetOneHouseById(id, false);
                //var entity = _serviceManager.HouseService.GetOneHouseById(id,false);

                /*if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"House with id: {id} could not be found."
                    });*/

                //_context.Houses.Remove(entity);
                //_context.SaveChanges();
                //_manager.HouseRepo.DeleteOneHouse(entity);
                //_manager.Save();
                await _serviceManager.HouseService.DeleteOneHouseAsync(id, false);
                return NoContent();
        }

        [Authorize(Roles = "Editor, Admin")]
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneHouseAsync([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<HouseDtoForUpdate> housePatch)
        {

            if (housePatch is null)
                return BadRequest(); //400

            var result = await _serviceManager.HouseService.GetOneHouseForPatchAsync(id, false);
            //check entity if exists
            //var entity = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
            //var entity = _manager.HouseRepo.GetOneHouseById(id, true);
            //var houseDto = _serviceManager.HouseService.GetOneHouseById(id, true);
            /*if (entity is null)
                return NotFound(); */// 404

            housePatch.ApplyTo(result.houseDtoForUpdate, ModelState);
            TryValidateModel(result.houseDtoForUpdate);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serviceManager.HouseService.SaveChangesForPatchAsync(result.houseDtoForUpdate, result.house);
            //_context.SaveChanges();
            //_manager.HouseRepo.Update(entity);
            /*_serviceManager.HouseService.UpdateOneHouse(id, new HouseDtoForUpdate()
            {
                Id = houseDto.Id,
                Type = houseDto.Type,
                Price = houseDto.Price,
                Location = houseDto.Location
            }, true);*/

                //_manager.Save();
                return NoContent(); // 204
            }

        [Authorize]
        [HttpOptions]
        public IActionResult GetHousesOptions()
        {
            Response.Headers.Add("Allow", "GET, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");
            return Ok(); // 200
        }


        }
    }


