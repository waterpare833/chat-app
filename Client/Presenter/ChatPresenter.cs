namespace CHAT_APP.CLIENT;

public class ChatPresenter
{
    public ObservableList<ChatMessage> Messages { get; } = [];
    public ReactiveCommand<string> Request_user_join_in_chat_room { get; } = new();
    public ReactiveCommand<string> Request_message_send { get; } = new();
}