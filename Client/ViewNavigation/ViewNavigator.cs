namespace Client;

public class ViewNavigator(
    MainWindowViewModel main,
    SplashScreenViewModel splash_screen,
    LoginViewModel login,
    RegisterViewModel register,
    ViewPresenter view_presenter
) : IStartable
{
    public void Start()
    {
        view_presenter.Main_view.Subscribe(x =>
        {
            main.View.Value = x switch
            {
                ViewType.SPLASH => splash_screen,
                ViewType.LOGIN => login,
                ViewType.REGISTER => register,
                _ => login
            };
        });

        view_presenter.On_showing_error_popup.Subscribe(_ => main.Is_popup_showing.Value = true);

    }
}