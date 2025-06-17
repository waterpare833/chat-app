namespace LSH.MY_CONVERTER;

public class ConverterService : ServiceBase<IConverterService>, IConverterService
{
    public UnaryResult<int> Sum(int x, int y) => UnaryResult.FromResult(x + y);
}