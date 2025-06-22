using LSH.MY_CONVERTER;

namespace CHAT_APP.CLIENT;

class ChatHubReceiver : IChatHubReceiver
{
    public void On_join(string user_name)
        => Console.WriteLine($"{user_name} joined.");

    public void On_leave(string user_name)
        => Console.WriteLine($"{user_name} left.");

    public void On_send_message(string user_name, string message)
        => Console.WriteLine($"{user_name}: {message}");
}