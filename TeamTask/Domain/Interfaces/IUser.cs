using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Models;

namespace TeamTask.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDtos> getUserByNit(string nit);
        public Task<UserDtos> getUserByEmail(string email);
        public Task<UserDtos> registerUser(DtUser user);
    }
}
