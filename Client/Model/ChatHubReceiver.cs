namespace CHAT_APP.CLIENT.MODEL;

public class ChatServiceReceiver(ChatPresenter chat_presenter) : IChatServiceReceiver
{
    public void On_join(string username)
    {
    }

    public void On_send_message(string username, string message)
        => chat_presenter.Messages.Add(new(username, message));
}