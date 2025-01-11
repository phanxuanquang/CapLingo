namespace Translator.Models
{
    public class Character
    {
        [Required]
        public string Appearance { get; set; }
        [Required]
        public string SpeakingTone { get; set; }
        [Required]
        public string Alias { get; set; }
    }
}
