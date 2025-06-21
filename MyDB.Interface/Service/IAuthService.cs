namespace MY_DB;

public interface IAuthService : IService<IAuthService>
{
    UnaryResult<bool> Register(string username, string password);
    UnaryResult<bool> Login(string username, string password);
    UnaryResult<bool> Is_username_taken(string username, string password);
}