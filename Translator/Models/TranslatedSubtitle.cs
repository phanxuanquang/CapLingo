namespace Translator.Models
{
    public class TranslatedSubtitle
    {
        public string StartAt { get; set; } // The start time of the dialog in the video, in the format of HH:MM:SS
        public string EndAt { get; set; } // The end time of the dialog in the video, in the format of HH:MM:SS
        public string Text { get; set; }  // The text transcribed from the audio in the video from the StartTime to EndTime, may be inaccurate
    }
}
