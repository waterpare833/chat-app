namespace CHAT_APP.CLIENT.MODEL;

public class SampleManager(
    ViewPresenter view_presenter,
    UserPresenter user_presenter
): IStartable
{
    public async void Start()
    {
        var db_channel = GrpcChannel.ForAddress("http://localhost:7028");
        var db_status_service = MagicOnionClient.Create<DB.INTERFACE.IStatusService>(db_channel);

        try
        {
            _ = await db_status_service.Is_running();
            view_presenter.Main_view.Value = ViewType.LOGIN;
        } catch (Exception)
        {
            view_presenter.On_showing_error_popup.Execute(Unit.Default);
        }

        var user_db_service =  MagicOnionClient.Create<DB.INTERFACE.IAuthService>(db_channel);
        user_presenter.Request_username_duplication_check.Subscribe(async x =>
        {
            var result = await user_db_service.Is_username_taken(x);
            user_presenter.Receive_username_duplication_result.Execute((x, result));
        });

        user_presenter.Request_user_register.Subscribe(async x =>
        {
            var user = new DATA.User(x.username, x.password);
            _ = await user_db_service.Register(user);
            user_presenter.Receive_user_registration_done.Execute(Unit.Default);
        });
    }
}