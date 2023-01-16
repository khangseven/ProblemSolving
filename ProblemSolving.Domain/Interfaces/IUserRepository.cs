using ProblemSolving.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetUser(string UserName);  
        public Task<User> GetUser(Guid UserId);
        public Task<User> PostUser(User user);
        public Task UpdateUser(User user);
        public Task DeleteUser(Guid UserId);
    }
}
