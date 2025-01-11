using Domains;
using Translator.Models;

namespace Translator
{
    public class VideoAnalyst
    {
        private VideoAnalysis _videoAnalysis;

        public async Task AnalyzeVideo(string videoFilePath, sbyte maxTotalChapters)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Subtitle>> TranslateVideo()
        {
            if (_videoAnalysis == null)
            {
                throw new InvalidOperationException("Video has not been analyzed yet.");
            }

            var translationTasks = _videoAnalysis.Chapters.Select(TranslateChapter);
            var results = await Task.WhenAll(translationTasks);

            return results
                .SelectMany(subtitle => subtitle)
                .OrderBy(subtitle => subtitle.StartTime)
                .ToList();
        }

        private async Task<List<Subtitle>> TranslateChapter(Chapter chapter)
        {
            throw new NotImplementedException();
        }
    }
}
