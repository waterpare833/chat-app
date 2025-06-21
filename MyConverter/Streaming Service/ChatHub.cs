namespace LSH.MY_CONVERTER;

public class ChatHub : StreamingHubBase<IChatHub, IChatHubReceiver>, IChatHub
{
    private IGroup<IChatHubReceiver>? _room;
    private string _userName = "unknown";

    public async ValueTask Join_room(string roomName, string userName)
    {
        _room = await Group.AddAsync(roomName);
        _userName = userName;
        _room.All.On_join(userName);
    }

    public async ValueTask Leave_room(string userName)
    {
        if (_room is null) return;

        _room.All.On_leave(userName);
        await _room.RemoveAsync(Context);
    }

    public ValueTask Send_message(string message)
    {
        _room?.All.on_send_message(_userName, message);
        
        return ValueTask.CompletedTask;
    }
}