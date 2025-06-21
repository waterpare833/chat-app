namespace MY_DB;

public class AuthService : ServiceBase<IAuthService>, IAuthService
{
    private readonly IUserRepository user_repo;

    public AuthService(IUserRepository user_repo) => this.user_repo = user_repo;

    public async UnaryResult<bool> Register(string username, string password)
    {
        var hashed_password = hash_password(password);
        return await this.user_repo.Add_user(username, hashed_password);
    }

    public async UnaryResult<bool> Login(string username, string password)
    {
        var user = await this.user_repo.Get_user(username);
        if (user is null) return false;

        var hash = hash_password(password);
        return hash == user.Password_hash;
    }

    public async UnaryResult<bool> Is_username_taken(string username, string password)
    {
        var user = await this.user_repo.Get_user(username);
        return user != null;
    }

    private string hash_password(string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}