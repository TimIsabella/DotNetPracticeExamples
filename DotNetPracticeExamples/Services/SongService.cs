using System.Collections;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;

namespace DotNetPracticeExamples.Services
{
	public class SongService : ISongService
	{
		private readonly ISongRepository _songRepository;

		public SongService(ISongRepository songRepository)
		{ _songRepository = songRepository; }

		public IEnumerable GetAllSongs()
		{ return _songRepository.GetAllSongs(); }
	}
}
