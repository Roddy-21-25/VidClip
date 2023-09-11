using PexelsDotNetSDK.Api;
using VidClip.Api.Models;

namespace VidClip.Api.Logic
{
    public class BusinessLogic : IBusinessLogic
    {
        public async Task<List<Response_Video_Data>> GetVideosAsync(string prompt)
        {
            List<Response_Video_Data> LstVideos = new List<Response_Video_Data>();
            //List<string> LstVideos = new List<string>();

            var pexelsClient = new PexelsClient("IhoaMhX9M2qcffAaMLFJVvHbmdyYmBj7joF0BewdVf7e9VfChyZ20LY7");

            // Add Pagination = PageSize from 15 to 80 result per request.
            var result = await pexelsClient.SearchVideosAsync(prompt, pageSize: 80);

            List<PexelsDotNetSDK.Models.Video> ltsVideosPexel = new List<PexelsDotNetSDK.Models.Video>();
            ltsVideosPexel = result.videos.ToList();

            foreach (var video in ltsVideosPexel)
            {
                string videoLink = video.videoFiles.FirstOrDefault().link;

                Resolution resolution_Set = new Resolution();
                resolution_Set.width = video.width;
                resolution_Set.height = video.height;

                Video_Data video_Data_Set = new Video_Data();
                video_Data_Set.id = video.videoFiles.FirstOrDefault().id;
                video_Data_Set.quality = video.videoFiles.FirstOrDefault().quality;
                video_Data_Set.file_type = video.videoFiles.FirstOrDefault().fileType;
                video_Data_Set.fps = video.videoFiles.FirstOrDefault().fps;
                video_Data_Set.link = video.videoFiles.FirstOrDefault().link;
                video_Data_Set.resolution = resolution_Set;

                User user_Set = new User();
                user_Set.Id = video.user.id;
                user_Set.Name = video.user.name;
                user_Set.url = video.user.url;

                Pexels_Results pexels_Results_Set = new Pexels_Results();
                pexels_Results_Set.id = video.id;
                pexels_Results_Set.Pexel_Video_url = video.url;

                Response_Video_Data response_Video_Data_Set = new Response_Video_Data();
                response_Video_Data_Set.User = user_Set;
                response_Video_Data_Set.Pexels_Results = pexels_Results_Set;
                response_Video_Data_Set.Video_Data = video_Data_Set;

                LstVideos.Add(response_Video_Data_Set);
            }
            return LstVideos;
        }
    }
}
