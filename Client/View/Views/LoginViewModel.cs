namespace CHAT_APP.CLIENT.VIEW;

public class LoginViewModel(): ReactiveObject
{
    public BindableReactiveProperty<string> Username { get; } = new("");
    public BindableReactiveProperty<string> Password { get; } = new("");
    
    public BindableReactiveProperty<string> User_validation_message { get; } = new();
    public BindableReactiveProperty<IBrush> User_validation_message_foreground { get; } = new();
    public BindableReactiveProperty<bool> User_validation_message_visible { get; } = new(false);
    
    public ReactiveCommand On_register_button_clicked { get; } = new();
    public ReactiveCommand On_login_button_clicked { get; } = new();

    public LoginViewModel(
        ViewPresenter view_presenter,
        UserPresenter user_presenter): this()
    {
        this.On_register_button_clicked
            .Subscribe(_ =>
            {
                reset_user_info();
                view_presenter.Main_view.Value = ViewType.REGISTER;
            });

        this.On_login_button_clicked
            .Subscribe(_ => user_presenter.Request_user_login.Execute((this.Username.Value, this.Password.Value)));

        this.Username.Merge(this.Password)
            .Subscribe(x => this.User_validation_message_visible.Value = false);
        
        user_presenter.Receive_user_login_done
            .Subscribe(x =>
            {
                if (!x)
                {
                    this.User_validation_message.Value = "올바른 계정이 아닙니다.";
                    this.User_validation_message_foreground.Value = Brushes.Red;
                    this.User_validation_message_visible.Value = true;
                } else
                {
                    view_presenter.Main_view.Value = ViewType.REGISTER;
                }
            });
    }

    private void reset_user_info()
    {
        this.Username.Value = "";
        this.Password.Value = "";
        this.User_validation_message.Value = "";
        this.User_validation_message_visible.Value = false;
    }
}