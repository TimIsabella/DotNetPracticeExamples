using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using System.Collections;

namespace DotNetPracticeExamples.Repository
{
	public class AlbumFormatCompositeRepository : IAlbumFormatCompositeRepository
	{
		private readonly ApiDbContext _dbContext;

		public AlbumFormatCompositeRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public IEnumerable GetAllAlbumFormatComposites()
		{ return _dbContext.AlbumFormatComposite.ToList(); }
	}
}