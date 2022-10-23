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
		[HttpDelete("DeleteVoid/{id}")]
		public void DeleteVoid(int id)
		{
			var song = _dbContext.Songs.Find(id);   //Find song record by id

			//If record not null
			if(song != null)
			{
				_dbContext.Songs.Remove(song);  //Remove song with '.Remove()'
				_dbContext.SaveChanges();		//'.SaveChanges' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database
			}

			//No return
		}

		/// /////////// string Return ///////////
		[HttpDelete("DeleteString/{id}")]
		public string DeleteString(int id)
		{
			var song = _dbContext.Songs.Find(id);

			if(song != null)
			{
				_dbContext.Remove(song);
				_dbContext.SaveChanges();
				return $"200 -- Song Id: {id} successfully deleted.";
			}
			else
			{
				return $"404 -- Song Id: {id} not found.";
			}	
		}

		/// /////////// 'IEnumerable' Return ///////////
		[HttpDelete("DeleteIEnumerable/{id}")]
		public IEnumerable DeleteIEnumerable(int id)
		{
			var song = _dbContext.Songs.Find(id);

			if(song != null)
			{
				_dbContext.Remove(song);
				_dbContext.SaveChanges();

				yield return StatusCode(200, $"Song Id: {id} successfully deleted.");
			}
			else
			{
				yield return StatusCode(404, $"Song Id: {id} not found.");
			}
		}
	}
}
