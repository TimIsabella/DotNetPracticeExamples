using System.Collections;

namespace DotNetPracticeExamples.Services.IService
{
	public interface IAlbumService
	{
		IEnumerable GetAllAlbums();
		IEnumerable GetAllSongsOfAlbum();
		IEnumerable GetAllAlbumsWithTotalDuration();
		IEnumerable GetAllAlbumsWithAverageRating();
		IEnumerable GetAllAlbumsWithFormats();
		IEnumerable GetAllAlbumsWithFormatsAndDistributors();
	}
}