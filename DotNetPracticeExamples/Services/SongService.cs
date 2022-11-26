using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Models.Composites;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace DotNetPracticeExamples.Services
{
	public class SongService : ISongService
	{
		private readonly ISongRepository _songRepository;
		private readonly IGenreRepository _genreRepository;
		private readonly IAlbumRepository _albumRepository;
		private readonly IDistributorRepository _distributorRepository;
		private readonly ISongDistributorCompositeRepository _songDistributorCompositeRepository;

		public SongService(ISongRepository songRepository,
						   IGenreRepository genreRepository,
						   IAlbumRepository albumRepository,
						   IDistributorRepository distributorRepository,
						   ISongDistributorCompositeRepository songDistributorCompositeRepository)
		{
			_songRepository = songRepository;
			_genreRepository = genreRepository;
			_albumRepository = albumRepository;
			_distributorRepository = distributorRepository;
			_songDistributorCompositeRepository = songDistributorCompositeRepository;
		}

		/// ///////////////////////////////// GET EXAMPLES WITH LINQ /////////////////////////////////
		/// - Available keywords in query syntax:
		/// From, Select, Join, Aggregate, Union, Distinct, Take, Skip, In, Group, OrderBy, ThenBy, Reverse, Let, Into, DefaultIfEmpty, Where, Count, Sum, Min, Max, Average

		/// - Available extension methods in method syntax (most common):
		/// Select, Where, OrderBy, OrderByDescending, ThenBy, ThenByDescending, Join, GroupJoin, GroupBy, Distinct, Concat, Union, Intersect, Except, Zip, Skip, SkipWhile, 
		/// Take, TakeWhile, Reverse, ToArray, ToList, ToDictionary, ToLookup, AsEnumerable, Cast, OfType, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, 
		/// ElementAt, Min, Max, Average, Sum, Aggregate

		public IEnumerable GetAllSongs()
		{ return _songRepository.GetAllSongs(); }

		public IEnumerable GetSongsByGenre(string genre)
		{
			///Query Syntax
			var queryResult = from song in _songRepository.GetAllSongs().Cast<Song>()
							  where EF.Functions.Like(song.Genre, $"%{genre}%") //Directly 'LIKE' operator in SQL -- LINQ does not contain a LIKE operator
							  orderby song.Title ascending
							  select new
							  {
								  Artist = song.Artist,
								  Title = song.Title,
								  Duration = song.Duration.ToString(@"mm\:ss") //Break down TimeSpan duration to 01:23 time format
							  };

			///Method Syntax
			var methodResult = _songRepository.GetAllSongs().Cast<Song>()
							   .Where(song => song.Genre.Contains(genre))
							   .OrderBy(song => song.Title)
							   .Select(song => new
							   {
								   Artist = song.Artist,
								   Title = song.Title,
								   Duration = song.Duration.ToString(@"mm\:ss") //Break down TimeSpan duration to 01:23 time format
							   });

			return methodResult;
		}

		public IEnumerable GetSongsByRatingGreaterThan(int rating)
		{
			///Query Syntax
			var queryResult = from song in _songRepository.GetAllSongs().Cast<Song>()
							  where song.Rating >= rating
							  orderby song.Title ascending
							  select new
							  {
								  Artist = song.Artist,
								  Title = song.Title,
								  Duration = song.Duration.ToString(@"mm\:ss")
							  };

			///Method Syntax
			var methodResult = _songRepository.GetAllSongs().Cast<Song>()
							   .Where(song => song.Rating >= rating)
							   .OrderBy(song => song.Title)
							   .Select(song => new
							   {
								   Artist = song.Artist,
								   Title = song.Title,
								   Duration = song.Duration.ToString(@"mm\:ss")
							   });

			return methodResult;
		}

		public IEnumerable GetSongsByDurationGreaterThan(int duration)
		{
			///Query syntax
			var queryResult = from song in _songRepository.GetAllSongs().Cast<Song>()
							  where song.Duration.Minutes >= duration
							  orderby song.Duration.Minutes
							  select new
							  {
								  Artist = song.Artist,
								  Title = song.Title,
								  Duration = song.Duration.ToString(@"mm\:ss")
							  };

			return queryResult;
		}

		public IEnumerable GetSongsPagniated(int pageIndex, int pageSize)
		{
			/////Query Syntax
			//var queryResult = (from song in _songRepository.GetAllSongs().Cast<Song>()
			//				   select song)
			//				   .Skip((pageIndex - 1) * pageSize)    //Query syntax does not have skip
			//				   .Take(pageSize);                     //Query syntax does not have take

			///Query Syntax
			var queryResult = (from song in _songRepository.GetAllSongs().Cast<Song>()
							   select song)
							   .Skip((pageIndex - 1) * pageSize)    //Query syntax does not have skip
							   .Take(pageSize);                     //Query syntax does not have take

			///Method Syntax
			//'Skip' songs elements by pagination formula
			//- formula establishes proper element start position
			//- Example:
			//-- Page 1 with 3 results: 0 * 3 = 0 -- 0 index starting point
			//-- Page 2 with 3 results: 1 * 3 = 3 -- 3 index starting point
			//-- Page 3 with 3 results: 2 * 3 = 6 -- 6 index starting point
			var skippedSongs = _songRepository.GetAllSongs().Cast<Song>().Skip((pageIndex - 1) * pageSize);

			//'Take' elements by size
			var takeSongs = skippedSongs.Take(pageSize);

			//Same as above in one line
			var methodResult = _songRepository.GetAllSongs().Cast<Song>()
							   .Skip((pageIndex - 1) * pageSize)
							   .Take(pageSize);

			return methodResult;
		}

		public IEnumerable GetAllSongsJoinedWithAlbumName()
		{
			///Query Syntax
			var queryResult = from song in _songRepository.GetAllSongs().Cast<Song>()
							  join album in _albumRepository.GetAllAlbums().Cast<Album>()
							  on song.AlbumId equals album.Id
							  orderby album.Title ascending
							  select new
							  {
								  Artist = song.Artist,
								  Title = song.Title,
								  Album = album.Title,
								  Duration = song.Duration.ToString(@"mm\:ss")
							  };

			///Method Syntax
			var methodResult = _songRepository.GetAllSongs().Cast<Song>()
							   .Join(_albumRepository.GetAllAlbums().Cast<Album>(),
									 song => song.AlbumId,    //Serves as the 'Where' clause
									 album => album.Id,       //Serves as the 'Where' clause
									 (song, album) => new
									 {
										 Song = song,
										 Album = album
									 })
							   //.Where(joinResult => joinResult.Song.AlbumId == joinResult.Album.Id)
							   .OrderBy(result => result.Album.Title)
							   .Select(result => new
							   {
								   Artist = result.Song.Artist,
								   Title = result.Song.Title,
								   Album = result.Album.Title,
								   Duration = result.Song.Duration.ToString(@"mm\:ss")
							   });

			return methodResult;
		}

		public IEnumerable GetAllSongsByGenre()
		{
			///Query syntax
			var queryResult = from genre in _genreRepository.GetAllGenres().Cast<Genre>()
							  select new
							  {
								  Genre = genre,
								  Songs = (from song in _songRepository.GetAllSongs().Cast<Song>()
										   where song.GenreId == genre.Id
										   orderby song.Artist ascending
										   select new
										   {
											   Artist = song.Artist,
											   Title = song.Title,
											   Duration = song.Duration.ToString(@"mm\:ss")
										   }).ToList()
							  };

			return queryResult;
		}

		public IEnumerable GetAllSongsWithDistributor()
		{
			///Query syntax
			var queryResult = from song in _songRepository.GetAllSongs().Cast<Song>()
							  select new
							  {
								  SongId = song.Id,
								  SongName = song.Title,

								  Distributors = (from distributor in _distributorRepository.GetAllDistributors().Cast<Distributor>()
												  join songC in _songDistributorCompositeRepository.GetAllSongDistributorComposites().Cast<SongDistributorComposite>()
												  on distributor.Id equals songC.DistributorId
												  where songC.SongId == song.Id
												  select new
												  { 
													Id = distributor.Id,
													Name = distributor.Name,
													Url = distributor.Url
												  }).ToList()
							  };

			///Method syntax
			var methodResult = _songRepository.GetAllSongs().Cast<Song>().Select(song => new
							   {
							       SongId = song.Id,
								   SongName = song.Title,

								   Distributors = _distributorRepository   //Get all distributors
												 .GetAllDistributors()
												 .Cast<Distributor>()

												 //Being join...
												 .Join(_songDistributorCompositeRepository	//Get all distributor composites
													   .GetAllSongDistributorComposites()
													   .Cast<SongDistributorComposite>(),

													  //Set records to 'Join on' as alias 'distributor' and 'songC'
													   distributor => distributor.Id,      
													   songC => songC.DistributorId,

													   //Select alias records for 'join'
													   (distributor, songC) => new
													   {
														   distributor,			//'join' records
														   songC
													   })
														
														 //'Where' result of joined records equals 'song.Id'
														 .Where(result => result.songC.SongId == song.Id)
														 
														 //'Select' matching 'distributor'
														 .Select(result => result.distributor)

														 //Create selection of distributor
														 .Select(result => new
														 {
															Id = result.Id,
															Name = result.Name,
															Url = result.Url
														 }).ToList()
								 }).ToList();

			return methodResult;
		}

		public int Post(Song song)
		{
			return _songRepository.Post(song);
		}

		public int Put(int id, Song song)
		{
			return _songRepository.Put(id, song);
		}

		public int DeleteById(int id)
		{
			return _songRepository.DeleteById(id);
		}
	}
}
