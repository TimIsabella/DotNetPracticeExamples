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
	}
}
