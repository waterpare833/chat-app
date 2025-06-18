using System;
using LSH.MY_CONVERTER;

namespace Client;

class ChatHubReceiver : IChatHubReceiver
{
    public void OnJoin(string userName)
        => Console.WriteLine($"{userName} joined.");

    public void OnLeave(string userName)
        => Console.WriteLine($"{userName} left.");

    public void OnSendMessage(string userName, string message)
        => Console.WriteLine($"{userName}: {message}");
}