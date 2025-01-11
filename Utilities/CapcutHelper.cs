using Domains;
using Newtonsoft.Json;

namespace Utilities
{
    public static class CapcutHelper
    {
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
    }
}
