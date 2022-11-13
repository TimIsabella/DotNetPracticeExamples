using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository.IRepository
{
    public interface IDistributorRepository
    {
        List<Distributor> GetAllDistributors();
    }
}