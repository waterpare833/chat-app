namespace CHAT_APP.CLIENT.VIEW;

public class RegisterViewModel(): ReactiveObject
{
    public BindableReactiveProperty<string> Username { get; } = new("");
    public BindableReactiveProperty<string> Password { get; } = new("");
    
    public BindableReactiveProperty<string> Username_validation_message { get; } = new();
    public BindableReactiveProperty<IBrush> Username_validation_message_foreground { get; } = new();
    public BindableReactiveProperty<bool> Register_button_enable{ get; } = new(false);

    public ReactiveCommand On_checking_username_duplication { get; } = new();
    public ReactiveCommand On_registering_button_clicked { get; } = new();
    public ReactiveCommand On_back_button_clicked { get; } = new();
    
    private bool username_is_valid;

    public RegisterViewModel(
        ViewPresenter view_presenter,
        UserPresenter user_presenter): this()
    {
        this.On_checking_username_duplication
            .Subscribe(_ => user_presenter.Request_username_duplication_check.Execute(this.Username.Value));

        this.On_registering_button_clicked
            .Subscribe(_ => user_presenter.Request_user_register.Execute((this.Username.Value, this.Password.Value)));

        this.On_back_button_clicked
            .Subscribe(_ =>
            {
                reset_user_info();
                view_presenter.Main_view.Value = ViewType.LOGIN;
            });
        
        this.Username.Subscribe(_ =>
        {
            this.username_is_valid = false;
            this.Register_button_enable.Value = false;
        });
        
        this.Password.Subscribe(x =>
        {
            if (x == string.Empty || !this.username_is_valid) this.Register_button_enable.Value = false;
            else this.Register_button_enable.Value = true;
        });
        
        user_presenter.Receive_username_duplication_result.Subscribe(x =>
        {
            this.username_is_valid = !x.value;

            if (!this.username_is_valid)
            {
                this.Username_validation_message.Value = $"{x.username}은/는 이미 사용중입니다.";
                this.Username_validation_message_foreground.Value = Brushes.Red;
            } else
            {
                this.Username_validation_message.Value = $"{x.username}은/는 사용 가능합니다.";
                this.Username_validation_message_foreground.Value = Brushes.Green;
            }

            if (this.Password.Value == string.Empty || !this.username_is_valid) this.Register_button_enable.Value = false;
            else this.Register_button_enable.Value = true;
        });

        user_presenter.Receive_user_registration_done
            .Subscribe(_ =>
            {
                reset_user_info();
                view_presenter.Main_view.Value = ViewType.LOGIN;
            });
    }

    private void reset_user_info()
    {
        this.Username.Value = "";
        this.Password.Value = "";
        this.Username_validation_message.Value = "";
    }
}