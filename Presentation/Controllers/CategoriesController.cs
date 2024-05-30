using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public CategoriesController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryAsync([FromRoute(Name ="id")]int id) {

            var category = await _serviceManager.CategoryService.GetOneCategoryByIdAsync(id, false);
            return Ok(category);
        }

        [HttpPost(Name = "FormOneCategoryAsync")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> FormOneCategoryAsync([FromBody]CategoryDtoForInsertion categoryDtoForInsertion)
        {
            var entity = await _serviceManager.CategoryService.FormOneCategoryAsync(categoryDtoForInsertion);
            return StatusCode(201, entity);
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateOneCategoryAsync([FromRoute]int id, [FromBody]CategoryDtoForUpdate categoryDtoForUpdate)
        {
            await _serviceManager.CategoryService.UpdateOneCategoryAsync(id, categoryDtoForUpdate, false); //

            return NoContent(); //204
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCategoryAsync([FromRoute(Name ="id")]int id)
        {
            await _serviceManager.CategoryService.DeleteOneCategoryAsync(id, false);
            return NoContent();
        }
    }
}
