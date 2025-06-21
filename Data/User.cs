namespace MY_DB;

public class User
{
    public long Id { get; set; }
    public string? Username { get; set; }
    public string? Password_hash { get; set; }

    public User()
    {
    }
}