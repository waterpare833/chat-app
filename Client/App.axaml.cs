using Avalonia.Markup.Xaml;
using CHAT_APP.CLIENT.MODEL;
using CHAT_APP.CLIENT.VIEW;
using LSH.MY_CONVERTER;

namespace CHAT_APP.CLIENT;

public class App : Application
{
    public static IChatHub? Chat_hub;
    
    public override void Initialize()
        => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (this.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop) return;
        
        var builder = new ContainerBuilder();
        
        builder.RegisterType<DbManager>().As<IStartable>().SingleInstance();
        builder.RegisterType<ChatManager>().As<IStartable>().SingleInstance();


        // Presenter 등록
        builder.RegisterType<UserPresenter>().SingleInstance();
        builder.RegisterType<ViewPresenter>().SingleInstance();
        builder.RegisterType<ChatPresenter>().SingleInstance();
        
        // ViewModel 등록        
        builder.RegisterType<SplashScreenViewModel>().SingleInstance();
        builder.RegisterType<LoginViewModel>().SingleInstance();
        builder.RegisterType<RegisterViewModel>().SingleInstance();
        builder.RegisterType<ChatViewModel>().SingleInstance();
        builder.RegisterType<MainWindowViewModel>().SingleInstance();

        builder.RegisterType<ViewNavigator>().As<IStartable>().SingleInstance();
        
        var container = builder.Build();
        desktop.MainWindow = new MainWindow { DataContext = container.Resolve<MainWindowViewModel>() };

        // var channel = GrpcChannel.ForAddress("http://localhost:5058");
        // var receiver = new ChatHubReceiver();
        // Chat_hub = await StreamingHubClient.ConnectAsync<IChatHub, IChatHubReceiver>(channel, receiver);
        //
        // await Chat_hub.Join_room("room", "client");
    }
}