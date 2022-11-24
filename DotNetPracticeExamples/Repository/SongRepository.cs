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
			return _dbContext.SaveChanges();
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
