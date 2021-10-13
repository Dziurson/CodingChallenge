using CognizantChallengeDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CognizantChallengeDAL.Repositories
{
    public interface IUsersRepository
    {
        User GetByName(string name);
        User CreateUser(string name);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly CognizantChallengeContext cognizantChallengeContext;

        public UsersRepository(CognizantChallengeContext cognizantChallengeContext)
        {
            this.cognizantChallengeContext = cognizantChallengeContext;
        }

        public User GetByName(string name)
        {
            return this.cognizantChallengeContext.Users.FirstOrDefault(u => u.Name == name);
        }

        public User CreateUser(string name)
        {
            var user = new User { Name = name };

            this.cognizantChallengeContext.Users.Add(user);
            this.cognizantChallengeContext.SaveChanges();

            return user;
        }
    }
}
