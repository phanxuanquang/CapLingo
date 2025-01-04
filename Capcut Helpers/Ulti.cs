using Newtonsoft.Json;

namespace Capcut_Helpers
{
    public static class Ulti
    {
        public static string AsString(TimeSpan timespan)
        {
            return $"{timespan.Hours:D2}:{timespan.Minutes:D2}:{timespan.Seconds:D2},{timespan.Milliseconds:D3}";
        }

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
                var content = subtitles[i].Content.ToLower().Trim();
                if (string.IsNullOrEmpty(content) || content.Length == 1 || content.AsParallel().All(c => c == content[0]))
                {
                    subtitles[i].Content = string.Empty;
                }

                var next = subtitles[i];

                if (current.EndTime == next.StartTime)
                {
                    current.Content = $"{current.Content}\n{next.Content}".Trim();
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
                .Where(s => !string.IsNullOrEmpty(s.Content))
                .OrderBy(s => s.StartTime)
                .ToList();
        }

        public static async Task<List<Subtitle>> GetSubtittle(string draftContentFilePath)
        {
            var content = await FileHelper.ReadFileAsync(draftContentFilePath);
            var draftContent = JsonConvert.DeserializeObject<DraftContent>(content);

            var subtitles = new List<Subtitle>();

            var textTrack = (draftContent?.Tracks.AsParallel().FirstOrDefault(t => t.Type.Equals("text", StringComparison.OrdinalIgnoreCase))) ?? throw new InvalidOperationException("Subtitle track not found");
            var segments = textTrack.Segments;

            for (int i = 0; i < draftContent.Materials.Texts.Count; i++)
            {
                var text = string.Concat(draftContent.Materials.Texts[i].Words.Text);

                var startTime = TimeSpan.FromTicks(segments[i].TargetTimerange.Start * 10);
                var endTime = TimeSpan.FromTicks((segments[i].TargetTimerange.Start + segments[i].TargetTimerange.Duration) * 10);

                subtitles.Add(new Subtitle
                {
                    Content = text.Trim(),
                    StartTime = startTime,
                    EndTime = endTime
                });
            }

            return subtitles;
        }
    }
}
