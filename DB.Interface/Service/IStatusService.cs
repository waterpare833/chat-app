namespace CHAT_APP.DB.INTERFACE;

public interface IStatusService : IService<IStatusService>
{
    UnaryResult<bool> Is_running();
}