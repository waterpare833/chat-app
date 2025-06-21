namespace MY_DB;

public interface IStatusService : IService<IStatusService>
{
    UnaryResult<bool> Is_running();
}