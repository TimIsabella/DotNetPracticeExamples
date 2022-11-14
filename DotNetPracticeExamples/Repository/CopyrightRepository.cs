using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using System.Collections;

namespace DotNetPracticeExamples.Repository
{
	public class CopyrightRepository : ICopyrightRepository
	{
		private readonly ApiDbContext _dbContext;

		public CopyrightRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public IEnumerable GetAllCopyrights()
		{ return _dbContext.Copyrights.ToList(); }
	}
}