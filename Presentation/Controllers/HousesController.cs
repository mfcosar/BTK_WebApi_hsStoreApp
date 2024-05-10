using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/houses")]
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

        [HttpGet]
        public IActionResult GetAllHouses()
        {
                //var students = _context.Houses.ToList();
                //var students = _manager.HouseRepo.GetAllHouses(false);
                var houses = _serviceManager.HouseService.GetAllHouses(false);
                return Ok(houses);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneHouse([FromRoute(Name = "id")] int id)
        {
                //var house = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
                //var house = _manager.HouseRepo.GetOneHouseById(id, false);

                //throw new Exception("!!!!");
                var house = _serviceManager.HouseService.GetOneHouseById(id, false);

            /*if (house is null)
                throw new HouseNotFoundException(id);    */  
            return Ok(house);
        }

        [HttpPost]
        public IActionResult FormOneHouse([FromBody] House house)
        {
                if (house is null)
                    return BadRequest();

                //_context.Houses.Add(house);
                //_context.SaveChanges();
                //_manager.HouseRepo.Form(house);
                //_manager.Save();
                _serviceManager.HouseService.FormOneHouse(house);

                return StatusCode(201, house);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneHouse([FromRoute(Name = "id")] int id, [FromBody] HouseDtoForUpdate houseDto)
        {
                if (houseDto is null)
                    return BadRequest(); //400

                //check new home
                //var entity = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
                //var entity = _manager.HouseRepo.GetOneHouseById(id, true);
                _serviceManager.HouseService.UpdateOneHouse(id, houseDto, true);


                //house.Id = entity.Id; - takip ediliyor EFCore'da
                //_context.SaveChanges();
                //_manager.Save();
                return NoContent(); //204
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneHouse([FromRoute(Name = "id")] int id)
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
                _serviceManager.HouseService.DeleteOneHouse(id, false);
                return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneHouse([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<House> housePatch)
        {
                //check entity if exists
                //var entity = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
                //var entity = _manager.HouseRepo.GetOneHouseById(id, true);
                var entity = _serviceManager.HouseService.GetOneHouseById(id, true);
                /*if (entity is null)
                    return NotFound(); */// 404

                housePatch.ApplyTo(entity);
                //_context.SaveChanges();
                //_manager.HouseRepo.Update(entity);
                _serviceManager.HouseService.UpdateOneHouse(id, new HouseDtoForUpdate(entity.Id, entity.Type, entity.Price, entity.Location), true);
                //_manager.Save();
                return NoContent(); // 204
            }
        }
    }


