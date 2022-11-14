using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Models.Composites;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository
{
	public class AlbumFormatCompositeRepository : IAlbumFormatCompositeRepository
	{
		private readonly ApiDbContext _dbContext;

		public AlbumFormatCompositeRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public List<AlbumFormatComposite> GetAllAlbumFormatComposites()
		{ return _dbContext.AlbumFormatComposite.ToList(); }
	}
}