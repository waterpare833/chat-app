namespace LSH.MY_CONVERTER;

public interface IChatHub : IStreamingHub<IChatHub, IChatHubReceiver>
{
    ValueTask Join_room(string roomName, string userName);
    ValueTask Leave_room(string userName);
    ValueTask Send_message(string message);
}

public interface IChatHubReceiver
{
    void On_join(string userName);
    void On_leave(string userName);
    void on_send_message(string userName, string message);
}