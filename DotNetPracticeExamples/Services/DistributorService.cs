using DotNetPracticeExamples.Models;
using System.Collections.Generic;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;

namespace DotNetPracticeExamples.Services
{
	public class DistributorService : IDistributorService
	{
		private readonly IDistributorRepository _distributorRepository;

		public DistributorService(IDistributorRepository distributorRepository)
		{ _distributorRepository = distributorRepository; }

		public List<Distributor> GetAllDistributors()
		{ return _distributorRepository.GetAllDistributors(); }
	}
}
