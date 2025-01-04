using System.Text;

namespace Capcut_Helpers
{
    public class Subtitle
    {
        public required string Content { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public static string AsSrt(List<Subtitle> subtitles, bool applyMinimizeContent = true)
        {
            var srt = new StringBuilder(subtitles.Count * 100);

            if (applyMinimizeContent)
            {
                subtitles = Ulti.MinimizeContent(subtitles);
            }

            for (int i = 0; i < subtitles.Count; i++)
            {
                srt.Append(i + 1).AppendLine()
                   .Append(Ulti.AsString(subtitles[i].StartTime))
                   .Append(" --> ")
                   .Append(Ulti.AsString(subtitles[i].EndTime))
                   .AppendLine()
                   .AppendLine(subtitles[i].Content)
                   .AppendLine();
            }

            return srt.ToString();
        }
    }
}
