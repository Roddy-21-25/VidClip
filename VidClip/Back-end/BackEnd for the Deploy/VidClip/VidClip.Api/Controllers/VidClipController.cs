using Microsoft.AspNetCore.Mvc;
using VidClip.Api.Logic;

namespace VidClip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VidClipController : ControllerBase
    {
        private readonly IBusinessLogic _logic;

        public VidClipController(IBusinessLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> GetVideos(String prompt)
        {

            if (prompt  == null)
            {
                return BadRequest();
            }

            var LstVideos = await _logic.GetVideosAsync(prompt);

            return Ok(LstVideos);

        }
    }
}
