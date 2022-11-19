using DotNetPracticeExamples.Models.Composites;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository.IRepository
{
	public interface ISongDistributorCompositeRepository
	{
		List<SongDistributorComposite> GetAllSongDistributorComposites();
	}
}