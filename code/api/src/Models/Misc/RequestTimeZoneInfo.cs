namespace IOL.GreatOffice.Api.Data.Models;

public class RequestTimeZoneInfo
{
    public TimeZoneInfo TimeZoneInfo { get; set; }
    public int Offset { get; set; }
    public DateTime LocalDateTime { get; set; }
}