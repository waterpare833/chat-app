using Avalonia.Controls.ApplicationLifetimes;

namespace Client.Views;

public partial class MainWindow : Window
{
    public MainWindow()
        => InitializeComponent();

    private void shutdown_application(object? sender, RoutedEventArgs e)
    {
        if (Avalonia.Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) 
            desktop.Shutdown();
    }
}