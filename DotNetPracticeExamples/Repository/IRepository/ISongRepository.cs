using System.Collections;

namespace DotNetPracticeExamples.Repository.IRepository
{
    public interface ISongRepository
    {
        IEnumerable GetAllSongs();
    }
}