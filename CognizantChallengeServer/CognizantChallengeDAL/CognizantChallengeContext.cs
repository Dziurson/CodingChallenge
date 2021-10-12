using CognizantChallengeDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CognizantChallengeDAL
{
    public class CognizantChallengeContext : DbContext
    {
        public CognizantChallengeContext(DbContextOptions<CognizantChallengeContext> options) : base(options)
        {
        }

        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
