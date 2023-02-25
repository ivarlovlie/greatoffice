namespace IOL.GreatOffice.Api.Utilities;

public static class DateTimeExtensions
{
    public static bool IsNullOrEmpty(this DateTime dateTime) {
        return (dateTime == default);
    }
}