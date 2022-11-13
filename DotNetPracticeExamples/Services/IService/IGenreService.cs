using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Services.IService
{
    public interface IGenreService
    {
        List<Genre> GetAllGenres();
    }
}