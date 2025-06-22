namespace CHAT_APP.CLIENT;

public class UserPresenter
{
    public ReactiveCommand<string> Request_username_duplication_check { get; } = new();
    public ReactiveCommand<(string username, bool value)> Receive_username_duplication_result { get; } = new();
    public ReactiveCommand<(string username, string password)> Request_user_register { get; } = new();
    public ReactiveCommand Receive_user_registration_done { get; } = new();

}