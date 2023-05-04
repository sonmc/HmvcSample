
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
        public async Task<IActionResult> Login(Authenticate model)
        {
            string token = "";
            string refreshToken = "";

            User user = await authenticationService.Login(model.Account, model.Password, model.Domain);

            if (user.RoleId == null || !CheckRole(model.Domain, user))
            {
                throw new BadRequestException("EXCEPTION.PLEASE_VERIFY_YOUR_LOGIN_INFORMATION", "EXCEPTION.INVALID_LOGIN");
            }

            if (user.Status != Configs.STATUS_ACTIVE)
            {
                throw new BadRequestException("EXCEPTION.PLEASE_CONTACT_OUR_CUSTOMER_SERVICE", "EXCEPTION.ACCOUNT_LOCKED");
            }

            if (user.RoleId != (int)Configs.ROLE.PARENT && user.RoleId != (int)Configs.ROLE.SUPER_ADMIN && user.RoleId != (int)Configs.ROLE.CMS_ADMIN && user.RoleId != (int)Configs.ROLE.CONTENT_CREATOR)
            {
                bool isValid = CheckOrganizationValid(user);
                if (!isValid)
                {
                    throw new BadRequestException("EXCEPTION.PLEASE_CONTACT_OUR_CUSTOMER_SERVICE", "EXCEPTION.ACCOUNT_EXPIRED");
                }
            }

            List<TokenDeviceAuth> tokenDevices = _uow.TokenDeviceAuthRepository.GetByUserId(user.Id);
            token = Common.GenerateJwtToken(user.Id, model.Domain, appSettings.Secret);
            refreshToken = Common.GenerateRefreshToken();

            var maxDevicesAllowed = 1;
            if (user.RoleId == (int)Configs.ROLE.PARENT)
            {
                var studentCount = _uow.StudentRepository.CountStudentByParentId(user.Id);
                if (studentCount > maxDevicesAllowed)
                {
                    maxDevicesAllowed = studentCount;
                }
            }

            _logger.LogInformation(appSettings.SuperPassword);

            return Ok(new { token = token, refreshToken = refreshToken });
        }
    }
}