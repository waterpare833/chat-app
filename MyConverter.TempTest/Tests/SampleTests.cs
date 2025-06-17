namespace LSH.MY_CONVERTER.TESTS;

public class SampleTests
{
    [Fact]
    public async void Test()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:5058");
        var client = MagicOnionClient.Create<IConverterService>(channel);

        var result = await client.Sum(1, 2);

        result.Should().Be(3);
    }
}