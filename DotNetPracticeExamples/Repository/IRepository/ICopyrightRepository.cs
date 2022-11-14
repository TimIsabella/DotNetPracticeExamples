using System.Collections;

namespace DotNetPracticeExamples.Repository.IRepository
{
    public interface ICopyrightRepository
    {
        IEnumerable GetAllCopyrights();
    }
}