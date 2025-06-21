namespace MY_DB;

public class StatusService : ServiceBase<IStatusService>, IStatusService
{
    public UnaryResult<bool> Is_running()
        => new(true);
}