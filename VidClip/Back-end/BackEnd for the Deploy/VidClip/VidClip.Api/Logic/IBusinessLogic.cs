using VidClip.Api.Models;

namespace VidClip.Api.Logic
{
    public interface IBusinessLogic
    {
        Task<List<Response_Video_Data>> GetVideosAsync(string prompt);
    }
}