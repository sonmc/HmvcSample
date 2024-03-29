
namespace HmvcSample.Modules.UserModule.Dto
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public UserEntity(UserSchema userSchema)
        {
            this.Id = userSchema.Id;
            this.UserName = userSchema.UserName;
            this.FullName = userSchema.FullName;
            this.Email = userSchema.Email;
            this.Age = userSchema.Age;
        }
    }
}