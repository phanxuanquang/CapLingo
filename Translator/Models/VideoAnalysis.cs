namespace Translator.Models
{
    public class VideoAnalysis
    {
        public string VideoLanguage { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Character> Characters { get; set; }
    }
}
