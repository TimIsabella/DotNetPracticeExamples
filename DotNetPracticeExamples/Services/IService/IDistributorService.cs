using DotNetPracticeExamples.Models;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Services.IService
{
    public interface IDistributorService
    {
        List<Distributor> GetAllDistributors();
    }
}