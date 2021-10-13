using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallengeAPI.Models
{
    public class TaskSubmitResult
    {
        public int StatusCode { get; set; }
        public string Output { get; set; }
        public string Errors { get; set; }
        public bool Success { get; set; }
    }
}
