using Microsoft.EntityFrameworkCore;
using ProblemSolving.Data.Context;
using ProblemSolving.Domain.Entities;
using ProblemSolving.Domain.Interfaces;
using ProblemSolving.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        public readonly ProblemSolvingContext _context;

        public UserRepository(ProblemSolvingContext context)
        {
            _context = context;
        }

        public async Task DeleteUser(Guid UserId)
        {
            var user = await GetUser(UserId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(Guid UserId)
        {
            return await _context.Users.FindAsync(UserId);
        }

        public async Task<User> GetUser(string username)
        {
            return await (from user 
                          in _context.Users
                          where user.UserName.Equals(UserName.Create(username))
                          select user)
                          .FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


    }
}
