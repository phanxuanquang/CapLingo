using Domains;

namespace Translator.Models
{
    public class Chapter
    {
        [Required]
        public string StartTime { get; set; } // The start time of the chapter in the video, in the format of MM:SS
        [Required]
        public string EndTime { get; set; } // The end time of the chapter in the video, in the format of MM:SS
        [Required]
        public string Description { get; set; } // The description of the chapter, including the main events and the main characters
    }
}
