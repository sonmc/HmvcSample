using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HmvcSample.Modules.UserModule
{
    public interface IUserService
    {
        UserSchema Get(int id);
    }
    public class UserService : IUserService
    {
        public UserSchema Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}