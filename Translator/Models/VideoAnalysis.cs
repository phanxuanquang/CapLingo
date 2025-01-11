namespace Translator.Models
{
    public class VideoAnalysis
    {
        public string AudioLanguage { get; set; }
        public string Summarization { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Character> Characters { get; set; }
    }
}
