using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using DotNetPracticeExamples.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using DotNetPracticeExamples.Models.Requests;

namespace DotNetPracticeExamples.Controllers
{
	//URL 'Route' -- https://localhost:1234/api/SongsDeletes
	//- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
	//[Route("api/[controller]")]
	[Route("api/SongsDeletes")]
	[ApiController]
	public class SongsDeletesController : ControllerBase
	{
		private ApiDbContext _dbContext;

		public SongsDeletesController(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		/// ///////////////////////////////// DELETE EXAMPLES /////////////////////////////////

		/// /////////// void Return ///////////

	}
}
