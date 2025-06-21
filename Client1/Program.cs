
using LSH.MY_CONVERTER;
using LSH.MY_CONVERTER.CLIENT1;

var channel = GrpcChannel.ForAddress("http://localhost:5058");
var receiver = new ChatHubReceiver();
var chatHubService = await StreamingHubClient.ConnectAsync<IChatHub, IChatHubReceiver>(channel, receiver);

await chatHubService.Join_room("room", "client1");

Console.WriteLine("아무 키나 입력하면 종료됩니다.");
Console.ReadLine();