﻿using Microsoft.AspNetCore.Http;
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
	//URL 'Route' -- https://localhost:1234/api/SongsPuts
	//- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
	//[Route("api/[controller]")]
	[Route("api/SongsPuts")]
	[ApiController]
	public class SongsPutsController : ControllerBase
	{
		private ApiDbContext _dbContext;

		public SongsPutsController(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		/// ///////////////////////////////// PUT EXAMPLES /////////////////////////////////

		/// /////////// void Return ///////////
		[HttpPut("PutVoid/{id}")]
		public void PutVoid(int id, [FromForm] Song songFromClient)
		{
			//'.Find()' matching record of 'id' and set as 'song'
			//- '.Find()' checks primary key first, then other columns for 'id' parameter
			//- Returns null if nothing is found
			var song = _dbContext.Songs.Find(id);

			if(song != null)
			{
				//'dbContext' of song modified with values from 
				song.Title = songFromClient.Title;
				song.Language = songFromClient.Language;
				song.Duration = songFromClient.Duration;

				_dbContext.SaveChanges();   //'.SaveChanges' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database
			}

			//No return
		}

		/// /////////// string Return ///////////
		[HttpPut("PutString/{id}")]
		public string PutString(int id, [FromForm] Song songFromClient)
		{
			var song = _dbContext.Songs.Find(id);

			if(song != null)
			{
				song.Title = songFromClient.Title;
				song.Language = songFromClient.Language;
				song.Duration = songFromClient.Duration;

				_dbContext.SaveChanges();

				return $"Song Id: {id} update successful.";
			}
			else
			{
				return $"Song Id: {id} not found.";
			}
		}

		/// /////////// 'IEnumerable' Return ///////////
		[HttpPut("PutIEnumerable/{id}")]
		public IEnumerable PutIEnumerable(int id, [FromForm] Song songFromClient)
		{
			var song = _dbContext.Songs.Find(id);

			if(song != null)
			{
				song.Title = songFromClient.Title;
				song.Language = songFromClient.Language;
				song.Duration = songFromClient.Duration;

				_dbContext.SaveChanges();

				yield return StatusCode(200, $"Song Id: {id} update successful.");
			}
			else
			{
				yield return StatusCode(404, $"Song Id: {id} not found.");
			}
		}

		/// /////////// 'IActionresult' Return ///////////
		[HttpPut("PutIActionresult/{id}")]
		public IActionResult PutIActionresult(int id, [FromForm] Song songFromClient)
		{
			var song = _dbContext.Songs.Find(id);

			if(song != null)
			{
				song.Title = songFromClient.Title;
				song.Language = songFromClient.Language;
				song.Duration = songFromClient.Duration;

				_dbContext.SaveChanges();

				return StatusCode(200, $"Song Id: {id} update successful.");
			}
			else
			{
				return StatusCode(404, $"Song Id: {id} not found.");
			}
		}

		/// /////////// 'IEnumerable' Return of 'Task' with 'await' ///////////
		[HttpPut("PutIEnumerableAsyncTask/{id}")]
		public async Task<IEnumerable> PutIEnumerableAsyncTask(int id, [FromForm] Song songFromClient)
		{
			var song = await Task.FromResult( _dbContext.Songs.Find(id) );

			if(song != null)
			{
				await Task.FromResult( song.Title = songFromClient.Title );
				await Task.FromResult( song.Language = songFromClient.Language );
				await Task.FromResult( song.Duration = songFromClient.Duration );

				await Task.FromResult( _dbContext.SaveChanges() );

				//Return status 200 to client
				return await Task.FromResult(new List<StatusCodeResult>() { StatusCode(200) });
			}
			else
			{
				return await Task.FromResult(new List<StatusCodeResult>() { StatusCode(404) });
			}
		}

		/// /////////// 'IActionResult' Return of 'Task' with 'await' ///////////
		[HttpPut("PutIActionResultAsyncTask/{id}")]
		public async Task<IActionResult> PutIActionResultAsyncTask(int id, [FromForm] Song songFromClient)
		{
			var song = await Task.FromResult( _dbContext.Songs.Find(id) );

			if(song != null)
			{
				await Task.FromResult( song.Title = songFromClient.Title );
				await Task.FromResult(song.Language = songFromClient.Language );
				await Task.FromResult(song.Duration = songFromClient.Duration );

				await Task.FromResult( _dbContext.SaveChanges() );

				return await Task.FromResult( StatusCode(200, $"Song Id: {id} update successful.") );
			}
			else
			{
				return await Task.FromResult( StatusCode(404, $"Song Id: {id} not found.") );
			}
		}
	}
}
