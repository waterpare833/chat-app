namespace MY_DB;

public class UserRepository(SqliteConnection connection): IUserRepository
{
    public async Task<bool> Add_user(User user)
    {
        try
        {
            var sql = "INSERT INTO Users (Id, Username, Password_hash) VALUES (@Id, @Username, @Password_hash)";

            var rows = await connection.ExecuteAsync(sql, new 
            { 
                Id = user.Id.ToString(),
                user.Username, 
                user.Password_hash 
            });

            return rows == 1;
        }
        catch
        {
            return false;
        }
    }

    public async Task<User?> Get_user(string username)
    {
        var sql = "SELECT Id, Username, Password_hash FROM Users WHERE Username = @Username";
        var result = await connection.QueryFirstOrDefaultAsync<(string Id, string Username, string Password_hash)>(sql, new { Username = username });

        return result == default ? null : new User(Guid.Parse(result.Id), result.Username, result.Password_hash);
    }
}