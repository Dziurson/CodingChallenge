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
        public ActionResult<Task[]> GetAll()
        {
            return this.tasksRepository.GetAll().Select(task => new Task 
            { 
                Name = task.Name, 
                Description = task.Description, 
                ExternalId = task.ExternalId 
            }).ToArray();
        }

        [HttpPost]
        public ActionResult Submit(TaskSubmit taskSubmit)
        {
            return Ok();
        }
    }
}
