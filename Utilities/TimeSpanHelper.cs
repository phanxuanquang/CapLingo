namespace Utilities
{
    public static class TimeSpanHelper
    {
        public static string AsString(TimeSpan timespan, bool includeMilisecond = true)
        {
            return includeMilisecond
                ? $"{timespan.Hours:D2}:{timespan.Minutes:D2}:{timespan.Seconds:D2},{timespan.Milliseconds:D3}"
                : $"{timespan.Hours:D2}:{timespan.Minutes:D2}:{timespan.Seconds:D2}";
        }

        public static TimeSpan AsTimeSpan(string timeInString)
        {
            return TimeSpan.Parse(timeInString);
        }
    }
}
