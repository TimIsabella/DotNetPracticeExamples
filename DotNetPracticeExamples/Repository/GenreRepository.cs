using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using System.Linq;
using DotNetPracticeExamples.Repository.IRepository;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository
{
	public class GenreRepository : IGenreRepository
	{
		private readonly ApiDbContext _dbContext;

		public GenreRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public List<Genre> GetAllGenres()
		{ return _dbContext.Genres.ToList(); }
	}
}
