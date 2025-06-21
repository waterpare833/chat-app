namespace Client;

public class ViewPresenter
{
    public readonly R3.ReactiveProperty<ViewType> Main_view = new(ViewType.SPLASH);

    public readonly ReactiveCommand On_showing_error_popup = new();
}