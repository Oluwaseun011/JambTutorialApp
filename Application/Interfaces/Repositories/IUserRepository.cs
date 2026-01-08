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
          Task AddAsync(User user);
          Task<User?> GetUserAsync(string username);
          void UpdateUser(User user);
          void DeleteUser(User user);
          Task<bool> IsExist(string userName);
    }
}
