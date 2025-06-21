using System;
using LSH.MY_CONVERTER;

namespace Client;

class ChatHubReceiver : IChatHubReceiver
{
    public void On_join(string userName)
        => Console.WriteLine($"{userName} joined.");

    public void On_leave(string userName)
        => Console.WriteLine($"{userName} left.");

    public void on_send_message(string userName, string message)
        => Console.WriteLine($"{userName}: {message}");
}