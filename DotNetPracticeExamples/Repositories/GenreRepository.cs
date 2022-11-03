using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace DotNetPracticeExamples.Repository
{
	public class GenreRepository
	{
		private ApiDbContext _dbContext;

		public GenreRepository(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		public IQueryable<Genre> GetAllGenres()
		{
			IQueryable<Genre> queryResult = from genres
									 in _dbContext.Genres 
									 select genres;

			return queryResult;
		}
	}
}
