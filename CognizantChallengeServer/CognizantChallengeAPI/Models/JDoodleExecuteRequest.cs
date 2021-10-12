using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallengeAPI.Models
{
    public class JDoodleExecuteRequest
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Script { get; set; }
        public string Stdin { get; set; }
        public string Language { get; set; }
        public int Version { get; set; }
    }
}
