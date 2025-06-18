namespace LSH.MY_CONVERTER;

public interface IConverterService : IService<IConverterService>
{
    UnaryResult<int> Sum(int x, int y);
}