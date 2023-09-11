namespace VidClip.Api.Models
{
    public class Response_Video_Data
    {
        public User User { get; set; }
        public Video_Data Video_Data { get; set; }
        public Pexels_Results Pexels_Results { get; set; }
    }
}
