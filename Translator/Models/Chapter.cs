using Domains;

namespace Translator.Models
{
    public class Chapter
    {
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
