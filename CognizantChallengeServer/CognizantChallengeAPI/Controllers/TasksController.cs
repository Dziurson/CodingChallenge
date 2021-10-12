using CognizantChallengeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CognizantChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string[]> GetAll()
        {
            return new string[] { "test", "test2" };
        }

        [HttpPost]
        public ActionResult Submit(TaskSubmit taskSubmit)
        {
            return Ok();
        }
    }
}
