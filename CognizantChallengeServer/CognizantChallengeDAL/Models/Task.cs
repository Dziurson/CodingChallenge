using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CognizantChallengeDAL.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExpectedResult { get; set; }
        public Guid ExternalId { get; set; }

        public virtual ICollection<Solution> Solutions { get; set; }
    }
}
