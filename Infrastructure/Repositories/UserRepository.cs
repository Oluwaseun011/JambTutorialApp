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
        public async Task CreateUserAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
        }

        public async Task DeleteUser(User user)
        {
           _context.Remove(user);
        }
        
        public async Task<User?> GetUser(Guid id)
        {
            foreach (var item in _context.Set<User>())
            {
                if(item.Id == id)
                {
                    return  item;
                }
            }
            return null;
        }

        public async Task UpdateUser(User user)
        {
            _context.Set<User>().Update(user);
        }
    }
}
