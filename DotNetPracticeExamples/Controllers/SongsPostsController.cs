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

namespace DotNetPracticeExamples.Controllers
{
	//URL 'Route' -- https://localhost:1234/api/SongsPosts
	//- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
	//[Route("api/[controller]")]
	[Route("api/SongsPosts")]
	[ApiController]
	public class SongsPostsController : ControllerBase
	{
		private ApiDbContext _dbContext;

		public SongsPostsController(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		/// ///////////////////////////////// POST EXAMPLES /////////////////////////////////

		/// /////////// void Return ///////////
		[HttpPost("PostVoid")]
		public void PostVoid([FromForm] Song song)
		{
			_dbContext.Songs.Add(song);     //Add song by model schema
			_dbContext.SaveChanges();       //'.SaveChanges' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database
											//No return
		}

		/// /////////// int Return ///////////
		[HttpPost("PostInt")]
		public int PostInt([FromForm] Song song)
		{
			_dbContext.Songs.Add(song);     //Add song by model schema
			_dbContext.SaveChanges();       //'.SaveChanges' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database
			return 201;
		}

		/// /////////// 'IEnumerable' Return ///////////
		[HttpPost("PostIEnumerable")]
		public IEnumerable PostIEnumerable([FromBody] Song song) // 'IEnumerable' (.NET interface of 'Collections' class) -- Basic collection in .Net
		{
			_dbContext.Songs.Add(song);     //Add song by model schema
			_dbContext.SaveChanges();       //'.SaveChanges' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database
			yield return StatusCode(201);   //'yeild' fulfills the need of an 'IEnumerable' collection return
		}

		/// /////////// 'IActionResult' Return ///////////
		[HttpPost("PostIActionResult")]
		public IActionResult PostIActionResult([FromBody] Song song) // 'IActionResult' (.NET interface of 'Mvc' class) -- Defines a contract that represents the result of an action method
		{
			_dbContext.Songs.Add(song);		//Add song by model schema
			_dbContext.SaveChanges();		//'.SaveChanges' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database
			return StatusCode(201);			//Return status 201 to client
		}

		/// /////////// 'IEnumerable' Return of 'Task' with 'await' ///////////
		[HttpPost("PostIEnumerableAsyncTask")]
		public async Task<IEnumerable> PostIEnumerableAsyncTask([FromBody] Song song)
		{
			await _dbContext.Songs.AddAsync(song);	//Add song by model schema asynchronusly
			await _dbContext.SaveChangesAsync();	//'.SaveChangesAsync' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database asynchronusly

			//Return status 201 to client
			return await Task.FromResult(new List<StatusCodeResult>() { StatusCode(201) });
		}

		/// /////////// 'IActionResult' Return of 'Task' with 'await' ///////////
		[HttpPost("PostIActionResultAsyncTask")]
		public async Task<IActionResult> PostIActionResultAsyncTask([FromBody] Song song)
		{
			await _dbContext.Songs.AddAsync(song);          //Add song by model schema asynchronusly
			await _dbContext.SaveChangesAsync();            //'.SaveChangesAsync' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database asynchronusly
			return await Task.FromResult(StatusCode(201));  //Return status 201 to client
		}
	}
}
