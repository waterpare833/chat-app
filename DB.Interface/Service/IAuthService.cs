using CHAT_APP.DATA;

namespace CHAT_APP.DB.INTERFACE;

public interface IAuthService : IService<IAuthService>
{
    UnaryResult<bool> Register(User user);
    UnaryResult<bool> Login(User user);
    UnaryResult<bool> Is_username_taken(string username);
}