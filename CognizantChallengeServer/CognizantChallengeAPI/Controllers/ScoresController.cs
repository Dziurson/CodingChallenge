using CognizantChallengeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CognizantChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Score>> GetAll()
        {
            return new List<Score>
            {
                new Score { Name = "test", SuccessSolutions = 1, Tasks = new [] { "test" } },
                new Score { Name = "test 2", SuccessSolutions = 1, Tasks = new [] { "test", "test2", "test3" } },
            };
        }
    }
}
