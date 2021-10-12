using CognizantChallengeAPI.Models;
using CognizantChallengeDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CognizantChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IScoresRepository scoresRepository;

        public ScoresController(IScoresRepository scoresRepository)
        {
            this.scoresRepository = scoresRepository;
        }

        [HttpGet]
        public ActionResult<List<Score>> GetTop(int top)
        {
            return scoresRepository.GetTop(top).Select(s => new Score { Name = s.User.Name, SuccessSolutions = s.SuccessfulSubmissions, Tasks = s.Tasks}).ToList();
        }
    }
}
