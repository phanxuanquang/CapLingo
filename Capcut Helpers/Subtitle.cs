using System.Text;

namespace Capcut_Helpers
{
    public class Subtitle
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public required string Text { get; set; }

        private static string TimeSpanAsString(TimeSpan timespan)
        {
            return $"{timespan.Hours:D2}:{timespan.Minutes:D2}:{timespan.Seconds:D2},{timespan.Milliseconds:D3}";
        }

        public static string AsSrt(List<Subtitle> subtitles)
        {
            var srt = new StringBuilder(subtitles.Count * 100);

            for (int i = 0; i < subtitles.Count; i++)
            {
                srt.Append(i + 1).AppendLine()
                   .Append(TimeSpanAsString(subtitles[i].StartTime))
                   .Append(" --> ")
                   .Append(TimeSpanAsString(subtitles[i].EndTime))
                   .AppendLine()
                   .AppendLine(subtitles[i].Text)
                   .AppendLine();
            }

            return srt.ToString();
        }
    }
}
