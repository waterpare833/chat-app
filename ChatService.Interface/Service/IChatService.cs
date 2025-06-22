namespace CHAT_APP.CHAT.INTERFACE;

public interface IChatService : IStreamingHub<IChatService, IChatServiceReceiver>
{
    ValueTask Join_room(string room_name, string user_name);
    ValueTask Send_message(string message);
}

public interface IChatServiceReceiver
{
    void On_join(string username);
    void On_send_message(string username, string message);
}