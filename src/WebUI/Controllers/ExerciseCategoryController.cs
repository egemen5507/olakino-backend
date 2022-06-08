using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.ExerciseCategory.Queries;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    public class ExerciseCategoryController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ExerciseCategoryDto>>> GetExerciseCategories()
        {
            return await Mediator.Send(new GetExerciseCategoryListQuery());
        }
    }
}