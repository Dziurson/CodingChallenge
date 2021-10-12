using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallengeAPI.Models
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ExternalId { get; set; }
    }
}
