using DotNetPracticeExamples.Models;
using System.Collections.Generic;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Services.IService;

namespace DotNetPracticeExamples.Services
{
	public class GenreService : IGenreService
	{
		private readonly IGenreRepository _genreRepository;

		public GenreService(IGenreRepository genreRepository)
		{ _genreRepository = genreRepository; }

		public List<Genre> GetAllGenres()
		{ return _genreRepository.GetAllGenres(); }
	}
}
