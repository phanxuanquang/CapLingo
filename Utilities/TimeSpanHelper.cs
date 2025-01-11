namespace Utilities
{
    public static class TimeSpanHelper
    {
        public static string AsString(TimeSpan timespan)
        {
            return $"{timespan.Hours:D2}:{timespan.Minutes:D2}:{timespan.Seconds:D2},{timespan.Milliseconds:D3}";
        }
        public static TimeSpan AsTimeSpan(string timeInString)
        {
            return TimeSpan.Parse(timeInString);
        }
    }
}
