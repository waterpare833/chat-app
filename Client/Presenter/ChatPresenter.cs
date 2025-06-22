namespace CHAT_APP.CLIENT;

public class ChatPresenter
{
    public ReactiveCommand<string> Request_user_join_in_chat_room { get; } = new();
}