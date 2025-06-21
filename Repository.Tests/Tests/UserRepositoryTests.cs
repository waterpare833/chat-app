using MY_REPOSITORY;

namespace Repository.Tests;

public class UserRepositoryTests: IDisposable
{
    private readonly SqliteConnection connection;
    private readonly IUserRepository user_repository;

    public UserRepositoryTests()
    {
        // 메모리 SQLite 연결
        this.connection = new("Data Source=:memory:");
        this.connection.Open();

        // 테이블 생성
        DatabaseInitializer.Ensure_user_table_created(this.connection);

        // 리포지토리에 주입
        this.user_repository = new UserRepository(this.connection);
    }

    [Fact]
    public async Task 사용자추가_성공_새로운아이디일때()
    {
        var result = await this.user_repository.Add_user("test1", "hash123");
        result.Should().BeTrue();

        var user = await this.user_repository.Get_user("test1");
        user.Should().NotBeNull();
        user!.Username.Should().Be("test1");
        user.Password_hash.Should().Be("hash123");
    }

    [Fact]
    public async Task 사용자추가_실패_중복아이디일때()
    {
        await this.user_repository.Add_user("test1", "hash123");
        var result = await this.user_repository.Add_user("test1", "anotherhash");
        result.Should().BeFalse();
    }

    [Fact]
    public async Task 사용자조회_결_과null_사용자없을때()
    {
        var user = await this.user_repository.Get_user("nonexistent");
        user.Should().BeNull();
    }

    public void Dispose()
        => this.connection.Dispose();
}