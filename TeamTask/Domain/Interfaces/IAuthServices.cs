using TeamTask.Aplication.DTOs;

namespace TeamTask.Domain.Interfaces
{
    public interface IAuthServices
    {
        public Task<AuthUserResponse> Auth(AuthUserRequest data);
    }
}
