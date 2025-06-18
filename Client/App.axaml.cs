using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Client.ViewModels;
using Client.Views;
using Grpc.Net.Client;
using LSH.MY_CONVERTER;
using MagicOnion.Client;

namespace Client;

public class App : Application
{
    public static IChatHub? ChatHub;
    
    public override void Initialize()
        => AvaloniaXamlLoader.Load(this);

    public override async void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop) return;
        
        desktop.MainWindow = new MainWindow(dataContext: new MainWindowViewModel());
        
        var channel = GrpcChannel.ForAddress("http://localhost:5058");
        var receiver = new ChatHubReceiver();
        ChatHub = await StreamingHubClient.ConnectAsync<IChatHub, IChatHubReceiver>(channel, receiver);

        await ChatHub.JoinAsync("room", "client");
    }
}