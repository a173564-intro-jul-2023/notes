using EmployeeDirectoryApi.Controllers;



namespace EmployeeDirectoryApi;



public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _systemTime;



    public StandardBusinessClock(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }



    public bool AreWeOpen()
    {
        var now = _systemTime.GetCurrrent();
        if (now.Hour >= 9 && now.Hour < 17)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}



public interface ISystemTime
{
    DateTime GetCurrrent();
}
public class SystemTime : ISystemTime
{
    public DateTime GetCurrrent() => DateTime.Now;
}
