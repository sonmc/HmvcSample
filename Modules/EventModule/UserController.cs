using HmvcSample.Modules.UserModule.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HmvcSample.Modules.UserModule
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public readonly IUserService userService;
        public UserController(ILogger<UserController> logger, IUserService _userService)
        {
            userService = _userService;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Get(int? id)
        {
            Object result = id != null ? userService.GetOne((int)id) : userService.GetAll();
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult Create(UserEntity userEntity)
        {
            var list = userService.Create(userEntity);
            return Ok(list);
        }

    }
}