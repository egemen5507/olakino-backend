using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.DietCategory.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    public class DietCategoryController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<DietCategoryDto>>> GetDietCategories()
        {
            return await Mediator.Send(new GetDietCategoryListQuery());
        }
    }
}