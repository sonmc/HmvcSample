
using Microsoft.AspNetCore.Mvc;

namespace HmvcSample.Modules.UserModule
{
    [Route("auth")]
    public class AuthController : Controller
    {
        public readonly IAuthService service;
        public AuthController(IAuthService _service)
        {
            service = _service;
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            // var res = service.Login();
            return Ok();
        }
    }
}