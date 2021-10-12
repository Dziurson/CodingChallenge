using CognizantChallengeDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CognizantChallengeDAL.Repositories
{
    public interface IScoresRepository
    {
        List<Score> GetTop(int top);
    }

    public class ScoresRepository : IScoresRepository
    {
        private readonly CognizantChallengeContext cognizantChallengeContext;

        public ScoresRepository(CognizantChallengeContext cognizantChallengeContext)
        {
            this.cognizantChallengeContext = cognizantChallengeContext;
        }

        public List<Score> GetTop(int top)
        {

            var usersWithBestScore = this.cognizantChallengeContext.Users
                .Join(this.cognizantChallengeContext.Solutions, u => u.ID, s => s.User.ID, (user, solution) => new { user, solution })
                .Where(j => j.solution.Success == true)
                .GroupBy(g => g.user.ID)
                .Select(g => new { UserId = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count).Take(top);


            var result = this.cognizantChallengeContext.Users.Include(u => u.Solutions).ThenInclude(s => s.Task).Where(u => usersWithBestScore.Select(u => u.UserId).Contains(u.ID)).ToList();
            return result.Select(user => new Score { User = user, SuccessfulSubmissions = user.Solutions.Count, Tasks = user.Solutions.Select(s => s.Task.Name).ToArray() }).ToList();
        }
    }
}
