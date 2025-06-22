namespace  CHAT_APP.CHAT;

public class ChatServiceService : StreamingHubBase<IChatService, IChatServiceReceiver>, IChatService
{
    private IGroup<IChatServiceReceiver>? room;
    private string name = "username";

    public async ValueTask Join_room(string room_name, string username)
    {
        this.room = await this.Group.AddAsync(room_name);
        this.name = username;
        this.room.All.On_join(username);
    }

    public ValueTask Send_message(string message)
    {
        this.room?.All.On_send_message(this.name, message);
        
        return ValueTask.CompletedTask;
    }
}