using DotNetPracticeExamples.Models;
using System.Collections.Generic;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;
using System.Collections;

namespace DotNetPracticeExamples.Services
{
	public class AlbumService : IAlbumService
	{
		private readonly IAlbumRepository _albumRepository;

		public AlbumService(IAlbumRepository albumRepository)
		{ _albumRepository = albumRepository; }

		public IEnumerable GetAllAlbums()
		{ return _albumRepository.GetAllAlbums(); }
	}
}
