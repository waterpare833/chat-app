namespace CHAT_APP.CLIENT.MODEL;

public class ChatManager(ChatPresenter chat_presenter): IStartable
{
    public void Start()
    {
        chat_presenter.Request_user_join_in_chat_room.Subscribe(x =>
        {
            
        });
    }
}