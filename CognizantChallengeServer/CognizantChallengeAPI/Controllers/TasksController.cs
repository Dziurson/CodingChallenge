using CognizantChallengeAPI.Logic;
using CognizantChallengeAPI.Models;
using CognizantChallengeDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult<Models.Task[]> GetAll()
        {
            return this.tasksRepository.GetAll().Select(task => new Models.Task
            { 
                Name = task.Name, 
                Description = task.Description, 
                ExternalId = task.ExternalId 
            }).ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<TaskSubmitResult>> Submit(TaskSubmit taskSubmit)
        {
            var result = await this.checkSubmissionLogic.Check(taskSubmit);
            return result;
        }
    }
}
