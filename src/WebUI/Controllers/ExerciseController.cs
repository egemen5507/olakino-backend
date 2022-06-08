using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Exercise.Queries;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    public class ExerciseController : ApiControllerBase
    {
        [HttpGet]
        [Route("category/{categoryId?}")]
        public async Task<ActionResult<List<ExerciseDto>>> GetExercises(int? categoryId)
        {
            return await Mediator.Send(new GetExerciseListQuery { CategoryId = categoryId });
        }
    }
}