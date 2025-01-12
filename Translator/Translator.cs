using Domains;
using GenAI;
using Newtonsoft.Json;
using System.Text;
using Translator.Models;
using Utilities;

namespace Translator
{
    public static class Translator
    {
        private static string _translationGuidelineInstruction;
        private static string _videoAnalysisInstruction;
        private static string _videoTranslatingInstruction;

        private static string _videoUri;
        private static string _videoMimeType;
        private static string _targetLanguage;

        public static string TranslationGuideline;
        public static string VideoAnalysis;

        public static async Task Prepare(string videoUri, string mimeType, string targetLanguage)
        {
            var tasks = new[]
            {
                FileHelper.ReadFileAsync("Instructions/TranslationGuidelineInstruction.md"),
                FileHelper.ReadFileAsync("Instructions/VideoAnalysisInstruction.md"),
                FileHelper.ReadFileAsync("Instructions/VideoTranslatingInstruction.md")
            };

            var results = await Task.WhenAll(tasks);

            _translationGuidelineInstruction = results[0];
            _videoAnalysisInstruction = results[1];
            _videoTranslatingInstruction = results[2];

            _videoUri = videoUri;
            _videoMimeType = mimeType;
            _targetLanguage = targetLanguage;
        }

        public static async Task<VideoAnalysis> AnalyzeVideo()
        {
            var prompt = "Analyze the provided video and generate a structured JSON output strictly conforming to the structure in the instruction. The output must be clear, complete, and optimized for subsequent processing by another LLM for video translation. Follow the detailed requirements provided in the system instructions.";

            var result = await Gemini.GenerateContentFromVideo(_videoAnalysisInstruction, prompt, _videoUri, _videoMimeType, CreativityLevel.Medium);

            var videoAnalysis = JsonConvert.DeserializeObject<VideoAnalysis>(result);

            var analysisBuilder = new StringBuilder();
            analysisBuilder.AppendLine("## **Video Language:**");
            analysisBuilder.AppendLine($"- {videoAnalysis.AudioLanguage}");
            analysisBuilder.AppendLine();
            analysisBuilder.AppendLine("## **Target Language:**");
            analysisBuilder.AppendLine($"- {_targetLanguage}");
            analysisBuilder.AppendLine();
            analysisBuilder.AppendLine("---");
            analysisBuilder.AppendLine();
            analysisBuilder.AppendLine("# **Video Analysis**");
            analysisBuilder.AppendLine();
            analysisBuilder.AppendLine("### **Video Summarization:**");
            analysisBuilder.AppendLine();
            analysisBuilder.AppendLine(videoAnalysis.Summarization);
            analysisBuilder.AppendLine();
            analysisBuilder.AppendLine("### **Character Description:**");
            analysisBuilder.AppendLine();
            for (int i = 0; i < videoAnalysis.Characters.Count; i++)
            {
                var character = videoAnalysis.Characters[i];
                analysisBuilder.AppendLine($"#### **{character.Alias}:**");
                analysisBuilder.AppendLine($"- Appearance: {character.Appearance}");
                analysisBuilder.AppendLine($"- Speaking Tone: {character.SpeakingTone}");
                analysisBuilder.AppendLine();
            }
            analysisBuilder.AppendLine();
            analysisBuilder.AppendLine("### **Chapter Description:**");
            for (int i = 0; i < videoAnalysis.Chapters.Count; i++)
            {
                var chapter = videoAnalysis.Chapters[i];
                analysisBuilder.AppendLine($"#### **{chapter.StartTime} to {chapter.EndTime}:**");
                analysisBuilder.AppendLine($"- {chapter.Description}");
                analysisBuilder.AppendLine();
            }

            VideoAnalysis = analysisBuilder.ToString().Trim();

            return videoAnalysis;
        }

        public static async Task<List<Subtitle>> TranslateVideo(List<Subtitle> originalSubtitles)
        {
            var promptBuilder = new StringBuilder();
            promptBuilder.AppendLine(VideoAnalysis);
            promptBuilder.AppendLine();
            promptBuilder.AppendLine("---");
            promptBuilder.AppendLine();
            promptBuilder.AppendLine("# **Translation Guideline**");
            promptBuilder.AppendLine();
            promptBuilder.AppendLine(TranslationGuideline);
            promptBuilder.AppendLine();
            promptBuilder.AppendLine("---");
            promptBuilder.AppendLine();
            promptBuilder.AppendLine("# **Transcript Array**");
            promptBuilder.AppendLine();
            promptBuilder.AppendLine($"> Be noted that this is only the transtription of the chapter from `{TimeSpanHelper.AsString(originalSubtitles[0].StartTime, false)}` to `{TimeSpanHelper.AsString(originalSubtitles[0].EndTime, false)}`.");
            promptBuilder.AppendLine();
            promptBuilder.AppendLine("```json");
            promptBuilder.AppendLine(JsonConvert.SerializeObject(originalSubtitles
                .Select(s => new TranslatedSubtitle
                {
                    StartAt = TimeSpanHelper.AsString(s.StartTime, false),
                    EndAt = TimeSpanHelper.AsString(s.EndTime, false),
                    Text = s.Text
                })
                .ToList(), Formatting.Indented));
            promptBuilder.AppendLine("```");

            var result = await Gemini.GenerateContentFromVideo(_videoTranslatingInstruction, promptBuilder.ToString(), _videoUri, _videoMimeType, CreativityLevel.Medium);

            var translatedSubtitles = JsonConvert.DeserializeObject<List<TranslatedSubtitle>>(result);

            return originalSubtitles
                .Select((subtitle, index) => new Subtitle
                {
                    StartTime = subtitle.StartTime,
                    EndTime = subtitle.EndTime,
                    Text = translatedSubtitles[index].Text
                })
                .ToList();
        }

        public static async Task ExtractTranslationGuideline()
        {
            TranslationGuideline = await Gemini.GenerateContentFromVideo(_translationGuidelineInstruction, VideoAnalysis, _videoUri, _videoMimeType, CreativityLevel.Medium, false);
        }
    }
}
