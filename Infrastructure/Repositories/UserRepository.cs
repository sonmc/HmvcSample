
using HmvcSample.Modules.UserModule;
using HmvcSample.Infrastructure.Repositories.Interfaces;

namespace HmvcSample.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserSchema>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}