using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallengeAPI.Models
{
    public class Score
    {
        public string Name { get; set; }
        public int SuccessSolutions { get; set; }
        public string[] Tasks { get; set; }
    }
}
