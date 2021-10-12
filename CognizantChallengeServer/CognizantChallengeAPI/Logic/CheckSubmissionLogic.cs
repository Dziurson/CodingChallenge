using CognizantChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using CognizantChallengeAPI.Clients;

namespace CognizantChallengeAPI.Logic
{
    public interface ICheckSubmissionLogic
    {
        void Check(TaskSubmit taskSubmit);
    }
    public class CheckSubmissionLogic : ICheckSubmissionLogic
    {
        private readonly IJDoodleClient jDoodleClient;

        public CheckSubmissionLogic(IJDoodleClient jDoodleClient)
        {
            this.jDoodleClient = jDoodleClient;
        }

        public void Check(TaskSubmit taskSubmit)
        {
            this.jDoodleClient.Execute();
        }
    }
}
