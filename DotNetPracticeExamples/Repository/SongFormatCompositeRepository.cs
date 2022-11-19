using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Models.Composites;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository
{
	public class SongFormatCompositeRepository : ISongFormatCompositeRepository
	{
		private readonly ApiDbContext _dbContext;

		public SongFormatCompositeRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public List<SongFormatComposite> GetAllSongFormatComposites()
		{ return _dbContext.SongFormatComposite.ToList(); }
	}
}