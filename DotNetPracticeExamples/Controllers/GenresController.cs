using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Services.IService;
using System.Collections;

namespace DotNetPracticeExamples.Controllers
{
    [Route("api/GenresController")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("GetAllGenres")]
        public IActionResult GetAllGenres()
        {
            IEnumerable result = _genreService.GetAllGenres();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }
    }
}