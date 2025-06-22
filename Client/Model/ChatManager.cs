namespace CHAT_APP.CLIENT.MODEL;

public class ChatManager(
    ViewPresenter view_presenter,
    ChatPresenter chat_presenter,
    ChatServiceReceiver chat_service_receiver
): IStartable, IDisposable
{
    private IChatService? chat_service;
    
    public async void Start()
    {
        var chat_service_channel = GrpcChannel.ForAddress("http://localhost:5058");

        try
        {
            this.chat_service = await StreamingHubClient.ConnectAsync<IChatService, IChatServiceReceiver>(chat_service_channel, chat_service_receiver);
        } catch (Exception)
        {
            view_presenter.On_showing_error_popup.Execute(Unit.Default);
        }

        chat_presenter.Request_user_join_in_chat_room
            .Subscribe(async x => await this.chat_service!.Join_room("room1", x));

        chat_presenter.Request_message_send
            .Subscribe(async x => await this.chat_service!.Send_message(x));
    }

    public void Dispose()
        => this.chat_service?.DisposeAsync();
}