using System.ComponentModel.DataAnnotations;

namespace HmvcSample.Modules.UserModule.Dto
{
    public class Authenticate
    {
        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
