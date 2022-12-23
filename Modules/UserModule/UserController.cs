
using HmvcSample.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HmvcSample.Modules.UserModule
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public readonly IGenericRepository<UserSchema> _repository;
        public UserController(ILogger<UserController> logger, IGenericRepository<UserSchema> repository)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}