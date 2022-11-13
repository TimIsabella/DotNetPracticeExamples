using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository
{
	public class DistributorRepository : IDistributorRepository
	{
		private readonly ApiDbContext _dbContext;

		public DistributorRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public List<Distributor> GetAllDistributors()
		{ return _dbContext.Distributors.ToList(); }
	}
}
