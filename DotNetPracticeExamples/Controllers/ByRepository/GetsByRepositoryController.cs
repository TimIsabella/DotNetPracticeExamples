using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Repository.IRepository;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Controllers.ByRepository
{
	[Route("api/GetsByRepositoryController")]
	[ApiController]
	public class GetsByRepositoryController : ControllerBase
	{
		private readonly IGenreRepository _genreRepository;

		public GetsByRepositoryController(IGenreRepository genreRepository)
		{ _genreRepository = genreRepository; }

		[HttpGet]
		public IActionResult GetAllGenres()
		{ 
			List<Genre> result = _genreRepository.GetAllGenres();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}
	}
}