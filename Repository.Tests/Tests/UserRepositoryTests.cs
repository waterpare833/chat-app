namespace MY_REPOSITORY.TESTS;

public class UserRepositoryTests: IDisposable
{
    private readonly SqliteConnection connection;
    private readonly UserRepository user_repository;

    public UserRepositoryTests()
    {
        // 메모리 SQLite 연결
        this.connection = new("Data Source=:memory:");
        this.connection.Open();

        // 테이블 생성
        DatabaseInitializer.Ensure_user_table_created(this.connection);

        // 리포지토리에 주입
        this.user_repository = new(this.connection);
    }

    [Fact]
    public async Task 새로운_아이디면_사용자가_추가된다()
    {
        var result = await this.user_repository.Add_user("test1", "hash123");
        result.Should().BeTrue();

        var user = await this.user_repository.Get_user("test1");
        user.Should().NotBeNull();
        user.Username.Should().Be("test1");
        user.Password_hash.Should().Be("hash123");
    }

    [Fact]
    public async Task 중복_아이디면_사용자가_추가되지_않는다()
    {
        await this.user_repository.Add_user("test1", "hash123");
        var result = await this.user_repository.Add_user("test1", "anotherhash");
        result.Should().BeFalse();
    }

    [Fact]
    public async Task 사용자를_조회할_수_있다()
    {
        await this.user_repository.Add_user("test1", "hash123");
        var existed_user = await this.user_repository.Get_user("test1");
        existed_user.Should().NotBeNull();
        existed_user.Username.Should().Be("test1");
        existed_user.Password_hash.Should().Be("hash123");
        
        var not_existed_user = await this.user_repository.Get_user("nonexistent");
        not_existed_user.Should().BeNull();
    }

    public void Dispose()
        => this.connection.Dispose();
}