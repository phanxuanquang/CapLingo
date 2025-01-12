using GenAI;
using Newtonsoft.Json;
using Translator.Models;
using Utilities;

namespace Translator
{
    public class VideoAnalyst
    {
        public VideoAnalysis VideoAnalysis { get; set; }

        public async Task AnalyzeVideo(string videoUri, string mimeType, sbyte maxTotalChapters)
        {
            var instruction = await FileHelper.ReadFileAsync("Instructions/VideoAnalysisInstruction.md");
            var prompt = "Analyze the provided video and generate a structured JSON output strictly conforming to the structure in the instruction. The output must be clear, complete, and optimized for subsequent processing by another LLM for video translation. Follow the detailed requirements provided in the system instructions.";

            var result = await Gemini.GenerateContentFromVideo(instruction, prompt, videoUri, mimeType, CreativityLevel.Medium, typeof(VideoAnalysis));

            VideoAnalysis = JsonConvert.DeserializeObject<VideoAnalysis>(result);
        }
    }
}
