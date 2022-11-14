using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;
using System.Collections;

namespace DotNetPracticeExamples.Services
{
	public class DistributorService : IDistributorService
	{
		private readonly IDistributorRepository _distributorRepository;

		public DistributorService(IDistributorRepository distributorRepository)
		{ _distributorRepository = distributorRepository; }

		public IEnumerable GetAllDistributors()
		{ return _distributorRepository.GetAllDistributors(); }
	}
}
