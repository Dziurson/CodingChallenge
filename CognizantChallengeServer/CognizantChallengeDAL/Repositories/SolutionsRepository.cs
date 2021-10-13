using CognizantChallengeDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CognizantChallengeDAL.Repositories
{
    public interface ISolutionsRepository
    {
        Solution GetUserSolutionForTask(int userId, int taskId);
        Solution CreateSolution(User user, Task task, string solutionCode, bool success);
        Solution UpdateSolution(Solution solution);
    }

    public class SolutionsRepository : ISolutionsRepository 
    {
        private readonly CognizantChallengeContext cognizantChallengeContext;

        public SolutionsRepository(CognizantChallengeContext cognizantChallengeContext)
        {
            this.cognizantChallengeContext = cognizantChallengeContext;
        }

        public Solution GetUserSolutionForTask(int userId, int taskId)
        {
            return this.cognizantChallengeContext.Solutions.FirstOrDefault(u => u.User.ID == userId && u.Task.ID == taskId);
        }

        public Solution CreateSolution(User user, Task task, string solutionCode, bool success)
        {
            var solution = new Solution
            {
                Code = solutionCode,
                Success = success,
                Task = task,
                User = user,
            };

            this.cognizantChallengeContext.Solutions.Add(solution);
            this.cognizantChallengeContext.SaveChanges();
            return solution;
        }

        public Solution UpdateSolution(Solution solution)
        {
            this.cognizantChallengeContext.Solutions.Update(solution);
            this.cognizantChallengeContext.SaveChanges();
            return solution;
        }
    }
}
