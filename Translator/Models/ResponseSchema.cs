namespace Translator.Models
{
    public class ResponseSchema
    {
        [Required]
        public List<Chapter> Chapters { get; set; }
        [Required]
        public List<Character> Characters { get; set; }
        [Required]
        public string PlotSetting { get; set; }
    }
}
