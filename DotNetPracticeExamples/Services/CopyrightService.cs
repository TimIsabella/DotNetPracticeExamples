using System.Collections;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;

namespace DotNetPracticeExamples.Services
{
	public class CopyrightService : ICopyrightService
	{
		private readonly ICopyrightRepository _copyrightRepository;

		public CopyrightService(ICopyrightRepository copyrightRepository)
		{ _copyrightRepository = copyrightRepository; }

		public IEnumerable GetAllCopyrights()
		{ return _copyrightRepository.GetAllCopyrights(); }
	}
}
