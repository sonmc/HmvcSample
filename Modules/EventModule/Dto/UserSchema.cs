
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HmvcSample.Modules.UserModule.Dto
{
    public class UserSchema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }

        public UserSchema(UserEntity entity)
        {
            this.Id = entity.Id;
            this.UserName = entity.UserName;
            this.FullName = entity.FullName;
            this.Email = entity.Email;
            this.Age = entity.Age;
        }
    }
}