using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetPracticeExamples.Controllers
{
	//URL 'Route' -- https://localhost:1234/api/SongsGets
	//- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
	//[Route("api/[controller]")]
	[Route("api/SongsGets")]
	[ApiController]
	public class SongsGetsController : ControllerBase
	{
		private ApiDbContext _dbContext;

		public SongsGetsController(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		/// ///////////////////////////////// GET ALL EXAMPLES /////////////////////////////////

		/// /////////// 'IEnumerable' collection Return ///////////
		[HttpGet("GetAllIEnumerable")]
		public IEnumerable<Song> GetAllIEnumerable() //Extend 'songs' List with IEnumerable extensions
		{
			return _dbContext.Songs; //Return JSON list of songs to client
		}

		/// /////////// 'IActionResult' Return ///////////
		[HttpGet("GetAllIActionResult")]
		public IActionResult GetAllIActionResult() // 'IActionResult' (.NET interface of 'Mvc' class) -- Defines a contract that represents the result of an action method
		{
			return StatusCode(200, _dbContext.Songs);
		}

		/// ///////////////////////////////// GET BY EXAMPLES /////////////////////////////////

		/// /////////// Simple Int Return ///////////
		//- Gets an int from url and returns it to the client
		[HttpGet("GetIntReturn/{returnInt}")]
		public int GetReturnInt(int returnInt)
		{
			return returnInt;
		}

		/// /////////// Get By Id and return 'Song' model ///////////
		//- 'Song' model return does not support 'ControllerBase' and must be returned separately
		[HttpGet("GetByIdSingleModel/{id}")]
		public Song GetByIdSingleModel(int id)
		{
			var song = _dbContext.Songs.Find(id);

			if(song == null)
			{
				NotFound($"Id: {id} not found");
				return song; 
			}
			else
			{
				StatusCode(200);
				return song;
			}
		}

		/// /////////// Get By Id and return 'IActionResult' ///////////
		[HttpGet("GetByIdIActionResult/{id}")]
		public IActionResult GetByIdIActionResult(int id)
		{
			var song = _dbContext.Songs.Find(id);

			if(song == null)
			{
				return StatusCode(404, $"Id: {id} not found.");
			}
			else
			{
				return StatusCode(200, song);
			}
		}

		/// ///////////////////////////////// GET WITH ASYNCHRONUS TASK EXAMPLES /////////////////////////////////

		/// /////////// 'IEnumerable' collection Return of 'Task' with 'await' ///////////
		[HttpGet("GetAllIEnumerableAsyncTask")]
		public async Task<IEnumerable<Song>> GetAllIEnumerableAsyncTask()
		{
			//Must use '.ToListAsync()' to apply 'await'
			return await _dbContext.Songs.ToListAsync();
		}

		/// /////////// 'IActionResult' Return of 'Task' with 'await' ///////////
		[HttpGet("GetAllIActionResultAsyncTask")]
		public async Task<IActionResult> GetAllIActionResultAsyncTask() // 'IActionResult' (.NET interface of 'Mvc' class) -- Defines a contract that represents the result of an action method
		{
			//Must use '.ToListAsync()' to apply 'await'
			return StatusCode(200, await _dbContext.Songs.ToListAsync());
		}

		/// /////////// Simple Int Return of 'Task' with 'await' ///////////
		//- Gets an int from url and returns it to the client
		[HttpGet("GetIntReturnAsyncTask/{returnInt}")]
		public async Task<int> GetIntReturnAsyncTask(int returnInt)
		{
			//'int' contains no extension methods so must be wrapped in 'Task' to apply 'await'
			return await Task.FromResult(returnInt);
		}

		/// /////////// Get By Id and return return 'Song' model or 'Task' with await ///////////
		//- 'Song' model return does not support 'ControllerBase' and must be returned separately
		[HttpGet("GetByIdSingleModelAsyncTask/{id}")]
		public async Task<Song> GetByIdSingleModelAsyncTask(int id)
		{
			var song = await _dbContext.Songs.FindAsync(id); //Asyncronus find

			if(song == null)
			{
				await Task.FromResult( NotFound($"Id {id} not found.") );
				return await Task.FromResult(song);
			}
			else
			{
				await Task.FromResult(StatusCode(200));

				//'song' contains no extension methods so must be wrapped in 'Task' to apply 'await'
				return await Task.FromResult(song);
			}
		}

		[HttpGet("GetByIdIActionResultAsyncTask/{id}")]
		public async Task<IActionResult> GetByIdIActionResultAsyncTask(int id)
		{
			var song = await _dbContext.Songs.FindAsync(id);

			if(song == null)
			{
				return await Task.FromResult(NotFound($"Id {id} not found."));
			}
			else
			{
				return StatusCode(200, await Task.FromResult(song));
			}
		}
	}
}
