namespace Translator.Models
{
    public class VideoAnalysis
    {
        public string AudioLanguage { get; set; }  // The language of the audio in the video
        public string Summarization { get; set; }  // The summary of the video content, including the historical setting and the main plot
        public List<Chapter> Chapters { get; set; } // The chapters of the video
        public List<Character> Characters { get; set; } // The characters in the video
    }
}
