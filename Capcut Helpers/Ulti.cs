using Newtonsoft.Json;

namespace Capcut_Helpers
{
    public static class Ulti
    {
        public static List<Subtitle> MinimizeContent(List<Subtitle> subtitles)
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

                if (next.StartTime.Subtract(current.EndTime).TotalMilliseconds < 100.0D)
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

        public static async Task<List<Subtitle>> GetSubtittleAsync(string draftContentFilePath)
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

        public static async Task ExportSubtittleAsync(List<Subtitle> subtitles, string outputFilePath)
        {
            var srt = Subtitle.AsSrt(subtitles);
            await FileHelper.WriteFileAsync(outputFilePath, srt);
        }
    }
}
