using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository
{
	public class CopyrightRepository : ICopyrightRepository
	{
		private readonly ApiDbContext _dbContext;

		public CopyrightRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public List<Copyright> GetAllCopyrights()
		{ return _dbContext.Copyrights.ToList(); }
	}
}