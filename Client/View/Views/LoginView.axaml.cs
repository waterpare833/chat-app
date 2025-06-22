namespace CHAT_APP.CLIENT.VIEW;

public partial class LoginView: UserControl
{
    public LoginView()
    {
        InitializeComponent();

        var username_textbox_on_changed = this.UserNameTextbox.GetPropertyChangedObservable(TextBox.TextProperty);
        var password_textbox_on_changed = this.PasswordTextbox.GetPropertyChangedObservable(TextBox.TextProperty);

        username_textbox_on_changed.Merge(password_textbox_on_changed)
            .Subscribe(_ =>
            {
                if (!string.IsNullOrEmpty(this.UserNameTextbox.Text) && !string.IsNullOrEmpty(this.PasswordTextbox.Text)) this.LoginButton.IsEnabled = true;
                else this.LoginButton.IsEnabled = false;
            });

        this.UserValidationMessageTextBlock.IsVisible = false;
        this.LoginButton.IsEnabled = false;
    }
}