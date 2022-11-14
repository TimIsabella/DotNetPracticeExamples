using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using System.Collections.Generic;
using DotNetPracticeExamples.Models;

namespace DotNetPracticeExamples.Repository
{
	public class FormatRepository : IFormatRepository
	{
		private readonly ApiDbContext _dbContext;

		public FormatRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public List<Format> GetAllFormats()
		{ return _dbContext.Formats.ToList(); }
	}
}
