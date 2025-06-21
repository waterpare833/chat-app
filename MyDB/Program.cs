var service_port_string = args.ElementAtOrDefault(0);
if (service_port_string is null) throw new NullReferenceException("service port를 입력해주세요.");

var service_port_convert_result = ushort.TryParse(service_port_string, out var service_port);
if (!service_port_convert_result) throw new("service port의 값이 올바르지 않습니다.");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(service_port, listen_options => listen_options.Protocols = HttpProtocols.Http2);
});

builder.Services.AddMagicOnion();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    var user_sqlite_connection_path = builder.Configuration["SQLITE_USER_DB_PATH"] ?? "Data Source=/app/data/users.db";
    var user_sqlite_connection = new SqliteConnection(user_sqlite_connection_path);
    user_sqlite_connection.Open();
    
    DatabaseInitializer.Ensure_user_table_created(user_sqlite_connection);

    container.RegisterInstance(user_sqlite_connection).As<SqliteConnection>().SingleInstance();
    container.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
});

var app = builder.Build();
app.MapMagicOnionService();
app.Run();