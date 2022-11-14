using DotNetPracticeExamples.Models.Composites;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Repository.IRepository
{
	public interface IAlbumFormatCompositeRepository
	{
		List<AlbumFormatComposite> GetAllAlbumFormatComposites();
	}
}