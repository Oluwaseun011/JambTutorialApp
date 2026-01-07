using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
         Task CreateUserAsync(User user);

          Task DeleteUser(User user);

          Task<User?> GetUser(Guid id);

          Task UpdateUser(User user;
    }
}
