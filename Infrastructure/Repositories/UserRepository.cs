using HmvcSample.Modules.UserModule.Dto;
namespace HmvcSample.Infrastructure.Repositories
{
    public interface IUserRepository : IGeneralRepository<UserSchema> { }
    public class UserRepository : GeneralRepository<UserSchema>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}