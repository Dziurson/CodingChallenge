using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallengeAPI.Models
{
    public class TaskSubmit
    {
        public string Name { get; set; }
        public Guid TaskExternalId { get; set; }
        public string Solution { get; set; }
    }
}
