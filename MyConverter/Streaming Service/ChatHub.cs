namespace LSH.MY_CONVERTER;

public class ChatHub : StreamingHubBase<IChatHub, IChatHubReceiver>, IChatHub
{
    private IGroup<IChatHubReceiver>? _room;
    private string _userName = "unknown";

    public async ValueTask JoinAsync(string roomName, string userName)
    {
        _room = await Group.AddAsync(roomName);
        _userName = userName;
        _room.All.OnJoin(userName);
    }

    public async ValueTask LeaveAsync(string userName)
    {
        if (_room is null) return;

        _room.All.OnLeave(userName);
        await _room.RemoveAsync(Context);
    }

    public ValueTask SendMessageAsync(string message)
    {
        _room?.All.OnSendMessage(_userName, message);
        
        return ValueTask.CompletedTask;
    }
}