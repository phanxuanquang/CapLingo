using Domains;
using System.Text;

namespace Utilities
{
    public static class SubtittleHelper
    {
        private static string TimeSpanAsString(TimeSpan timespan)
        {
            return $"{timespan.Hours:D2}:{timespan.Minutes:D2}:{timespan.Seconds:D2},{timespan.Milliseconds:D3}";
        }

        public static List<Subtitle> MinimizeDialogues(List<Subtitle> subtitles)
        {
            if (subtitles == null || subtitles.Count == 0)
            {
                return [];
            }

            var mergedSubtitles = new List<Subtitle>();
            var current = subtitles[0];

            for (int i = 1; i < subtitles.Count; i++)
            {
                var content = subtitles[i].Text.ToLower();
                if (string.IsNullOrEmpty(content) || content.Length == 1 || content.All(c => c == content[0]))
                {
                    subtitles[i].Text = string.Empty;
                }

                var next = subtitles[i];

                if (next.StartTime.Subtract(current.EndTime).TotalMilliseconds < 30.0D)
                {
                    current.Text = $"{current.Text}\n{next.Text}".Trim();
                    current.EndTime = next.EndTime;
                }
                else
                {
                    mergedSubtitles.Add(current);
                    current = next;
                }
            }

            mergedSubtitles.Add(current);

            return mergedSubtitles
                .Where(s => !string.IsNullOrEmpty(s.Text))
                .OrderBy(s => s.StartTime)
                .ToList();
        }

        public static async Task ExportAsync(List<Subtitle> subtitles, string filePath)
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

            await FileHelper.WriteFileAsync(filePath, srt.ToString());
        }
    }
}
