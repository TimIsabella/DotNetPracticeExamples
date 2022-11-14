using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Services.IService;
using System.Collections;

namespace DotNetPracticeExamples.Controllers
{
    [Route("api/SongsController")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet("GetAllSongs")]
        public IActionResult GetAllSongs()
        {
            IEnumerable result = _songService.GetAllSongs();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }
    }
}