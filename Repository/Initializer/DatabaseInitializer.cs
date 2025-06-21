namespace MY_REPOSITORY;

public static class DatabaseInitializer
{
    public static void Ensure_user_table_created(SqliteConnection connection)
    {
        var table_command = connection.CreateCommand();
        table_command.CommandText = """
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password_hash TEXT NOT NULL
                );
            """;
        table_command.ExecuteNonQuery();
    }
}