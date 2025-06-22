namespace CHAT_APP.CLIENT.VIEW;

public class LoginViewModel() : ReactiveObject
{
    public ReactiveCommand On_register_button_clicked { get; } = new();

    public LoginViewModel(ViewPresenter view_presenter): this()
    {
        this.On_register_button_clicked.Subscribe(_ => view_presenter.Main_view.Value = ViewType.REGISTER);
    }
}