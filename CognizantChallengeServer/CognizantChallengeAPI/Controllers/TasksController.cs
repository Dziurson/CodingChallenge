using CognizantChallengeAPI.Models;
using CognizantChallengeDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CognizantChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository tasksRepository;

        public TasksController(ITasksRepository tasksRepository)
        {
            this.tasksRepository = tasksRepository;
        }

        [HttpGet]
        public ActionResult<string[]> GetAll()
        {
            return this.tasksRepository.GetAll().Select(task => task.Name).ToArray();
        }

        [HttpPost]
        public ActionResult Submit(TaskSubmit taskSubmit)
        {
            return Ok();
        }
    }
}
