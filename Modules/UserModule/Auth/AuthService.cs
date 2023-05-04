using System;
using HmvcSample.Infrastructure.Repositories;
using HmvcSample.Modules.UserModule.Dto;

namespace HmvcSample.Modules.UserModule
{
    public interface IAuthService
    {
        UserEntity Login(int id);
    }
    public class AuthService : IAuthService
    {
        IUserRepository userRepository;
        public AuthService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public UserEntity Login(int id)
        {
            throw new NotImplementedException();
        }
    }
}