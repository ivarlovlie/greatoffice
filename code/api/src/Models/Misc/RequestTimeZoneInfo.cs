namespace IOL.GreatOffice.Api.Models.Models;

public class RequestTimeZoneInfo
{
    public TimeZoneInfo TimeZoneInfo { get; set; }
    public int Offset { get; set; }
    public DateTime LocalDateTime { get; set; }
}