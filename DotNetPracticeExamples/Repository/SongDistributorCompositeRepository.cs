using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Models.Composites;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository
{
	public class SongDistributorCompositeRepository : ISongDistributorCompositeRepository
	{
		private readonly ApiDbContext _dbContext;

		public SongDistributorCompositeRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public List<SongDistributorComposite> GetAllSongDistributorComposites()
		{ return _dbContext.SongDistributorComposite.ToList(); }
	}
}