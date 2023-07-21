namespace Banking.Domain;

public class SystemTime : ISystemTime
{
    public DateTime GetCurrent() { return DateTime.Now; }
}