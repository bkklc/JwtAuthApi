
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IUserRepository 
    {
        Task<User> AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
