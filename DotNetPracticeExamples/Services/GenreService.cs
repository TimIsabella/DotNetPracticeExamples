using DotNetPracticeExamples.Models;
using System.Collections.Generic;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;
using System.Collections;

namespace DotNetPracticeExamples.Services
{
	public class GenreService : IGenreService
	{
		private readonly IGenreRepository _genreRepository;

		public GenreService(IGenreRepository genreRepository)
		{ _genreRepository = genreRepository; }

		public IEnumerable GetAllGenres()
		{ return _genreRepository.GetAllGenres(); }
	}
}
