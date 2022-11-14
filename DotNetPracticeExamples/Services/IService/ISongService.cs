using System.Collections;

namespace DotNetPracticeExamples.Services.IService
{
    public interface ISongService
    {
        IEnumerable GetAllSongs();
    }
}