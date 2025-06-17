var servicePortString = args.ElementAtOrDefault(0);
if (servicePortString is null) throw new NullReferenceException("service port를 입력해주세요.");

var servicePortConvertResult = ushort.TryParse(servicePortString, out var servicePort);
if (!servicePortConvertResult) throw new Exception("service port의 값이 올바르지 않습니다.");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(servicePort, listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
});

builder.Services.AddMagicOnion();

var app = builder.Build();
app.MapMagicOnionService();

app.Run();