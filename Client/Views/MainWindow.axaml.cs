using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Client.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public MainWindow(object? dataContext) : this()
    {
        DataContext = dataContext;
    }

    private async void Test(object? sender, RoutedEventArgs e)
    {
        await App.ChatHub!.SendMessageAsync("Hello, world!");
    }
}