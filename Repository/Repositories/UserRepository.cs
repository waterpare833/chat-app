namespace MY_DB;

public class UserRepository : IUserRepository
{
    private readonly SqliteConnection connection;

    public UserRepository(SqliteConnection connection)
        => this.connection = connection;

    public async Task<bool> Add_user(string username, string password_hash)
    {
        try
        {
            var sql = "INSERT INTO Users (Username, Password_hash) VALUES (@Username, @Password_hash)";
            var rows = await this.connection.ExecuteAsync(sql, new { Username = username, Password_hash = password_hash });
            return rows == 1;
        }
        catch
        {
            return false;
        }
    }

    public async Task<User?> Get_user(string username)
    {
        var sql = "SELECT * FROM Users WHERE Username = @Username";
        return await this.connection.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });
    }
}