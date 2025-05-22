using TeamTask.Aplication.DTOs;

namespace TeamTask.Domain.Interfaces
{
    public interface IUserServices
    {
        public Task<UserResponse> GetUserByNit(string nit);
        public Task<UserResponse> GetUserByEmail(string email);
        public Task<UserResponse> Register(UserDtos data);
    }
}
