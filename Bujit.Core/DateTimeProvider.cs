namespace Bujit.Core;

public class DateTimeProvider
{
    public DateTime ShortDateTime => DateTime.UtcNow.Date;
    public DateTime LongDateTime => DateTime.UtcNow;
}