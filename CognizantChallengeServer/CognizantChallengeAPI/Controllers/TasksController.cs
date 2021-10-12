using CognizantChallengeAPI.Logic;
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
        private readonly ICheckSubmissionLogic checkSubmissionLogic;

        public TasksController(
            ITasksRepository tasksRepository,
            ICheckSubmissionLogic checkSubmissionLogic)
        {
            this.tasksRepository = tasksRepository;
            this.checkSubmissionLogic = checkSubmissionLogic;
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
        public async System.Threading.Tasks.Task<ActionResult> Submit(TaskSubmit taskSubmit)
        {
            await this.checkSubmissionLogic.Check(taskSubmit);
            return Ok();
        }
    }
}
