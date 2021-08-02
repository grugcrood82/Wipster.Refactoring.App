using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Persistence;
using Wipster.Refactoring.Application;
using Wipster.Refactoring.Application.Dtos;

namespace Wipster.Refactoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeesService EmployeesService;

        public EmployeesController(IEmployeesService employees)
        {
            EmployeesService = employees;
        }

        [HttpGet]
        // inconsistent approach to parameter passing. Stick to one method. either Query strings through out or url parameters
        public async Task<ActionResult<EmployeesListResponse>> GetAll([FromQuery] string country)
        {
            // this logic belongs inside the service. Parse the country code in and reduce the methods
            //Not all results must return Ok. Consider providing an appropriate response code based on operation success
            if (country != null)
            {
                return Ok(await EmployeesService.GetAllByCountryAsync(country));
            }
            else
            {
                return Ok(await EmployeesService.GetAllAsync());
            }
        }

        [HttpGet("{id}")]
        //why are we getting Categories in an employees controller
        public async Task<ActionResult<CategoryResponse>> GetAsync(int id)
        {
            var result = await EmployeesService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        //why are we getting Categories in an employees controller
        public async Task<ActionResult<CategoryResponse>> CreateAsync([FromBody] EmployeeRequest request)
        {
            var productId = await EmployeesService.CreateAsync(request);
            return Ok(productId);
        }

        [HttpPut("{id}")]
        //why are we getting Categories in an employees controller
        public async Task<ActionResult<CategoryResponse>> UpdateAsync(int id, [FromBody] EmployeeRequest request)
        {
            var result = await EmployeesService.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAsync(int id)
        {
            var result = await EmployeesService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
