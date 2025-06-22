namespace CHAT_APP.REPOSITORY;

public interface IUserRepository
{
    Task<bool> Add_user(User users);
    Task<User?> Get_user(string username);
}