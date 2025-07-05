using DataAccess.Abstracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class UserRepository : IUserRepository
    {
        private readonly JwtAuthApiContext _jwtAuthApi;
        public UserRepository(JwtAuthApiContext context)  
        {
            _jwtAuthApi = context;
        }

        public async Task<User> AddAsync(User user)
        {
            _jwtAuthApi.Add(user);
            await _jwtAuthApi.SaveChangesAsync();
            return user;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _jwtAuthApi.User.AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _jwtAuthApi.User                
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
