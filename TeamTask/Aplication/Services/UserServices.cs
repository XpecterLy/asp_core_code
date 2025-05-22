using System.Text.RegularExpressions;
using ShopApi.Exceptions;
using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Interfaces;
using TeamTask.Domain.Models;
using TeamTask.Utils;

namespace TeamTask.Aplication.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> GetUserByNit(string nit)
        {
            var strinRegex = @"^\d{6,10}$";

            if (!Regex.IsMatch(nit, strinRegex)) throw new BadRequestException("Nit is not valid");

            var res = await _userRepository.getUserByNit(nit);
            if (res == null) throw new NotFoundException("User nit is not found");

            return new UserResponse
            {
                nit = res.nit,
                name = res.name,
                email = res.email,
                user_name = res.user_name,
            };
        }

        public async Task<UserResponse> GetUserByEmail(string email)
        {
            var res = await _userRepository.getUserByEmail(email);
            if (res == null) throw new NotFoundException("User email is not found");

            return new UserResponse
            {
                nit = res.nit,
                name = res.name,
                email = res.email,
                user_name = res.user_name,
            };
        }

        public async Task<UserResponse> Register(UserDtos data)
        {
            if (await _userRepository.getUserByNit(data.nit) != null) throw new ConflictException("Error user nit is already exist");
            if (await _userRepository.getUserByEmail(data.email) != null) throw new ConflictException("Error user email is already exist");

            var res = await _userRepository.registerUser(new DtUser
            {
                Nit = data.nit,
                Name = data.name,
                Email  = data.email,
                Password = PasswordUtil.GenerateHashPassword(data.password),
                UserName = data.user_name,
            });

            if (res == null) throw new Exception("Error to create user");

            return new UserResponse
            {
                nit = data.nit,
                name = data.name,
                email = data.email,
                user_name = data.user_name,
            };
        }
    }
}
