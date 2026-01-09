using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User?> GetUserAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(a => a.UserName == username);
        }

            public async Task<bool> IsExist(string userName)
        {
            return await _context.Set<User>().AnyAsync(a => a.UserName == userName);
        }

        public void UpdateUser(User user)
        {
            _context.Set<User>().Update(user);
        }
    }
}
