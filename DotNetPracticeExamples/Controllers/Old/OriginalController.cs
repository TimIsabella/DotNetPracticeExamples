using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using DotNetPracticeExamples.Helpers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetPracticeExamples.Controllers.Old
{
	//URL 'Route' -- https://localhost:1234/api/controllername
	//- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
	//[Route("api/[controller]")]
	[Route("api/Old/OriginalController")]
	[ApiController]
	public class OriginalController : ControllerBase
	{
		private ApiDbContext _dbContext;

		public OriginalController(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		/// //////////////////////////////////////////// GET //////////////////////////////////////////// 

		//On HTTP GET, the below method will be called and return 'IActionResult' to the client on an 'async' thread
		//- 'IActionResult' (.NET interface of 'Mvc' class) -- Defines a contract that represents the result of an action method
		//- 'IActionResult' is placed in an asynchronus 'Task<>' list which returns that 'IActionResult' upon completion
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			//On 'status 200 OK' return JSON list of songs to client
			//- '.Ok' (.NET extension of 'ControllerBase' class) -- Action method that returns an 'OkObjectResult' object on status '200 OK'
			//- 'await' runs the code in a separate asynchronous thread
			//- '.ToListAsync' returns the result as a 'Task<>' list upon asynchronus completion
			return Ok(await _dbContext.SongsWithImage.ToListAsync());
		}

		//Get() with 'IEnumerable' return
		/*
		//On HTTP GET, the below method will be called and return 'IEnumerable' of 'Songs' to the client
		[HttpGet]
		public IEnumerable<Song> Get() //Extend 'songs' List with IEnumerable extensions
		{ return _dbContext.Songs; }   //Rerturn JSON list of songs to client
		*/

		//Get() with 'IActionResult' return
		/*
		//On HTTP GET, the below method will be called and return 'IActionResult' of 'Songs' to the client
		[HttpGet]
		public IActionResult Get() // 'IActionResult' (.NET interface of 'Mvc' class) -- Defines a contract that represents the result of an action method
		{
			//On 'status 200 OK' return JSON list of songs to client
			//- '.Ok' (.NET extension of 'ControllerBase' class) -- Action method that returns an 'OkObjectResult' object on status '200 OK'
			return Ok(_dbContext.Songs);
		}
		*/

		//Status code returns
		/*
		--Other status codes--
		 return BadRequest();
		 return NotFound();
		 return StatusCode(123);
		 return StatusCode(StatusCodes.Status200OK);
		 return StatusCode(StatusCodes.Status404NotFound);
		*/

		/// //////////////////////////////////////////// GET by index ////////////////////////////////////////////

		//On HTTP GET, the below method will be called to return a song in 'Songs' by 'index' to the client
		[HttpGet("{index}")]
		public IActionResult Get(int index)
		{
			var song = _dbContext.SongsWithImage.Find(index); //Get song by index

			if (song == null)
			{ return NotFound($"Index: {index} not found"); }
			else
			{ return Ok(song); } //Return song on status '200 OK'
		}

		/// //////////////////////////////////////////// GET by index of method name ////////////////////////////////////////////

		//URL 'Route' -- https://localhost:1234/api/controllername/test/111
		//- '[action]' represents the method name to access directly
		[HttpGet("[action]/{id}")]
		public int Test(int id)
		{ return id; }


		/// //////////////////////////////////////////// POST ////////////////////////////////////////////

		//On HTTP POST, the below will be called to '.Add' a song to the 'songs' List
		//- 'FromForm' (.NET extension of the 'FromFormAttribute' class) -- gets form data from the client 'form-data'
		//- 'song' parameter of class 'Song' is set by form data captured by 'FromForm'
		[HttpPost]
		public async Task<IActionResult> Post([FromForm] SongWithImage song)
		{
			///Code for Azure relocated to 'FileHelper.cs'
			/*
			//Connection string from Azure 'storage account' in 'access keys'
			string connectionString = "DefaultEndpointsProtocol=https;AccountName=musicapistorage111;AccountKey=a/0FxEk+oayUGvdSUD8FIXdM9kizasTVIkXm3r5UiPf0XMaTA/VaMTeEpIYMGYXxF+eDFLb3IzXE+AStcLVlEg==;EndpointSuffix=core.windows.net";
			
			//Azure 'storage account' 'container' name
			string containerName = "songart";

			//Instantiates a new Azure 'blob' connection instance by using the above
			var blobContainerClient = new BlobContainerClient(connectionString, containerName);

			//Call '.GetBlobClient' from above instance to create a new 'blobClient' named as the song 'FileName'
			//- Client input from 'Image' is gotten from 'FromForm'
			//- Song model 'Image' is extended by 'IFormFile' which contains the 'FileName' property
			//- 'FileName' returns the file name from the 'Content-Disposition header'
			var blobClient = blobContainerClient.GetBlobClient(song.Image.FileName);

			//Instantiate a new 'MemoryStream' object from 'System.IO'
			var memoryStream = new MemoryStream();

			//Copies song image to 'memoryStream'
			await song.Image.CopyToAsync(memoryStream);

			//Reset 'stream' position to zero
			memoryStream.Position = 0;

			//Upload 'memoryStream' to Azure 'blobClient'
			await blobClient.UploadAsync(memoryStream);

			//Set 'song.ImageUrl' as image Uri from Azure 'blobClient'
			song.ImageUrl = blobClient.Uri.AbsoluteUri;
			*/

			//Call '.UploadImage' to upload the 'FromForm' file to Azure and return the URI
			var imageUrl = await FileHelper.UploadImage(song.Image);

			//Set 'ImageUrl' to Azure image URI
			song.ImageUrl = imageUrl;

			//Prepare 'song' to be added to database
			await _dbContext.SongsWithImage.AddAsync(song);

			//Update database
			await _dbContext.SaveChangesAsync();

			return StatusCode(StatusCodes.Status201Created);
		}

		//Post() with simple database only update
		/*
		//On HTTP POST, the below will be called to '.Add' a song to the 'songs' List
		//- 'FromBody' (.NET extension of the 'FromBodyAttribute' class) -- gets JSON data from the client 'body'
		//- 'song' parameter of class 'Song' is set by JSON data captured by 'FromBody'
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Song song)
		{ 
			await _dbContext.Songs.AddAsync(song);				//Add song by model schema asynchronusly
			await _dbContext.SaveChangesAsync();                //'.SaveChangesAsync' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database asynchronusly
			return StatusCode(StatusCodes.Status201Created);	//Return status '201 Created' to client upon completion
		}
		*/

		/// //////////////////////////////////////////// PUT ////////////////////////////////////////////

		//On HTTP PUT, the below will be called to replace a song in the 'songs' List by 'index'
		//- '{index}' corresponds with the number in the URL after the route -- https://localhost:1234/api/songs/3
		//- 'FromBody' (.NET extension of the 'FromBodyAttribute' class) -- gets JSON data from the client 'body'
		//- 'song' parameter of class 'Song' is set by JSON data captured by 'FromBody'
		[HttpPut("{index}")]
		public IActionResult Put(int index, [FromBody] SongWithImage songObjFromClient)
		{
			var song = _dbContext.SongsWithImage.Find(index); //Get song by index

			if (song == null)
			{ return NotFound($"Index: {index} not found"); }
			else
			{
				song.Title = songObjFromClient.Title;       //Set 'song' Title from '[FromBody]'
				song.Language = songObjFromClient.Language; //Set 'song' Language from '[FromBody]'
				song.Duration = songObjFromClient.Duration; //Set 'song' Duration from '[FromBody]'
				_dbContext.SaveChanges();                   //'.SaveChanges' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database
				return Ok("Record updated!");               //Return status '200 OK' to client and update message upon completion
			}
		}

		/// //////////////////////////////////////////// DELETE ////////////////////////////////////////////

		//On HTTP DELETE, the below will be called to delete a song in the 'songs' List by 'index'
		//- '{index}' corresponds with the number in the URL after the route -- https://localhost:1234/api/songs/3
		[HttpDelete("{index}")]
		public IActionResult Delete(int index)
		{
			var song = _dbContext.SongsWithImage.Find(index);   //Get song by index

			if (song == null)
			{ return NotFound($"Index: {index} not found"); }
			else
			{
				_dbContext.SongsWithImage.Remove(song); //Remove song with '.Remove' and passing in got gotten by index
				_dbContext.SaveChanges();               //'.SaveChanges' (.NET extension of 'DbContext' class) -- Saves changes made to the context to the database
				return Ok("Record deleted!");           //Return status '200 OK' to client and delete message upon completion
			}
		}
	}
}
