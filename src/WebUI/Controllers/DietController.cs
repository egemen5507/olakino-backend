using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Diet.Queries;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    public class DietController : ApiControllerBase
    {
        [HttpGet]
        [Route("category/{categoryId?}")]
        public async Task<ActionResult<List<DietDto>>> GetDiets(int? categoryId)
        {
            return await Mediator.Send(new GetDietListQuery { CategoryId = categoryId });
        }
    }
}