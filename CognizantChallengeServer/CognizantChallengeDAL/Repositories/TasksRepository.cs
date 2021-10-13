using CognizantChallengeDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CognizantChallengeDAL.Repositories
{
    public interface ITasksRepository
    {
        List<Task> GetAll();
        Task GetByExternalId(Guid externalId);
    }

    public class TasksRepository : ITasksRepository
    {
        private readonly CognizantChallengeContext cognizantChallengeContext;

        public TasksRepository(CognizantChallengeContext cognizantChallengeContext)
        {
            this.cognizantChallengeContext = cognizantChallengeContext;
        }

        public List<Task> GetAll()
        {
            cognizantChallengeContext.SaveChanges();
            return cognizantChallengeContext.Tasks.ToList();
        }

        public Task GetByExternalId(Guid externalId)
        {
            return cognizantChallengeContext.Tasks.FirstOrDefault(t => t.ExternalId == externalId);
        }
    }
}
