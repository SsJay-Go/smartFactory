
using Interface;

namespace Service
{
    public class UserService : IUserService
    {
        public string GetName()
        {
            return "Hello .NET 8";
        }

    }
}
