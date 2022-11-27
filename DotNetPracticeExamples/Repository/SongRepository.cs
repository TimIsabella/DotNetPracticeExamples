using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using System.Collections.Generic;
using DotNetPracticeExamples.Models;

namespace DotNetPracticeExamples.Repository
{
	public class SongRepository : ISongRepository
	{
		private readonly ApiDbContext _dbContext;

		public SongRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public List<Song> GetAllSongs()
		{ return _dbContext.Songs.ToList(); }

		public int Post(Song song)
		{
			_dbContext.Songs.Add(song);
			_dbContext.SaveChanges();
			return _dbContext.Entry(song).GetDatabaseValues().GetValue<int>("Id");
		}

		public int Put(int id, Song songFromClient)
		{
			var song = _dbContext.Songs.Find(id);

			if(song != null)
			{
				song.Id = id;
				song.Artist = songFromClient.Artist;
				song.Title = songFromClient.Title;
				song.Genre = songFromClient.Genre;
				song.Duration = songFromClient.Duration;
				song.Rating = songFromClient.Rating;
				song.CopyrightId = songFromClient.CopyrightId;
				song.ForSale = songFromClient.ForSale;

				return _dbContext.SaveChanges();
			}
			else
			{ return 0; }
		}

		public int DeleteById(int id)
		{
			var returnId = 0;
			var song = _dbContext.Songs.Find(id);   //Find song record by id

			//If record not null
			if(song != null)
			{
				_dbContext.Songs.Remove(song);
				_dbContext.SaveChanges();
				returnId = id;
			}

			return returnId;
		}
	}
}
