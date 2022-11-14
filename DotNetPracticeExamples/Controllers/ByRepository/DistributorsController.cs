using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Services.IService;
using System.Collections;

namespace DotNetPracticeExamples.Controllers.ByRepository
{
	[Route("api/DistributorsController")]
	[ApiController]
	public class DistributorsController : ControllerBase
	{
		private readonly IDistributorService _distributorService;

		public DistributorsController(IDistributorService distributorService)
		{ 
			_distributorService = distributorService;
		}

		[HttpGet("GetAllDistributors")]
		public IActionResult GetAllDistributors()
		{
			IEnumerable result = _distributorService.GetAllDistributors();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}
	}
}