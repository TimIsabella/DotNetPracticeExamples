using System.Collections;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;

namespace DotNetPracticeExamples.Services
{
	public class FormatService : IFormatService
	{
		private readonly IFormatRepository _formatRepository;

		public FormatService(IFormatRepository formatRepository)
		{ _formatRepository = formatRepository; }

		public IEnumerable GetAllFormats()
		{ return _formatRepository.GetAllFormats(); }
	}
}
