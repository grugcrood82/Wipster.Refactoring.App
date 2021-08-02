using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Persistence;
using Wipster.Refactoring.Application;
using Wipster.Refactoring.Application.Dtos;
using Newtonsoft.Json;

namespace Wipster.Refactoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // In the event of a failure, the response must provide actionable intel to the caller. This is a bit enigmatic and will be problematic for consumers who do not have context
        private ICategoriesService _categoryService;

        public CategoriesController(ICategoriesService categories)
        {
            _categoryService = categories;
        }
        //Not all results must return Ok. Consider providing an appropriate response code based on operation success

        [HttpGet]
        public async Task<ActionResult<CategoriesListResponse>> GetAll()
        {
            //consider responding with 404 when the ID has no match
            //What if there is an error. Okay does not cover it
            var result = await _categoryService.GetAll();
            return Ok(result);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> Get(int id)
        {
            //consider responding with 404 when the ID has no match
            var result = await _categoryService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> Create([FromBody] CategoryRequest request)
        {
            var result = await _categoryService.Create(request);
            
            //What if there is an error. Okay does not cover it
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryResponse>> Update(int id, [FromBody] CategoryRequest request)
        {
            var result = await _categoryService.Update(id, request);
            
            //What if there is an error. Okay does not cover it
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await _categoryService.Delete(id);
            
            //What if there is an error. Okay does not cover it
            return Ok(result);
        }
    }
}
