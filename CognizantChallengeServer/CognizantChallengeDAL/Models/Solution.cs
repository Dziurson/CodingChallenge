using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CognizantChallengeDAL.Models
{
    public class Solution
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public bool Success { get; set; }         
        public Task Task { get; set; }
        public User User { get; set; }
    }
}
