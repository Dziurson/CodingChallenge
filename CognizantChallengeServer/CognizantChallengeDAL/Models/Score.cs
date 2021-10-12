using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CognizantChallengeDAL.Models
{
    public class Score
    {
        public User User { get; set; }
        public int SuccessfulSubmissions { get; set; }
        public string[] Tasks { get; set; }
    }
}
