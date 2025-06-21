using System.Reactive.Linq;

namespace Client.Views;

public partial class RegisterView: UserControl
{
    public RegisterView()
    {
        InitializeComponent();

        this.UserNameTextbox
            .GetPropertyChangedObservable(TextBox.TextProperty)
            .Select(x => x.NewValue as string ?? string.Empty)
            .Subscribe(x =>
            {
                this.DuplicationCheckUsernameButton.IsEnabled = !string.IsNullOrEmpty(x);
                this.UsernameValidationMessageTextBlock.IsVisible = false;
            });

        this.UsernameValidationMessageTextBlock
            .GetPropertyChangedObservable(TextBox.TextProperty)
            .Select(x => x.NewValue as string ?? string.Empty)
            .Where(x => !string.IsNullOrEmpty(x))
            .Subscribe(_ => this.UsernameValidationMessageTextBlock.IsVisible = true);

        this.DuplicationCheckUsernameButton.IsEnabled = false;
        this.RegisterButton.IsEnabled = false;
        this.UsernameValidationMessageTextBlock.IsVisible = false;
    }
}