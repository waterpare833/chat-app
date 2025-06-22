using System.Collections.ObjectModel;

namespace CHAT_APP.CLIENT.VIEW;

public class ChatViewModel(): ReactiveObject
{
    public ObservableCollection<ChatMessage> Messages { get; set; } = [];
    public BindableReactiveProperty<string> Message { get; } = new("");

    public ReactiveCommand On_message_send_button_clicked { get; } = new();

    public ChatViewModel(ChatPresenter chat_presenter): this()
    {
        this.On_message_send_button_clicked
            .Subscribe(_ =>
            {
                chat_presenter.Request_message_send.Execute(this.Message.Value);
                this.Message.Value = "";
            });

        chat_presenter.Messages.ObserveAdd()
            .Subscribe(x => this.Messages.Add(x.Value));
    }
}