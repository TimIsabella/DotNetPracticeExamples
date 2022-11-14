using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Models.Composites;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository
{
	public class AlbumDistributorCompositeRepository : IAlbumDistributorCompositeRepository
	{
		private readonly ApiDbContext _dbContext;

		public AlbumDistributorCompositeRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public List<AlbumDistributorComposite> GetAllAlbumDistributorComposites()
		{ return _dbContext.AlbumDistributorComposite.ToList(); }
	}
}