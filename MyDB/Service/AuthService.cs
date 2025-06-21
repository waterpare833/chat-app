namespace MY_DB;

public class AuthService(IUserRepository user_repo): ServiceBase<IAuthService>, IAuthService
{
    public async UnaryResult<bool> Register(User user)
    {
        var hashed_password = hash_password(user.Password_hash);
        var user_to_add = user with { Password_hash = hashed_password };
        return await user_repo.Add_user(user_to_add);
    }

    public async UnaryResult<bool> Login(User user)
    {
        var existing_user = await user_repo.Get_user(user.Username);
        if (existing_user is null) return false;

        var hash = hash_password(user.Password_hash);
        return hash == existing_user.Password_hash;
    }

    public async UnaryResult<bool> Is_username_taken(string username)
    {
        var user = await user_repo.Get_user(username);
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