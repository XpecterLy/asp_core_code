using Microsoft.Extensions.Options;
using ShopApi.Exceptions;
using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Config;
using TeamTask.Domain.Interfaces;
using TeamTask.Utils;

namespace TeamTask.Aplication.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthServices> _logger;
        private readonly MyAppSettings _settings;
  
        public AuthServices(IUserRepository userRepository, ILogger<AuthServices> logger, IOptions<MyAppSettings> settings)
        {
            _userRepository = userRepository;
            _logger = logger;
            _settings = settings.Value;
        }
        public async Task<AuthUserResponse> Auth(AuthUserRequest data)
        {
            var res = await _userRepository.getUserByEmail(data.gmail);
            if (res == null) throw new UnauthorizedException("Credentials is not correct");

            if (!PasswordUtil.CompareHashPassword(data.password, res.password)) throw new UnauthorizedException("Credentials is not correct");
            
            _logger.LogInformation("{time} - User {@data.gmail} auth successfully", DateTime.Now, data.gmail);

            return new AuthUserResponse{
                token = JWTUtil.GenerateJwtToken(res.user_name, res.nit, res.name, _settings.option.token_security)
            };
        }
    }
}
