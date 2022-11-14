using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Models.Composites;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;
using System;
using System.Collections;
using System.Linq;

namespace DotNetPracticeExamples.Services
{
	public class AlbumService : IAlbumService
	{
		private IAlbumRepository _albumRepository;
		private ICopyrightRepository _copyrightRepository;
		private IDistributorRepository _distributorRepository;
		private IFormatRepository _formatRepository;
		private IGenreRepository _genreRepository;
		private ISongRepository _songRepository;
		private IAlbumFormatCompositeRepository _albumFormatCompositeRepository;
		private IAlbumDistributorCompositeRepository _albumDistributorCompositeRepository;

		public AlbumService(IAlbumRepository albumRepository,
							ICopyrightRepository copyrightRepository,
							IDistributorRepository distributorRepository,
							IFormatRepository formatRepository,
							IGenreRepository genreRepository,
							ISongRepository songRepository,
							IAlbumFormatCompositeRepository albumFormatCompositeRepository,
							IAlbumDistributorCompositeRepository albumDistributorCompositeRepository)
		{
			_albumRepository = albumRepository;
			_copyrightRepository = copyrightRepository;
			_distributorRepository = distributorRepository;
			_formatRepository = formatRepository;
			_genreRepository = genreRepository;
			_songRepository = songRepository;
			_albumFormatCompositeRepository = albumFormatCompositeRepository;
			_albumDistributorCompositeRepository = albumDistributorCompositeRepository;
		}

		/// ///////////////////////////////////////////////////////////////////////////////////////////////////
		/// - Available keywords in query syntax:
		/// From, Select, Join, Aggregate, Union, Distinct, Take, Skip, In, Group, OrderBy, ThenBy, Reverse, Let, Into, DefaultIfEmpty, Where, Count, Sum, Min, Max, Average

		/// - Available extension methods in method syntax (most common):
		/// Select, Where, OrderBy, OrderByDescending, ThenBy, ThenByDescending, Join, GroupJoin, GroupBy, Distinct, Concat, Union, Intersect, Except, Zip, Skip, SkipWhile, 
		/// Take, TakeWhile, Reverse, ToArray, ToList, ToDictionary, ToLookup, AsEnumerable, Cast, OfType, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, 
		/// ElementAt, Min, Max, Average, Sum, Aggregate

		public IEnumerable GetAllAlbums()
		{ return _albumRepository.GetAllAlbums(); }

		/// /////////// Get All Albums And List Songs ///////////
		public IEnumerable GetAllSongsOfAlbum()
		{
			///Query Syntax
			var queryResult = from album in _albumRepository.GetAllAlbums().Cast<Album>()
							  orderby album.Title ascending
							  select new
							  {
								  Album = album.Title,
								  Genre = album.Genre,

								  //List of songs in album
								  Songs = (from song in _songRepository.GetAllSongs().Cast<Song>()
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
			var methodResult = from album in _albumRepository.GetAllAlbums().Cast<Album>()
							   .OrderBy(album => album.Title)
							   select new
							   {
								   Album = album.Title,
								   Genre = album.Genre,
								   
								   //List of songs in album
								   Songs = _songRepository.GetAllSongs().Cast<Song>()
										   .Where(song => song.AlbumId == album.Id)
										   .OrderBy(song => song.Artist)
										   .Select(song => new
										   {
											   Artist = song.Artist,
											   Title = song.Title,
											   Duration = song.Duration.ToString(@"mm\:ss")
										   }).ToList() //Returns multiple results and must be converted to a list
							   };

			return methodResult;
		}

		/// /////////// Get All Albums With Total Duration ///////////
		public IEnumerable GetAllAlbumsWithTotalDuration()
		{
			var queryResult = from album in _albumRepository.GetAllAlbums().Cast<Album>()
							  let songList = (from song in _songRepository.GetAllSongs().Cast<Song>()
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

		public IEnumerable GetAllAlbumsWithAverageRating()
		{
			var queryResult = from album in _albumRepository.GetAllAlbums().Cast<Album>()
							  let songList = (from song in _songRepository.GetAllSongs().Cast<Song>()
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

		public IEnumerable GetAllAlbumsWithFormats()
		{
			var queryResult = from album in _albumRepository.GetAllAlbums().Cast<Album>()

							  let formatComp = (from formatC in _albumFormatCompositeRepository.GetAllAlbumFormatComposites().Cast<AlbumFormatComposite>()
												where album.Id == formatC.AlbumId
												select formatC).ToList()

							  let formatList = (from formatC in formatComp
												from formatL in _formatRepository.GetAllFormats().Cast<Format>()
												where formatC.FormatId == formatL.Id
												select formatL.Type).ToList()

							  select new
							  {
								  Album = album.Title,
								  Formats = formatList
							  };

			return queryResult;
		}

		public IEnumerable GetAllAlbumsWithFormatsAndDistributors()
		{
			var queryResult = from album in _albumRepository.GetAllAlbums().Cast<Album>()

								  //Format
							  let formatComp = (from formatC in _albumFormatCompositeRepository.GetAllAlbumFormatComposites().Cast<AlbumFormatComposite>()
												where album.Id == formatC.AlbumId
												select formatC).ToList()

							  let formatList = (from formatC in formatComp
												from formatL in _formatRepository.GetAllFormats().Cast<Format>()
												where formatC.FormatId == formatL.Id
												select formatL.Type).ToList()

							  //Distributor
							  let distributorComp = (from distroC in _albumDistributorCompositeRepository.GetAllAlbumDistributorComposites().Cast<AlbumDistributorComposite>()
													 where album.Id == distroC.AlbumId
													 select distroC).ToList()

							  let distributorList = (from distroC in distributorComp
													 from distroL in _distributorRepository.GetAllDistributors().Cast<Distributor>()
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
