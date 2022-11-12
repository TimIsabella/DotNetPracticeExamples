using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository.IRepository
{
    public interface IGenreRepository
    {
        List<Genre> GetAllGenres();
    }
}