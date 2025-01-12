namespace Translator.Models
{
    public class Chapter
    {
        public string StartTime { get; set; } // The start time of the chapter in the video, in the format of HH:MM:SS
        public string EndTime { get; set; } // The end time of the chapter in the video, in the format of HH:MM:SS
        public string Description { get; set; } // The description of the chapter, including the main events and the main characters
    }
}
