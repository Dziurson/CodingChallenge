using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CognizantChallengeDAL.Repositories
{
    public interface ITasksRepository
    {
        List<Models.Task> GetAll();
    }

    public class TasksRepository : ITasksRepository
    {
        private readonly CognizantChallengeContext cognizantChallengeContext;

        public TasksRepository(CognizantChallengeContext cognizantChallengeContext)
        {
            this.cognizantChallengeContext = cognizantChallengeContext;
        }

        public List<Models.Task> GetAll()
        {
            cognizantChallengeContext.SaveChanges();
            return cognizantChallengeContext.Tasks.ToList();
        }
    }
}
