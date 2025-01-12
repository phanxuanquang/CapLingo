using Domains;

namespace Translator.Models
{
    public class Character
    {
        [Required]
        public string Appearance { get; set; } // The appearance of the character, including the most notable features to identify
        [Required]
        public string SpeakingTone { get; set; } // The speaking tone of the character, including the emotions and the personality
        [Required]
        public string Alias { get; set; } // The alias of the character, defined by the LLM
    }
}
