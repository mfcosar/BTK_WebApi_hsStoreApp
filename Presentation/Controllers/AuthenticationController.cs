using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var result = await _serviceManager.AuthenticationService.RegisterUser(userForRegistrationDto);
            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                    ModelState.TryAddModelError(err.Code, err.Description);
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }


        [HttpPost("Login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody]UserForAuthenticationDto userForAuthenticationDto)
        {
            if (!await _serviceManager.AuthenticationService.ValidateUser(userForAuthenticationDto))
            {
                return Unauthorized(); //401
            }

            var tokenDto = await _serviceManager.AuthenticationService.FormToken(true);
            return Ok(tokenDto); //test için Postman'ı güncellemek gerek
        }

        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody]TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _serviceManager.AuthenticationService.RefreshToken(tokenDto);

            return Ok(tokenDtoToReturn);
        }

    }
}
