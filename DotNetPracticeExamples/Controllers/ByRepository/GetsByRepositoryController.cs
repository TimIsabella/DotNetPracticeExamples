using DotNetPracticeExamples.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetPracticeExamples.Controllers.ByRepository
{
	[Route("api/GetsByRepositoryController")]
	[ApiController]
	public class GetsByRepositoryController : ControllerBase
	{
		private GenreRepository _genreRepository;

		[HttpGet]
		public IActionResult GetAllGenres()
		{ 
			IQueryable result = _genreRepository.GetAllGenres();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}
	}
}
