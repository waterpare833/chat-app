namespace MY_DB;

public interface IUserRepository
{
    Task<bool> Add_user(string username, string password_hash);
    Task<User?> Get_user(string username);
}