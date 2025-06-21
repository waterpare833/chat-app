namespace Client.ViewModels;

public class MainWindowViewModel()
{
    public BindableReactiveProperty<ReactiveObject> View { get; } = new();
    public BindableReactiveProperty<bool> Is_popup_showing { get; } = new(false);
}