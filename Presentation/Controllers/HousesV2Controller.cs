using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //[ApiVersion("2.0", Deprecated=true)]
    [ApiController]
    [Route("api/houses")]
    [ApiExplorerSettings(GroupName ="v2")]
    //[Route("api/{v:apiversion}/houses")]
    public class HousesV2Controller: ControllerBase
    {
        private readonly IServiceManager _servicemanager;

        public HousesV2Controller(IServiceManager servicemanager)
        {
            _servicemanager = servicemanager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHousesAsync()
        {
            var houses = await _servicemanager.HouseService.GetAllHousesAsync(false);
            var housesV2 = houses.Select(h => new
            {
                Id = h.Id,
                Price = h.Price
            });
            return Ok(housesV2);
        }
    }
}
