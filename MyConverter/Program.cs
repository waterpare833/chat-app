var servicePortString = args.ElementAtOrDefault(0);
if (servicePortString is null) return;

var servicePortConvertResult = ushort.TryParse(servicePortString, out var servicePort);
if (!servicePortConvertResult) return;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls($"http://localhost:{servicePort}");
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureEndpointDefaults(endpointOptions => endpointOptions.Protocols = HttpProtocols.Http2);
});

builder.Services.AddMagicOnion();


var app = builder.Build();
app.MapMagicOnionService();

app.Run();