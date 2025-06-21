namespace MY_DB;

public interface IAuthService : IService<IAuthService>
{
    UnaryResult<bool> Register(User user);
    UnaryResult<bool> Login(User user);
    UnaryResult<bool> Is_username_taken(string username);
}