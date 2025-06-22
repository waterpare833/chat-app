namespace CHAT_APP.CLIENT.DB.INTERFACE;

public class StatusService : ServiceBase<IStatusService>, IStatusService
{
    public UnaryResult<bool> Is_running()
        => new(true);
}