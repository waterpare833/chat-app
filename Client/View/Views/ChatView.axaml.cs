namespace CHAT_APP.CLIENT.VIEW;

public partial class ChatView: UserControl
{
    public ChatView()
    {
        InitializeComponent();
        
        this.MessageTextbox
            .GetPropertyChangedObservable(TextBox.TextProperty)
            .Select(x => x.NewValue as string ?? string.Empty)
            .Subscribe(x => this.SendButton.IsEnabled = !string.IsNullOrEmpty(x));
    }
}