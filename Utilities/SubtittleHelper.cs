using Domains;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilities
{
    public static class SubtittleHelper
    {
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
                   .Append(TimeSpanHelper.AsString(subtitles[i].StartTime))
                   .Append(" --> ")
                   .Append(TimeSpanHelper.AsString(subtitles[i].EndTime))
                   .AppendLine()
                   .AppendLine(subtitles[i].Text)
                   .AppendLine();
            }

            await FileHelper.WriteFileAsync(filePath, srt.ToString());
        }

        public static async Task<List<Subtitle>> ExtractSrtAsync(string srtFilePath)
        {
            var srtContent = await FileHelper.ReadFileAsync(srtFilePath);

            if (string.IsNullOrEmpty(srtContent.Trim()))
            {
                throw new InvalidOperationException("Subtitle file is empty.");
            }

            var subtitles = new List<Subtitle>();

            var regex = new Regex(@"(?<Index>\d+)\r?\n(?<Time>\d{2}:\d{2}:\d{2},\d{3}) --> (?<EndTime>\d{2}:\d{2}:\d{2},\d{3})\r?\n(?<Text>.*?)\r?\n\r?\n", RegexOptions.Singleline);

            foreach (Match match in regex.Matches(srtContent))
            {
                var startTime = TimeSpan.ParseExact(match.Groups["Time"].Value, @"hh\:mm\:ss\,fff", CultureInfo.InvariantCulture);
                var endTime = TimeSpan.ParseExact(match.Groups["EndTime"].Value, @"hh\:mm\:ss\,fff", CultureInfo.InvariantCulture);
                var text = match.Groups["Text"].Value.Replace("\r\n", " ").Replace("\n", " ").Trim();

                subtitles.Add(new Subtitle
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    Text = text
                });
            }

            return subtitles
                .OrderBy(s => s.StartTime)
                .ToList();
        }

        public static async Task<List<Subtitle>> ExtractCapcutSubtittleAsync(string draftContentFilePath)
        {
            var content = await FileHelper.ReadFileAsync(draftContentFilePath);
            var draftContent = JsonConvert.DeserializeObject<DraftContent>(content);

            var textTrack = (draftContent?.Tracks.FirstOrDefault(t => t.Type.Equals("text", StringComparison.OrdinalIgnoreCase))) ?? throw new InvalidOperationException("Subtitle track not found");

            return draftContent.Materials.Texts
                .Select((text, i) => new Subtitle
                {
                    Text = string.Concat(text.Words.Text).Trim(),
                    StartTime = TimeSpan.FromTicks(textTrack.Segments[i].TargetTimerange.Start * 10),
                    EndTime = TimeSpan.FromTicks((textTrack.Segments[i].TargetTimerange.Start + textTrack.Segments[i].TargetTimerange.Duration) * 10)
                })
                .OrderBy(s => s.StartTime)
                .ToList();
        }
    }
}
