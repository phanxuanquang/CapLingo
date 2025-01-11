namespace Domains
{
    public class Subtitle
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public required string Text { get; set; }
    }
}
