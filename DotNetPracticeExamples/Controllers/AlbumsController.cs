using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Services.IService;

namespace DotNetPracticeExamples.Controllers
{
    //URL 'Route' -- https://localhost:1234/api/SongsGets
    //- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
    //[Route("api/[controller]")]
    [Route("api/AlbumsController")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        /// /////////// Get All Albums And List Songs ///////////
        [HttpGet("GetAllAlbums")]
        public IActionResult GetAllAlbums()
        {
            ///Query Syntax
            var result = _albumService.GetAllAlbums();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }

        /// /////////// Get All Albums And List Songs ///////////
        [HttpGet("GetAllSongsOfAlbum")]
        public IActionResult GetAllSongsOfAlbum()
        {
            var result = _albumService.GetAllSongsOfAlbum();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }

        /// /////////// Get All Albums With Total Duration ///////////
        [HttpGet("GetAllAlbumsWithTotalDuration")]
        public IActionResult GetAllAlbumsWithTotalDuration()
        {
            var result = _albumService.GetAllAlbumsWithTotalDuration();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }

        /// /////////// Get All Albums With Average Rating ///////////
        [HttpGet("GetAllAlbumsWithAverageRating")]
        public IActionResult GetAllAlbumsWithAverageRating()
        {
            var result = _albumService.GetAllAlbumsWithAverageRating();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }

        /// /////////// Get All Albums With Formats ///////////
        [HttpGet("GetAllAlbumsWithFormats")]
        public IActionResult GetAllAlbumsWithFormats()
        {
            var result = _albumService.GetAllAlbumsWithFormats();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }

        /// /////////// Get All Albums With Formats and Distributors ///////////
        [HttpGet("GetAllAlbumsWithFormatsAndDistributors")]
        public IActionResult GetAllAlbumsWithFormatsAndDistributors()
        {
            var result = _albumService.GetAllAlbumsWithFormatsAndDistributors();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }
    }
}
