using DotNetPracticeExamples.Data;
using System.Linq;
using System.Collections;
using DotNetPracticeExamples.Repository.IRepository;

namespace DotNetPracticeExamples.Repository
{
	public class AlbumDistributorCompositeRepository : IAlbumDistributorCompositeRepository
	{
		private readonly ApiDbContext _dbContext;

		public AlbumDistributorCompositeRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public IEnumerable GetAllAlbumDistributorComposites()
		{ return _dbContext.AlbumDistributorComposite.ToList(); }
	}
}