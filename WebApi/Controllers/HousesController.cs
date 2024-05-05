using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try {
                //var students = _context.Houses.ToList();
                //var students = _manager.HouseRepo.GetAllHouses(false);
                var houses = _serviceManager.HouseService.GetAllHouses(false);
                return Ok(houses);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneHouse([FromRoute(Name = "id")] int id)
        {
            try {
                //var house = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
                //var house = _manager.HouseRepo.GetOneHouseById(id, false);

                var house = _serviceManager.HouseService.GetOneHouseById(id,false);

                if (house is null)
                    return NotFound();
                return Ok(house);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult FormOneHouse([FromBody] House house)
        {
            try
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
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneHouse([FromRoute(Name = "id")] int id, [FromBody] House house)
        {
            try {

                if (house is null)
                    return BadRequest(); //400

                //check new home
                //var entity = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
                //var entity = _manager.HouseRepo.GetOneHouseById(id, true);
                _serviceManager.HouseService.UpdateOneHouse(id,house,true);


                //house.Id = entity.Id; - takip ediliyor EFCore'da
                //_context.SaveChanges();
                //_manager.Save();
            return NoContent(); //204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneHouse([FromRoute(Name = "id")] int id)
        {
            try {
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneHouse([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<House> housePatch)
        {
            try {
                //check entity if exists
                //var entity = _context.Houses.Where(h => h.Id.Equals(id)).SingleOrDefault();
                //var entity = _manager.HouseRepo.GetOneHouseById(id, true);
                var entity = _serviceManager.HouseService.GetOneHouseById(id,true);
                if (entity is null)
                    return NotFound(); // 404

                housePatch.ApplyTo(entity);
                //_context.SaveChanges();
                //_manager.HouseRepo.Update(entity);
                _serviceManager.HouseService.UpdateOneHouse(id,entity,true);
                //_manager.Save();
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
