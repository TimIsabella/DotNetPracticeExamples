using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotNetPracticeExamples.Models;
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

		public SongService(ISongRepository songRepository,
						   IGenreRepository genreRepository,
						   IAlbumRepository albumRepository)
		{
			_songRepository = songRepository;
			_genreRepository = genreRepository;
			_albumRepository = albumRepository;
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
	}
}
