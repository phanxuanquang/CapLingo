namespace Translator.Models
{
    public class Character
    {
        public string Appearance { get; set; } // The appearance of the character, including the most notable features to identify
        public string SpeakingTone { get; set; } // The speaking tone of the character, including the emotions and the personality
        public string Alias { get; set; } // The alias of the character, defined by the LLM
    }
}
