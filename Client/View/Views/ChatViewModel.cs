namespace CHAT_APP.CLIENT.VIEW;

public class ChatViewModel : ReactiveObject
{
    public ObservableCollection<ChatMessage> Messages { get; set; } = [];

    public ChatViewModel()
    {
        this.Messages.Add(new("1", "2"));
    }
}

public record ChatMessage(string Username, string Message);