using Microsoft.EntityFrameworkCore;
using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Interfaces;
using TeamTask.Domain.Models;

namespace TeamTask.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbTeamTaskContext _context;
        public UserRepository(DbTeamTaskContext context)
        {
            _context = context;
        }
        public async Task<UserDtos?> getUserByNit(string nit)
        {
            var res = await _context.DtUsers.FirstOrDefaultAsync( u => u.Nit == nit);
            if (res == null) return null;
            return new UserDtos
            {
                nit = res.Nit,
                name = res.Name,
                user_name = res.UserName,
                email = res.Email,
                password = res.Password,
            };
        }
        public async Task<UserDtos?> getUserByEmail(string email)
        {
            var res = await _context.DtUsers.FirstOrDefaultAsync(u => u.Email == email);
            if (res == null) return null;
            return new UserDtos
            {
                nit = res.Nit,
                name = res.Name,
                user_name = res.UserName,
                email = res.Email,
                password = res.Password,
            };
        }

        public async Task<UserDtos?> registerUser(DtUser user)
        {
            _context.DtUsers.Add(new DtUser
            {
                Nit = user.Nit,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
            });

            var res = await _context.SaveChangesAsync();

            if (res <= 0) return null;
            return new UserDtos
            {
                nit = user.Nit,
                name = user.Name,
                user_name = user.UserName,
                email = user.Email,
                password = user.Password,
            };
        }
    }
}
