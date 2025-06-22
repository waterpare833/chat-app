namespace CHAT_APP.CLIENT.VIEW;

public partial class MainWindow : Window
{
    public MainWindow()
        => InitializeComponent();

    private void shutdown_application(object? sender, RoutedEventArgs e)
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) 
            desktop.Shutdown();
    }
}