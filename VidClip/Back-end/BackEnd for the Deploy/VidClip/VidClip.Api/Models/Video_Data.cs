namespace VidClip.Api.Models
{
    public class Video_Data
    {
        public int id { get; set; }
        public string quality { get; set; }
        public string file_type { get; set; }
        public double? fps { get; set; }
        public string link { get; set; }
        public Resolution resolution { get; set; }

    }
}
