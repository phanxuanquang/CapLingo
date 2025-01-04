namespace Translator.Models
{
    public class PlotAnalysis
    {
        public string SettingAndContextOfStory { get; set; }
        public string PlotDescription { get; set; }

        public class Infor
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Content { get; set; }
        }
    }
}
