using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using System.Collections.Generic;
using System;
using System.Collections;

namespace DotNetPracticeExamples.Repository
{
	public class AlbumRepository : IAlbumRepository
	{
		private ApiDbContext _dbContext;

		public AlbumRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		/// ///////////////////////////////// GET EXAMPLES WITH LINQ /////////////////////////////////
		/// - Available keywords in query syntax:
		/// From, Select, Join, Aggregate, Union, Distinct, Take, Skip, In, Group, OrderBy, ThenBy, Reverse, Let, Into, DefaultIfEmpty, Where, Count, Sum, Min, Max, Average

		/// - Available extension methods in method syntax (most common):
		/// Select, Where, OrderBy, OrderByDescending, ThenBy, ThenByDescending, Join, GroupJoin, GroupBy, Distinct, Concat, Union, Intersect, Except, Zip, Skip, SkipWhile, 
		/// Take, TakeWhile, Reverse, ToArray, ToList, ToDictionary, ToLookup, AsEnumerable, Cast, OfType, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, 
		/// ElementAt, Min, Max, Average, Sum, Aggregate

		/// /////////// Get All Albums And List Songs ///////////
		public List<Album> GetAllAlbums()
		{
			///Query Syntax
			return _dbContext.Albums.ToList();
		}

		/// /////////// Get All Albums And List Songs ///////////
		public IEnumerable GetAllSongsOfAlbum()
		{
			///Query Syntax
			var queryResult = from album in _dbContext.Albums
							  orderby album.Title ascending
							  select new
							  {
								  Album = album.Title,
								  Genre = album.Genre,

								  //List of songs in album
								  Songs = (from song in _dbContext.Songs
										   where song.AlbumId == album.Id
										   orderby song.Artist ascending
										   select new
										   {
											   Artist = song.Artist,
											   Title = song.Title,
											   Duration = song.Duration.ToString(@"mm\:ss")
										   }).ToList() //Returns multiple results and must be converted to a list
							  };

			///Method Syntax
			var methodResult = _dbContext.Albums
							  .OrderBy(album => album.Title)
							  .Select(album => new
							  {
								  Album = album.Title,
								  Genre = album.Genre,

								  //List of songs in album
								  Songs = _dbContext.Songs
										  .Where(song => song.AlbumId == album.Id)
										  .OrderBy(song => song.Artist)
										  .Select(song => new
										  {
											  Artist = song.Artist,
											  Title = song.Title,
											  Duration = song.Duration.ToString(@"mm\:ss")
										  }).ToList() //Returns multiple results and must be converted to a list
							  });

			return methodResult;
		}

		/// /////////// Get All Albums With Total Duration ///////////
		public IEnumerable GetAllAlbumsWithTotalDuration()
		{
			var queryResult = from album in _dbContext.Albums
							  let songList = (from song in _dbContext.Songs
											  where song.AlbumId == album.Id
											  select song
											 ).ToList()
							  select new
							  {
								  Album = album.Title,
								  ///Create new TimeSpan based on sum total of song list duration
								  Duration = new TimeSpan(songList.Sum(song => song.Duration.Hours),    //Get Sum total of songs hours
														  songList.Sum(song => song.Duration.Minutes),  //Get Sum total of songs minutes
														  songList.Sum(song => song.Duration.Seconds)   //Get Sum total of songs seconds
														 ).ToString(@"hh\:mm\:ss"),

								  Songs = (from song in songList
										   select new
										   {
											   Artist = song.Artist,
											   Title = song.Title,
											   Duration = song.Duration.ToString(@"mm\:ss")
										   })
							  };

			return queryResult;
		}

		/// /////////// Get All Albums With Average Rating ///////////
		public IEnumerable GetAllAlbumsWithAverageRating()
		{
			var queryResult = from album in _dbContext.Albums
							  let songList = (from song in _dbContext.Songs
											  where song.AlbumId == album.Id
											  select song
											 ).ToList()
							  select new
							  {
								  Album = album.Title,
								  AverageRating = songList.Sum(song => song.Rating) / songList.Count,
								  Songs = (from song in songList
										   select new
										   {
											   Artist = song.Artist,
											   Title = song.Title,
											   Rating = song.Rating
										   })
							  };

			return queryResult;
		}

		/// /////////// Get All Albums With Formats ///////////
		public IEnumerable GetAllAlbumsWithFormats()
		{
			var queryResult = from album in _dbContext.Albums

							  let formatComp = (from formatC in _dbContext.AlbumFormatComposite
												where album.Id == formatC.AlbumId
												select formatC).ToList()

							  let formatList = (from formatC in formatComp
												from formatL in _dbContext.Formats
												where formatC.FormatId == formatL.Id
												select formatL.Type).ToList()

							  select new
							  {
								  Album = album.Title,
								  Formats = formatList
							  };

			return queryResult;
		}

		/// /////////// Get All Albums With Formats and Distributors ///////////
		public IEnumerable GetAllAlbumsWithFormatsAndDistributors()
		{
			var queryResult = from album in _dbContext.Albums

								  //Format
							  let formatComp = (from formatC in _dbContext.AlbumFormatComposite
												where album.Id == formatC.AlbumId
												select formatC).ToList()

							  let formatList = (from formatC in formatComp
												from formatL in _dbContext.Formats
												where formatC.FormatId == formatL.Id
												select formatL.Type).ToList()

							  //Distributor
							  let distributorComp = (from distroC in _dbContext.AlbumDistributorComposite
													 where album.Id == distroC.AlbumId
													 select distroC).ToList()

							  let distributorList = (from distroC in distributorComp
													 from distroL in _dbContext.Distributors
													 where distroC.DistributorId == distroL.Id
													 select distroL.Name).ToList()

							  select new
							  {
								  Album = album.Title,
								  Formats = formatList,
								  Distributors = distributorList
							  };

			return queryResult;
		}
	}
}