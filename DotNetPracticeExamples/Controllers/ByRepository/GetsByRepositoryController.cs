using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Models;
using System.Collections.Generic;
using DotNetPracticeExamples.Services.IService;

namespace DotNetPracticeExamples.Controllers.ByRepository
{
	[Route("api/GetsByRepositoryController")]
	[ApiController]
	public class GetsByRepositoryController : ControllerBase
	{
		private readonly IGenreService _genreService;
		private readonly IDistributorService _distributorService;

		public GetsByRepositoryController(IGenreService genreService, 
										  IDistributorService distributorService)
		{ 
			_genreService = genreService;
			_distributorService = distributorService;
		}

		[HttpGet("GetAllGenres")]
		public IActionResult GetAllGenres()
		{ 
			List<Genre> result = _genreService.GetAllGenres();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		[HttpGet("GetAllDistributors")]
		public IActionResult GetAllDistributors()
		{ 
			List<Distributor> result = _distributorService.GetAllDistributors();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}
	}
}